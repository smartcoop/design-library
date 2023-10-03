using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Smart.Design.Library.Showcase.Pages.Templates;

public class UploadTelerikModel : PageModel
{
    // 6 upload functions are defined here because I coundn't find a way to use the same function for all controls
    // The parameter name needs to be the same as the control or the files will not be passed to the function
    // We can further investigate / ask Telerik support if there is a cleaner way of achieving this
    public ActionResult OnPostSave1(IEnumerable<IFormFile> files1)
    {
        return OnPostSave(files1);
    }

    public ActionResult OnPostSave2(IEnumerable<IFormFile> files2)
    {
        return OnPostSave(files2);
    }

    public ActionResult OnPostSave3(IEnumerable<IFormFile> files3)
    {
        return OnPostSave(files3);
    }

    public ActionResult OnPostSave4(IEnumerable<IFormFile> files4)
    {
        return OnPostSave(files4);
    }

    public ActionResult OnPostSave5(IEnumerable<IFormFile> files5)
    {
        return OnPostSave(files5);
    }

    public ActionResult OnPostSave6(IEnumerable<IFormFile> files6)
    {
        return OnPostSave(files6);
    }

    public ActionResult OnPostSave(IEnumerable<IFormFile> files)
    {
        if (files != null)
        {
            foreach (var file in files)
            {
                var fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition);

                //// Some browsers send file names with full path.
                //// We are only interested in the file name.
                var fileName = Path.GetFileName(fileContent.FileName.Trim('"'));
                var physicalPath = Path.Combine("App_Data", fileName);

                //// The files are not actually saved in this demo
                ////file.SaveAs(physicalPath);
            }
        }

        // Return an empty string to signify success
        return Content(string.Empty);
    }

    // We only need 1 remove function because the parameter name is not linked to the control name
    public ActionResult OnPostRemove(string[] fileNames)
    {
        // The parameter of the Remove action must be called "fileNames"

        if (fileNames != null)
        {
            foreach (var fullName in fileNames)
            {
                var fileName = Path.GetFileName(fullName);
                var physicalPath = Path.Combine("App_Data", fileName);

                // TODO: Verify user permissions

                if (System.IO.File.Exists(physicalPath))
                {
                    // The files are not actually removed in this demo
                    // System.IO.File.Delete(physicalPath);
                }
            }
        }

        // Return an empty string to signify success
        return Content(string.Empty);
    }
}
