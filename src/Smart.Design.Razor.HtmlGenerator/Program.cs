using Microsoft.Extensions.DependencyInjection;
using Smart.Design.Razor.Extensions;
using Smart.Design.Razor.Templates;

IServiceCollection services = new ServiceCollection();

services.AddSmartDesign();
services.AddSingleton<Templator>();
services.AddRazorTemplating();
var serviceProvider = services.BuildServiceProvider();
var templator = serviceProvider.GetRequiredService<Templator>();

// Generate HTML from the templates and write them at the root.
await templator.GenerateAsync();