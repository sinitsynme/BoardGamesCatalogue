using BoardGamesCatalogue.Interfaces;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace BoardGamesCatalogue.Services;

public class PriceReportService(IBoardGameRepository _boardGameRepository) : IPriceReportService
{
    public IWorkbook FormPriceReport()
    {
        var boardGames = _boardGameRepository.GetBoardGames().Result;
        boardGames.Sort((x, y)=> x.Creator.Name.CompareTo(y.Creator.Name));

        IWorkbook workbook = new XSSFWorkbook();
        ISheet sheet = workbook.CreateSheet("Sheet1");
        sheet.CreateRow(0);

        int currRow = 0;

        var font = workbook.CreateFont();
        font.IsBold = true;
        
        sheet.SetColumnWidth(0, 40*256);
        sheet.SetColumnWidth(1, 40*256);
        sheet.SetColumnWidth(2, 40*256);
        
        IRow header = sheet.GetRow(currRow++);
        header.CreateCell(0).SetCellValue("Производитель");
        header.GetCell(0).RichStringCellValue.ApplyFont(font);
        header.CreateCell(1).SetCellValue("Название");
        header.GetCell(1).RichStringCellValue.ApplyFont(font);
        header.CreateCell(2).SetCellValue("Стоимость");
        header.GetCell(2).RichStringCellValue.ApplyFont(font);

        foreach (var boardGame in boardGames)
        {
            IRow row = sheet.CreateRow(currRow++);
            row.CreateCell(0).SetCellValue(boardGame.Creator.Name);
            row.CreateCell(1).SetCellValue(boardGame.Name);
            row.CreateCell(2).SetCellValue(boardGame.Price.ToString());
        }
        
        return workbook;
    }
}