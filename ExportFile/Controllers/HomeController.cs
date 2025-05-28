using ExportFile.DataDummy;
using ExportFile.Models;
using ExportFile.Repository;
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
        private readonly IDataRepository repository;
        public HomeController(IExportFile _exportFile, IDataRepository _repository) 
        {

            export = _exportFile;
            repository = _repository;
        
        } 
        public IActionResult Index()
        {
            var data = DataModelDummy.DataDummy();
            var data2 = repository.GetAll();
            
            return View(data2);
        }

        [HttpGet("Export")]
        public IActionResult Export(string Or)
        {
            var data = DataModelDummy.DataDummy();
            var data2 = repository.GetAll();
            try
            {
                if (Or.Equals("Excel"))
                {
                    var bytes = export.DownloadExcel(data2);
                    return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "DownloadExcel.xlsx");

                }
                if(Or.Equals("Pdf"))
                {
                    return new ViewAsPdf("Index", data2)
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
