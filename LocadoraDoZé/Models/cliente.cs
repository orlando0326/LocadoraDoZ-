using LocadoraDoZe.Models;
using LocadoraDoZe.Models.LocadoraDoZe.Models;
using System.ComponentModel.DataAnnotations;


namespace LocadoraDoZe.Models
{
    public class cliente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; } = string.Empty;

        public string Telefone { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public ICollection<locacoes> Locacoes { get; set; } = new List<locacoes>();
    }
}