using LocadoraDoZe.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocadoraDoZe.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    namespace LocadoraDoZe.Models
    {
        public class locacoes
        {
            [Key]
            public int Id { get; set; }

            public DateTime Data_Retirada { get; set; }

            public DateTime? Data_Devolucao { get; set; }

            public decimal Forma_Pagamento { get; set; }

            public int ClienteId { get; set; }

            [ForeignKey("ClienteId")]
            public cliente? Cliente { get; set; }

            public int PatineteId { get; set; }

            [ForeignKey("PatineteId")]
            public Patinetes? Patinete { get; set; }
        }
    }
}