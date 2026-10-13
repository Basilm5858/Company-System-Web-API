using System.ComponentModel.DataAnnotations;

namespace Campany.Models
{
    public class ApplicationUser
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        [MinLength(20)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string Password { get; set; } = string.Empty;
        [Required]
        public string Role {  get; set; } = string.Empty;
    }
}

