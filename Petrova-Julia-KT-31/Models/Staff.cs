namespace Petrova_Julia_KT_31.Models
{
    public class Staff
    {
        public int StaffId { get; set; }
        public string Name { get; set; } 
        public List<Teacher> Teachers { get; set; } = new List<Teacher>();
    }

}
