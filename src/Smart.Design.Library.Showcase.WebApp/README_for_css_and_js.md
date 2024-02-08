# Installation des extentions.

![N|Solid](https://madskristensen.gallerycdn.vsassets.io/extensions/madskristensen/bundlerminifier/2.8.396/1535134367605/Microsoft.VisualStudio.Services.Icons.Default) **Bundler & Minifier**

Cette extension permet à Visual Studio de créer des fichiers uniques à partir de fichiers JS et CSS. Le contenu du fichier sera également minifié.

- Aller dans le menu Extensions de visual-studio => manage extensions.

- Dans le champ de recherche tapez : Bundler & Minifier

- Cliquer sur le bouton download pour l’installer.

**NB : Visual-Studio doit être redémarrer pour que l’installation soit effectuée.**

Une fois installé dans l'explorateur de solution sélectionner un ou plusieurs fichiers JS ou CSS.
Clique droit pour ouvrir le menu et on trouve le menu **bundler & minifier**.

### liens utiles:
https://marketplace.visualstudio.com/items?itemName=MadsKristensen.BundlerMinifier

___

![N|Solid](https://failwyn.gallerycdn.vsassets.io/extensions/failwyn/webcompiler64/1.14.11/1679936818773/Microsoft.VisualStudio.Services.Icons.Default) **Web Compiler 2022 +**

Cette extension permet à Visual Studio de compiler du scss en css.

- Aller dans le menu Extensions de Visual Studio => manage extensions.

- Dans le champ de recherche tapez : web compiler 2022

- Cliquer sur le bouton download pour l’installer.

**NB : Visual-studio doit être redémarrer pour que l’installation soit effectuée.**

Une fois installé dans l'explorateur de solution sélectionner un fichier SCSS.
Clique droit pour ouvrir le menu et on trouve le menu **Web compiler**.

### liens utiles:
https://marketplace.visualstudio.com/items?itemName=Failwyn.WebCompiler64



# Utilisation des extensions dans Showcase

Les fichiers de configuration (Smart.Design.Library.Showcase/bundleconfig.json et Smart.Design.Library.Showcase/compilerconfig.json) sont déjà présents dans la solution Smart.Design.Library.Showcase.

### Génération du CSS final ###
 Faire un click droit sur
 **Smart.Design.Library.Showcase/SmartLib/scss/main.scss**
 et choisir **Web Compiler / Re-compile file** pour regénérer le CSS final
 Smart.Design.Library.Showcase/SmartLib/css/smart-main.css et sa minification **Smart.Design.Library.Showcase/SmartLib/css/smart-main.css**.
 Cela comprendra les derniers ajouts/modifications css.

 Il suffira de copier le contenu de ce fichier minifié (Smart.Design.Library.Showcase/SmartLib/css/smart-main.min.css) dans :
**Smart.Design.Library/wwwroot/css/**


### Génération du JS final ###
 L'extension Bundle & Minify regroupe tous les fichiers js dans le fichier **Smart.Design.Library.Showcase/SmartLib/js/smart-bundle-client.min.js** dès qu'on modifie et sauve un fichier se retrouvant repris dans  **C:\joe-repos\design-library\src\Smart.Design.Library.Showcase.WebApp\bundleconfig.json**
 

 Il suffira de copier le contenu de ce fichier minifié (Smart.Design.Library.Showcase/SmartLib/js/smart-bundle-client.min.js) dans :
**Smart.Design.Library/wwwroot/js/**

___

![N|Solid](https://ms-vsliveshare.gallerycdn.vsassets.io/extensions/ms-vsliveshare/vsls-vs-2022/1.0.5883.0/1692650871758/Microsoft.VisualStudio.Services.Icons.Default) **Live share 2022**

Permet de visionner en temp réel les modifications faites les fichiers html et css directement dans le navigateur.

**NB : Cette extension est installée de base avec visual-studio.**

### liens utiles:
https://marketplace.visualstudio.com/items?itemName=MS-vsliveshare.vsls-vs-2022

Il suffit de modifier le html ou le css de votre projet et d’attendre. La page du navigateur va se mettre à jour tout seule.

___
