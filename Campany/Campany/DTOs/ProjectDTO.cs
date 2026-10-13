using Campany.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Campany.DTOs
{
    public class ProjectDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(300)]
        public string? Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        [Range(1000, 10000000)]
        public decimal Budget { get; set; }
        public int DepartmentId { get; set; }
    }
    public class CreateProjectDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(300)]
        public string? Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        [Range(1000, 10000000)]
        public decimal Budget { get; set; }
        public int DepartmentId { get; set; }
    }
    public class UpdateProjectDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(300)]
        public string? Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        [Range(1000, 10000000)]
        public decimal Budget { get; set; }
        public int DepartmentId { get; set; }
    }
}
