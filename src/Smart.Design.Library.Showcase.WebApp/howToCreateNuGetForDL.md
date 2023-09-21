# Création d'un NUGET package design-library.

## Création du fichier main.css.

Le fichier **main.css** est un bundle contenant l’entièreté du css minifié.
Celui-ci est généré à partir du fichier :
*\Smart.Design.Library.Showcase.WebApp\wwwroot\SmartLib\scss\main.scss*

Celui-ci peut être compiler avec Web compiler 2022+. Le fichier se retrouvera dans le répertoire :
*\design-library\src\Smart.Design.Library.Showcase.WebApp\wwwroot\SmartLib\css\smart-main.min.css*

Ce fichier doit être copié dans le la DL dans le répertoire :
*\design-library\src\Smart.Design.Library\wwwroot\css\smart-main.css*

Le fichier main.css contient le css de mono ainsi que le css maison.

___

## Création du NUGET package.

**JS:**

Aller dans le projet **Smart.Design.Library.Showcase** dans le répertoire :
*\design-library\src\Smart.Design.Library.Showcase.WebApp\wwwroot\SmartLib\js\smart-modules\\*

sélectionner tous les fichiers .js créer un bundle et minifier le js dans un fichier smart-bundle.js dans le réprtoire :
*\design-library\src\Smart.Design.Library.Showcase.WebApp\wwwroot\SmartLib\js\\*

Copier enfin ce fichier dans le projet **Smart.Design.Library** dans le répertoire :
*\design-library\src\Smart.Design.Library\wwwroot\js\\*


**CSS:**

Aller dans le projet **Smart.Design.Library.Showcase** dans le répertoire :
*\design-library\src\Smart.Design.Library.Showcase.WebApp\wwwroot\SmartLib\scss\\*

Recompiler le fichier main.scss (celui-ci ne contient uniquement que des imports)
le fichier *\design-library\src\Smart.Design.Library.Showcase.WebApp\wwwroot\SmartLib\css\smart-main.css* sera régéné.

Copier enfin ce fichier dans le projet **Smart.Design.Library** dans le répertoire :
*\design-library\src\Smart.Design.Library\wwwroot\css\\*


Dans le projet **Smart.Design.Library** il faut faire un clic droit sur le projet aller à propriétés=>packages. Dans la rubrique package version il faut entrer le nouveau numéro de version.

La version doit être aussi mise à jour dans le fichier *Smart.Design.library.csproj* sinon une erreur surviendra durant la compilation.
Au-dessus de l’onglet de la gestion de package il y’a une checkbox « generate nuget package on build ». Elle doit être cochée.
Il suffit maintenant de refaire un build. On trouvera dans le répertoire */bin/debug/* le nouveau fichier nuget.

#### Pre-release
Il s’agit de packages encore en test. Ils doivent faire apparaitre la mention pre-release.
#### Release
Il s’agit de packages validés par les tests et qui peuvent être intégrés aux autres projets.

___

## Upload du package.

Rendez-vous à l’adresse suivante : https://www.nuget.org/packages/Smart.Design.Library/

Allez dans la rubrique upload et uploader le package depuis votre disque dur sur le serveur.
Il est maintenant accessible depuis le menu « manage nuget package » de vos applications.


___

## Mise à jour de la liste des packages.

Il faut ouvrir le fichier :
*\design-library\src\Smart.Design.Library.Showcase.WebApp\Pages\Changelog.cshtml*

Il faut ajouter une nouvelle entrée pour la nouvelle version du package.

___

## Charger le package dans unity.

Ouvrir la solution backend. Clique droit sur le projet Smart.unity.Web puis sur « manage nuget package ». Dans l’onglet de gestion des packages cliquer sur « update » et dans le champ de recherche entrer la chaine « design ».

Le package devrait apparaitre, il suffit de le mettre à jour.

**NB : Veillez à cliquer sur la checkbox « pre-release » si il s’agit d’une version de test.**
