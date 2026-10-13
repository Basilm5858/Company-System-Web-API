using System.ComponentModel.DataAnnotations;

namespace Campany.DTOs
{
    public class DepartmentDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string Location { get; set; } = string.Empty;
    }
    public class CreateDepartmentDTO
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string Location { get; set; } = string.Empty;
    }
    public class UpdateDepartmentDTO
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string Location { get; set; } = string.Empty;
    }
}
