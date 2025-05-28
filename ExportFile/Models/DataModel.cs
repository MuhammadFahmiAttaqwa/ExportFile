namespace ExportFile.Models
{
    public class DataModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
    }

}
