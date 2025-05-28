using ExportFile.Models;

namespace ExportFile.DataDummy
{
    public static class DataModelDummy
    {
        public static List<DataModel> DataDummy()
        {
            var dataDummy = new List<DataModel>
            {
                new DataModel { Id = 1, FullName = "Andi Saputra", Email = "andi@mail.com", BirthDate = new DateTime(1990, 1, 15), Address = "Jakarta", Phone = "081234567890", Gender = "Male", Position = "Developer", Salary = 8000000, IsActive = true },
                new DataModel { Id = 2, FullName = "Budi Santoso", Email = "budi@mail.com", BirthDate = new DateTime(1988, 5, 21), Address = "Bandung", Phone = "081234567891", Gender = "Male", Position = "Manager", Salary = 15000000, IsActive = true },
                new DataModel { Id = 3, FullName = "Citra Dewi", Email = "citra@mail.com", BirthDate = new DateTime(1995, 3, 10), Address = "Surabaya", Phone = "081234567892", Gender = "Female", Position = "QA Engineer", Salary = 7000000, IsActive = true },
                new DataModel { Id = 4, FullName = "Deni Firmansyah", Email = "deni@mail.com", BirthDate = new DateTime(1992, 7, 4), Address = "Yogyakarta", Phone = "081234567893", Gender = "Male", Position = "Support", Salary = 6000000, IsActive = false },
                new DataModel { Id = 5, FullName = "Eka Wulandari", Email = "eka@mail.com", BirthDate = new DateTime(1993, 8, 30), Address = "Semarang", Phone = "081234567894", Gender = "Female", Position = "UI Designer", Salary = 7500000, IsActive = true },
                new DataModel { Id = 6, FullName = "Fajar Hidayat", Email = "fajar@mail.com", BirthDate = new DateTime(1989, 12, 5), Address = "Bekasi", Phone = "081234567895", Gender = "Male", Position = "SysAdmin", Salary = 9000000, IsActive = false },
                new DataModel { Id = 7, FullName = "Gita Putri", Email = "gita@mail.com", BirthDate = new DateTime(1991, 11, 2), Address = "Depok", Phone = "081234567896", Gender = "Female", Position = "Product Owner", Salary = 16000000, IsActive = true },
                new DataModel { Id = 8, FullName = "Hendra Wijaya", Email = "hendra@mail.com", BirthDate = new DateTime(1987, 6, 18), Address = "Tangerang", Phone = "081234567897", Gender = "Male", Position = "Tech Lead", Salary = 18000000, IsActive = true },
                new DataModel { Id = 9, FullName = "Intan Lestari", Email = "intan@mail.com", BirthDate = new DateTime(1994, 2, 14), Address = "Medan", Phone = "081234567898", Gender = "Female", Position = "Scrum Master", Salary = 14000000, IsActive = true },
                new DataModel { Id = 10, FullName = "Joko Suprianto", Email = "joko@mail.com", BirthDate = new DateTime(1986, 9, 25), Address = "Bogor", Phone = "081234567899", Gender = "Male", Position = "Analyst", Salary = 9500000, IsActive = false },
            }.ToList();
            

            return dataDummy;
        }
    }
}
