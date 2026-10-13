using Campany.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Campany.DTOs
{
    public class EmployeeProjectDTO
    {
        [Key]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        [MaxLength(50)]
        public string AssignedRole { get; set; } = string.Empty;
        public DateTime AssignedDate { get; set; }
    }
    public class CreateEmployeeProjectDTO
    {
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        [MaxLength(50)]
        public string AssignedRole { get; set; } = string.Empty;
        public DateTime AssignedDate { get; set; }
    }
}
