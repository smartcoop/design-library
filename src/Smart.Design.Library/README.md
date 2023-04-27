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
