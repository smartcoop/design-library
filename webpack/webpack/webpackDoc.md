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

```
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

```
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
```
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
```
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

## commandes utiles

```- npm -v``` : Donne la version actuelle de npm.
