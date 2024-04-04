# Smart Design Console Generator

Command line written in .NET 6
A simple command line which allows auto-generating templated pages of components in the design-showcase project.

## Step-by-step

1. Get the names of all components create in the Design Razor library
2. Get the names of all the components already implemented in the Design Showcase web application
3. Generate a templated .cshtml  (and its necessary .cs file) page based on a template of each missing implemented component
4. Write a text file of all generated missing components
5. Generate side-menu items for all components

## Prerequisites
In its original form, the console app generation make some assumptions to work properly:
1. In Design Razor:    * The project folder is called _"Smart.Design.Razor"_ and is in the parent folder of the console application
      * The application is relying on that to construct the base path to the design library
     * All written components are placed in the _"TagHelpers"_ at the root of the project folder and their name finish by _"TagHelper"_
       * The application is relying on that to build an up-to-date list of all created components
2. In Showcase Library:
   * The project folder is called _"Smart.Design.Razor.Showcase"_ and is in the same parent folder as the console app called _"Smart.Design.Showcase.WebApp"_
     * The application is relying on that to construct the base path to the showcase library
   * There is a folder _"Template"_ with files named respectively _"Template.cshtml"_ and _"Template.cshtml.cs"_ in the _"Pages/Component"_ directory.
     * The application is relying on those document to generate a default page component
   * There is a _"_ComponentList.cshtml"_ file in the _"Pages/Shared"_ directory
     * The application is relying on that document to regenerate the side-panel

## When to use
Use the console line app before running the showcase web app to ensure all components have been generated.
