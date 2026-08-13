using LocadoraDoZe.Models;
using LocadoraDoZe.Models.LocadoraDoZe.Models;
using System.ComponentModel.DataAnnotations;

namespace LocadoraDoZe.Models
{
    public class Patinetes
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Marca { get; set; } = string.Empty;

        [Required]
        public string Modelo { get; set; } = string.Empty;

        public int Ano { get; set; }

        public ICollection<locacoes> Locacoes { get; set; } = new List<locacoes>();
    }
}