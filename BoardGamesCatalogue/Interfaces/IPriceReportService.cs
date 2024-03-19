using NPOI.SS.UserModel;

namespace BoardGamesCatalogue.Services;

public interface IPriceReportService
{
    IWorkbook FormPriceReport();
}