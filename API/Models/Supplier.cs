using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nama Supplier Harus Diisi !")]
        [StringLength(25)]
        [MinLength(6, ErrorMessage = "Minimum panjang karakter adalah 6")]
        [MaxLength(25, ErrorMessage = "Maksimum panjang karakter adalah 25")]
        public string Name { get; set; }
    }
}