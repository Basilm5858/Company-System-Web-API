using Campany.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Campany.DTOs
{
    public class EmployeeDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string FullName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [Range(3000, 100000)]
        public decimal Salary { get; set; }
        [Required]
        public DateTime HireDate { get; set; }
        public int DepartmentId { get; set; }
    }
    public class CreateEmployeeDTO
    {
        [Required]
        [MaxLength(150)]
        public string FullName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [Range(3000, 100000)]
        public decimal Salary { get; set; }
        [Required]
        public DateTime HireDate { get; set; }
        public int DepartmentId { get; set; }
    }

    public class UpdateEmployeeDTO
    {
        [Required]
        [MaxLength(150)]
        public string FullName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [Range(3000, 100000)]
        public decimal Salary { get; set; }
        [Required]
        public DateTime HireDate { get; set; }
        public int DepartmentId { get; set; }
    }

}
