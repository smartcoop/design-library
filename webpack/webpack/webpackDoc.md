# Webpack documentation

## Cadre

## Description

## Instalation
___
### Prérequis :
Prérequis : Il sera nécessaire d’installer Node et NPM préalablement avant de lancer l’installation de WebPack.
- https://nodejs.org/en

NODE.JS est nécessaire car il nous donne accès à NPM son gestionnaire de paquets. C’est NPM qui va nous installer WEBPACK et ses dépendences.
___
### Instalation WEBPACK :

Afin de préparer votre projet à utiliser les dépendances NPM, ouvrez votre terminal, rendez-vous à la racine de votre projet et tapez la commande suivante :

```sh
npm init -y
```

Ceci va créer dans le répertoire un fichier **package.json**. Si le fichier n’est pas créé immédiatement il suffira de le créer manuellement.

Le fichier **package.json** est un fichier qui sert à stocker une représentation exacte des dépendances installées dans le projet à un moment donné. Il permet de garantir que les installations suivantes produiront la même arborescence de dépendances, quelles que soient les mises à jour des packages intermédiaires. Il est donc utile pour assurer la stabilité et la reproductibilité du projet, ainsi que pour optimiser le temps d’installation des dépendances1.

Le fichier **package-lock.json** est généré automatiquement par npm lorsqu’on modifie le fichier package.json ou le dossier node_modules. Il n’est pas nécessaire de le modifier manuellement.

Ensuite pour installer WEBPACK tapez la commande suivante :

```sh
npm install --save-dev webpack@latest webpack-dev-server@latest
```

Pour pouvoir communiquer avec WEBPACK en ligne de commande il faut installer son CLI :

```sh
npm install --save-dev webpack-cli
```
___

### Création des fichiers.

Ensuite, vous allez devoir créez 2 dossiers (public contenant 2 fichiers : index.html, bundle.js et src contenant 1 fichier index.js) et 1 fichier webpack.config.js à la racine.

Si vous avez un terminal de commande linux comme CMDER exécutez la commande suivante :

```sh
touch webpack.config.js && mkdir public src && cd public && touch index.html bundle.js && cd .. && cd src && touch index.js && cd ..
```

Le dossier src/ nous permettra de stocker la logique de notre application tandis que le dossier public nous permettra de stocker tous nos fichiers minifiés.

Ensuite créer le répertoire assets et ses sous répertoires fonts icons images et stylesheets

```sh
mkdir assets && cd assets && mkdir fonts icons images stylesheets && cd ..
```


Une fois ceci fait coller les textes suivants dans les fichiers créés :

**package.json:**

```json
{
  "author": "JAD",
  "name": "webpack Smart design-library",
  "homepage": "smartbe.be",
  "version": "1.0.0",
  "description": "",
  "main": "index.js",
  "keywords": [],
  "license": "ISC",

  "scripts": {
    "start": "webpack serve --config ./webpack.config.js --mode development",
    "dev": "webpack --mode development",
    "prod": "webpack --mode development"
  },


  "devDependencies": {
    "webpack": "^5.88.2",
    "webpack-cli": "^5.1.4",
    "webpack-dev-server": "^4.15.1"
  }
}
```
*Le fichier package.json sert à définir les informations et les dépendances d’un projet qui utilise webpack.
Il contient des champs comme le nom, la version, la description, les scripts, les auteurs, les licences, etc.*

*Il permet aussi de spécifier les modules dont le projet a besoin pour fonctionner, nous pouvons voir la dépendence webpack,webpack-cli,webpack-dev-server que nous avons installé précédemment.*

*Ces modules sont installés avec la commande npm install et sont stockés dans le dossier node_modules.*
___
**webpack.config.js:**

```js
const webpack = require("webpack");
const path = require("path");

let config = {
    entry: "./src/index.js",
    output: {
        path: path.resolve(__dirname, "./public"),
        filename: "./bundle.js"
    }
}

module.exports = config;
```
*Le fichier webpack.config.js sert à configurer les options de webpack, il permet de gérer la gestion des entrées, des sorties, des loaders, des plugins, etc.*
___
**index.html:**
```html
<!DOCTYPE html>
<html>
<head>
    <title>Hello webpack</title>
</head>
<body>
<div>
    <h1>Hello world</h1>
</div>
<script src="bundle.js"></script>
</body>
</html>
```

**index.js:**
```js
document.write("Je débute avec Webpack !");
document.write("<br/>Je suis le fichier d'index");
```
___

Maintenant il suffit de tapez la commande suivante dans le terminal :

```sh
Npm run dev
```

On peut constater qu’un fichier bundle.js a été créé dans le répertoire public.
Le code JS à l’intérieure est celui de notre fichier index.js minifié.

On peut maintenant ouvrir la page public/index.html pour visionner le résultat.

___

### Installation de Babel.

Babel est un transpileur JavaScript qui permet de convertir du code JavaScript moderne en code JavaScript plus ancien, afin que ce dernier puisse être exécuté sur des navigateurs plus anciens
D'abord les dépendances.

```sh
npm install --save-dev babel-loader babel-core
```

Une fois les dépendances installées nous devons ajouter les ligne suivante dans le fichier **webpack.config.js:**

