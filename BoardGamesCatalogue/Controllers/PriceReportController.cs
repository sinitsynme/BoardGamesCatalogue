using BoardGamesCatalogue.Services;
using Microsoft.AspNetCore.Mvc;
using NPOI.SS.UserModel;

namespace BoardGamesCatalogue.Controllers;

[Route("/rest/api/[controller]")]
[ApiController]
public class PriceReportController(IPriceReportService priceReportService) : Controller
{
    [HttpGet]
    public ActionResult Get()
    {
        IWorkbook workbook = priceReportService.FormPriceReport();

        using (var exportData = new MemoryStream())
        {
            workbook.Write(exportData);
            string saveAsFileName = string.Format("Настолки.ru-Прайс-{0:d}.xlsx", DateTime.Now).Replace("/", "-");
            byte[] bytes = exportData.ToArray();
            return File(bytes, "application/vnd.ms-excel", saveAsFileName);
        }
    }
}