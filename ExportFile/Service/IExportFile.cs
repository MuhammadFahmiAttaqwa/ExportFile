using ExportFile.Models;

namespace ExportFile.Service
{
    public interface IExportFile
    {
        byte[] DownloadExcel(IList<DataModel> Data);


    }
}
