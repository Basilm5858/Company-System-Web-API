using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Campany.Models
{
    public class EmployeeProject
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        public Employee Employee { get; set; }
        public Project Project { get; set; }
        [MaxLength(50)]
        public string AssignedRole { get; set; } = string.Empty;
        public DateTime AssignedDate { get; set; }
    }
}