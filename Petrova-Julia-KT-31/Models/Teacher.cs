namespace Petrova_Julia_KT_31.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public int? AcademicDegreeId { get; set; }
        public AcademicDegree AcademicDegree { get; set; }

        public int? StaffId { get; set; }
        public Staff Staff { get; set; }

        public int? DepartmentId { get; set; }
        public Department Department { get; set; }

        public int? WorkloadId { get; set; }
        public Workload Workload { get; set; }

        public bool HasFullName()
        {
            return !string.IsNullOrWhiteSpace(FirstName)
                && !string.IsNullOrWhiteSpace(LastName)
                && !string.IsNullOrWhiteSpace(MiddleName);
        }

    }
}
