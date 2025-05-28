using ExportFile.Models;

namespace ExportFile.Repository
{
    public interface IDataRepository
    {
        List<DataModel> GetAll();
        
    }
}
