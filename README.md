# ![SmartDesign](art/Smart.logo.png)

# Smart Design Razor
This library is an implementation of the Smart Design with Tag Helpers.
The Smart Design System documentation can be consulted [here](https://design.smart.coop).
## Installation
You should install [Smart.Design.Razor with NuGet](https://www.nuget.org/packages/Smart.Design.Razor):
    
    Install-Package Smart.Design.Razor
Or via the .NET Core command line interface:
    
    dotnet add package Smart.Design.Razor
Add the following line to your _viewport.cshtml

    @addTagHelper *, Smart.Design.Razor

 the dependencies with the following line of code:
```csharp
builder.Services.AddSmartDesign();
```

Add to the &lt;head> tag of your layout the following line:
```html
<link rel="stylesheet" href="_content/Smart.Design.Razor/css/main.css" />
```
