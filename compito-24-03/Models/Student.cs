using System.ComponentModel.DataAnnotations;

namespace compito_24_03.Models
{
    public class Student
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public required string Nome { get; set; }
        [Required]
        public required string Cognome { get; set; }
        [Required]
        public required string Email { get; set; }
    }
}
