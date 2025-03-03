namespace Petrova_Julia_KT_31.Models
{
    public class Workload
    {
        public int WorkloadId { get; set; }
        public int DisciplineId { get; set; }
        public Discipline Discipline { get; set; }

        public int Hours { get; set; }
    }

}
