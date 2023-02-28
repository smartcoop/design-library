using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Library.TagHelpers.Layout;

public interface IHtmlLayoutGenerator
{
    TagBuilder GenerateApplicationLayoutInnerContent(IHtmlContent childrenContent);

    TagBuilder GenerateApplicationLayout();

    TagBuilder GenerateSideBar();
    TagBuilder GenerateBody();
    TagBuilder GenerateBodyWrapper(IHtmlContent childContent);

    TagBuilder GenerateMain(IHtmlContent childContent);
}
