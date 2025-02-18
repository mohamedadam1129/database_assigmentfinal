using System.ComponentModel.DataAnnotations;

namespace database_assigmentfinal
{
    public class Project
    {
        [Key]
        public int ProjectNumber { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ProjectManager { get; set; } = string.Empty;
        public string Customer { get; set; } = string.Empty;
        public decimal HourlyRate { get; set; }
        public decimal TotalPrice { get; set; }
        public ProjectStatus Status { get; set; }
    }

    public enum ProjectStatus
    {
        NotStarted,
        Ongoing,
        Completed
    }
}
