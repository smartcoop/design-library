# ![SmartDesign](art/Smart.logo.png)

# Smart Design Library
This solution contains a C# UI web kit and a web project showcasing the various components it contains.

## Installation
You should reference [Smart.Design.Library with NuGet](https://www.nuget.org/packages/Smart.Design.Razor):

    Install-Package Smart.Design.Razor
Or via the .NET Core command line interface:

    dotnet add package Smart.Design.Razor
Add the following line to your _viewport.cshtml

    @addTagHelper *, Smart.Design.Razor

Or reference the project directly

Add the dependencies with the following line of code:
```csharp
builder.Services.AddSmartDesign();
```

Add to the &lt;head> tag of your layout the following line:
```html
<link rel="stylesheet" href="_content/Smart.Design.Razor/css/main.css" />
```

# Smart Design Library Showcase

This repository contains the design library website. This site describes the component documentation where you can find copy/pastable HTML and CSS for common components. The Figma design files can be found on our [Figma community profile](https://www.figma.com/@smartcoop).

This library is an implementation of the Smart Design with Tag Helpers. For all instructions to install Smart Design Razor, view the [README here](https://github.com/smartcoop/design-cs).

## Getting started with Smart Design Library Showcase

    git clone git@github.com:smartcoop/design-library-showcase.git

## Start a local Docker container

The folder of the application `Smart.Design.Showcase` contains a file `Dockerfile` that can be used to build a Docker image for this application.

To create the image, please use this command from the directory of the application `Smart.Design.Showcase`:

    docker build -t smart.design.showcase .

Aferthat, a Docker container can be launched using the command:

    docker run -d --name designshowcase -p 5000:80 smart.design.showcase:latest

The application will be exposed on:

    http://localhost:5000

You also can launch the application using your IDE, like Visual Studio, for example.

## Deploy the application

- Dev: [https://jenkins.smartbe.be/job/COOP-DEV/job/Smart-Design-Showcase.DEV/](https://jenkins.smartbe.be/job/COOP-DEV/job/Smart-Design-Showcase.DEV/)
- Stage: [https://jenkins.smartbe.be/job/COOP-STAGE/job/Smart-Design-Showcase.STAGE/](https://jenkins.smartbe.be/job/COOP-STAGE/job/Smart-Design-Showcase.STAGE/)
- Prod: [https://jenkins.smartbe.be/job/COOP-PROD/job/Smart-Design-Showcase.PROD/](https://jenkins.smartbe.be/job/COOP-PROD/job/Smart-Design-Showcase.PROD/)