```js
module: {
rules: [{
        test: /\.(js|jsx)$/,
        exclude: /node_modules/,
        use: {  loader: "babel-loader",  },
        },],
},
```
Le fichier **webpack.config.js** doit ressembler à ceci maintenant:
```js
const webpack = require("webpack");
const path = require("path");

let config = {
    entry: "./src/index.js",
    output: {
        path: path.resolve(__dirname, "./public"),
        filename: "./bundle.js"
    },
    module: {
        rules: [{
            test: /\.(js|jsx)$/,
            exclude: /node_modules/, //exclude les node modules pour n utiliser que babel
            use: {  loader: "babel-loader",  },
        },],
    },
}

module.exports = config;
```
Maintenant, nous allons devoir indiquer à Babel qu’il doit utiliser le preset (pré-réglage) ES2015. Pour ce faire, entrez la commande suivante :
```sh
npm install --save-dev babel-preset-env
```
Maintenant créez un fichier **.babelrc** à la racine de votre projet et ajoutez-y le code suivant :
```JSON
{
 "presets": [
  ["env", {
     "targets": {
     "browsers": ["last 2 versions", "safari >= 7"]
    }
  }]
 ]
}
```
Nous pouvons des maintenant utiliser Babel pour générer notre fichiers de librairie .js.

___

### Utiliser de multiples fichiers java-script.
Commençons par modifier notre fichier actuel **index.js:**
```js
document.write("Je suis fichier js d'index");
document.write("<hr/>");
```
Ensuite créons deux nouveaux fichier .js :

**joelle.js:**
```js
document.write("Je suis le fichier js de Joelle");
document.write("<hr/>");
```

**meli.js**
```js
document.write("Je suis le fichier js de Mélissa);
document.write("<hr/>");
```

Nous nous retrouvons maintenant avec trois fichiers .js en entrée, chacun affichant une phrase qui lui est propre.
Nous allons modifier le fichier **webpack.config.js** pour que ls trois fichiers soit compiler en un seule, pour ce faire nous allons utiliser un tableau.

Notre ligne entry :
```js
entry: "./src/index.js",
```
Va être remplacée par celle-ci :
```js
entry: ['./src/index.js', './src/joelle.js', './src/meli.js'],
```

Il suffit maintenant de relancer notre commande :
```sh
npm run dev
```
Puis de vérifier notre **index.html** pour voir que le message de chaque fichier .js est bien présent sur la page.

Nous pouvons de cette façon compiler autant de fichier .js que nous le désirons webpack agrégera et minifiera le code pour nous.

___

### Configurer le css.

Tout d’abord, vous devez installer un chargeur CSS et un chargeur de style dans vos dépendances de développement :
```sh
npm install --save-dev css-loader style-loader
```
Vous pouvez utiliser les deux chargeurs pour tous les fichiers css dans votre configuration Webpack.

Ajoutez dans dans le fichier **webpack.config.js** leslignes suivantes:
```js
test: /\.(css)$/,
use: ['style-loader', 'css-loader'],
```
Vous devez avoir un fichier **webpack.config.js** qui ressemble à ceci :
```js
const webpack = require("webpack");
const path = require("path");

let config = {
    entry: ['./src/index.js', './src/joelle.js', './src/meli.js'],
    output: {
        path: path.resolve(__dirname, "./public"),
        filename: "./bundle.js"
    },
    module: {
        rules: [{
            test: /\.(js|jsx)$/,
            exclude: /node_modules/, //exclude les node modules pour n utiliser que babel
            use: {  loader: "babel-loader",  },

            test: /\.(css)$/,
            use: ['style-loader', 'css-loader'],
        },],
    },
}

module.exports = config;
```

Dans le répertoire assts/stylesheets/ créer le fichier **style.css**.

Copier dedans les lignes suivantes :
```css
h1 {
  color: red;
}
```
Editer le fichier **index.js** et ajouter la ligne suivante au début du fichier:
```js
import '../assets/stylesheets/style.css'
```
Il suffit maintenant de relancer notre commande :
```sh
npm run dev
```
Puis de vérifier notre **index.html** pour voir que le CSS est bien chargé et actif dans notre page.

___


### Générer un fichier CSS.

Tout comme nous l’avons déjà fait pour le java-script nous pouvons créer un fichier unique pour accueillir le CSS de notre projet.

Tout d’abord nous allons ajouter la référence vers notre unique fichier dans la page **index.html:**
```html
<head>
    <link rel="stylesheet" href="main.css">
    <title>Hello webpack</title>
</head>
```
Installer le plugin nécessaire à la création du fichier :
```sh
npm install --save-dev mini-css-extract-plugin
```
Ajouter enfin ces lignes au fichier **webpack.config.js:**
```js
use: [MiniCssExtractPlugin.loader, 'css-loader'],
```
à la place de:
```js
use: ['style-loader', 'css-loader'],
```
Au début du fichier ajouter une nouvelle constante:
```js
const MiniCssExtractPlugin = require('mini-css-extract-plugin');
```
Créer une section plugin:
```js
plugins: [
    new MiniCssExtractPlugin()

],
```
Vous devez avoir un fichier **webpack.config.js** qui ressemble à ceci :
```js
const webpack = require("webpack");
const path = require("path");
const MiniCssExtractPlugin = require('mini-css-extract-plugin');

let config = {
    entry: ['./src/index.js', './src/joelle.js', './src/meli.js'],
    output: {
        path: path.resolve(__dirname, "./public"),
        filename: "./bundle.js"
    },
    module: {
        rules: [{
            test: /\.(js|jsx)$/,
            exclude: /node_modules/, //exclude les node modules pour n utiliser que babel
            use: {  loader: "babel-loader",  },

            test: /\.(css)$/,
            use: [MiniCssExtractPlugin.loader, 'css-loader'],
        },],
    },
    plugins: [
        new MiniCssExtractPlugin()

    ],
}

module.exports = config;
```
Il suffit maintenant de relancer notre commande :
```sh
npm run dev
```
Puis de vérifier notre **index.html** pour voir que le CSS est bien chargé et actif dans notre page.
On trouvera également le fichier **main.css** dans le répertoire public.

___




## commandes utiles

```- npm -v``` : Donne la version actuelle de npm.
