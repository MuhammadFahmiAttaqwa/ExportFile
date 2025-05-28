using ExportFile.DataDummy;
using ExportFile.Models;
using ExportFile.Service;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Utilities;
using Rotativa.AspNetCore;
using System.Diagnostics;

namespace ExportFile.Controllers
{

    public class HomeController : Controller
    {
        private readonly IExportFile export;
        public HomeController(IExportFile _exportFile) 
        {
            export = _exportFile;
        
        } 
        public IActionResult Index()
        {
            var data = DataModelDummy.DataDummy();
            
            return View(data);
        }

        [HttpGet("Export")]
        public IActionResult Export(string Or)
        {
            var data = DataModelDummy.DataDummy();
            try
            {
                if (Or.Equals("Excel"))
                {
                    var bytes = export.DownloadExcel(data);
                    return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "DownloadExcel.xlsx");

                }
                if(Or.Equals("Pdf"))
                {
                    return new ViewAsPdf("Index", data)
                    {
                        FileName = "DownloadPdf.pdf",
                        PageSize = Rotativa.AspNetCore.Options.Size.A4,
                        PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait
                    };
                }
                

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
            return BadRequest("Request Erorr");
        }
    }
}
