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
**Smart.Design.Library/css/smart-main.min.css**


### Génération du JS final ###  
 Faire un click droit sur l'ensemble des fichiers du dossier  
 **Smart.Design.Library.Showcase/SmartLib/js/smart-modules**  
 et choisir **Bundler & Minifier / Bundle and Minify** Files pour générer le js final  
 Smart.Design.Library.Showcase/SmartLib/js/smart-modules/smart-bundle.js et sa minification **Smart.Design.Library.Showcase/SmartLib/js/smart-bundle.min.js**.  
 Cela comprendra les derniers ajouts/modifications js.

 Il suffira de copier le contenu de ce fichier minifié (Smart.Design.Library.Showcase/SmartLib/js/smart-bundle.min.js) dans :  
**Smart.Design.Library/js/smart-main.min.css**