using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Definux.HtmlBuilder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Smart.Design.Razor.Fluent.Components;
using Smart.Presentation.Mvc.Models;
using ViewRenderer.Abstractions;
using Westwind.Web.Mvc;

namespace Smart.Presentation.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly IViewToStringRenderer _viewToStringRenderer;
        private readonly HtmlBuilder _htmlBuilder;
        private readonly ILogger< HomeController > _logger;

        public HomeController( ILogger< HomeController > logger, IWebHostEnvironment appEnvironment, IViewToStringRenderer viewToStringRenderer, HtmlBuilder htmlBuilder )
        {
            _appEnvironment = appEnvironment;
            _viewToStringRenderer = viewToStringRenderer;
            _htmlBuilder = htmlBuilder;
            _logger = logger;
        }

        public async Task< IActionResult > Index()
        {
            return View( "Index", _htmlBuilder.SmartAccordion( "Fluent API", "Send back with fluent api method" ).RenderHtml());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ ResponseCache( Duration = 0, Location = ResponseCacheLocation.None, NoStore = true ) ]
        public IActionResult Error()
        {
            return View( new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier} );
        }
    }
}
