using ExportFile.Models;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace ExportFile.Service.Impl
{
    public class ExportFileImpl : IExportFile
    {
        public byte[] DownloadExcel(IList<DataModel> Data)
        {
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("DownloadExcel");

            ICellStyle headerStyle = workbook.CreateCellStyle();

            headerStyle.FillForegroundColor = IndexedColors.Blue.Index;

            headerStyle.FillPattern = FillPattern.SolidForeground;

            IFont font = workbook.CreateFont();
            font.Boldweight = (short)FontBoldWeight.Bold;
            font.Color = IndexedColors.White.Index;
            headerStyle.SetFont(font);

            IRow header = sheet.CreateRow(1);

            string[] headerTitles = new string[] { "Full Name", "Email", "BirthDate", "Address", "Phone", "Gender", "Position", "Salary" };

            for (int i = 0; i < headerTitles.Length; i++)
            {
                var cell = header.CreateCell(i);
                cell.SetCellValue(headerTitles[i]);
                cell.CellStyle = headerStyle;  
            }

            int rowIndex = 2;
            foreach (var item in Data)
            {
                IRow value = sheet.CreateRow(rowIndex++);
                value.CreateCell(0).SetCellValue(item.FullName);
                value.CreateCell(1).SetCellValue(item.Email);
                value.CreateCell(2).SetCellValue(item.BirthDate.ToString("dd - MMMM - yyyy"));
                value.CreateCell(3).SetCellValue(item.Address);
                value.CreateCell(4).SetCellValue(item.Phone);
                value.CreateCell(5).SetCellValue(item.Gender);
                value.CreateCell(6).SetCellValue(item.Position);
                value.CreateCell(7).SetCellValue(item.Salary.ToString());
            }
            for (int i = 0; i < Data.Count; i++)
            {
                sheet.AutoSizeColumn(i);
            }
            using var stream = new MemoryStream();
            workbook.Write(stream);
            return stream.ToArray();
        }
    }
}
