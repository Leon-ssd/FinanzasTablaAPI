using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finanzas.Models
{
    [Table("monedas")]
    public class Moneda
    {
        [Key]
        [Column("id")]
        [MaxLength(10)]
        public string Id { get; set; } = string.Empty; // Ej: "BOB", "USD", "EUR"

        [Required]
        [Column("nombre")]
        [MaxLength(50)]
        public string Nombre { get; set; } = string.Empty; // Ej: "Boliviano"

        [Required]
        [Column("simbolo")]
        [MaxLength(10)]
        public string Simbolo { get; set; } = string.Empty; // Ej: "Bs"
    }
}