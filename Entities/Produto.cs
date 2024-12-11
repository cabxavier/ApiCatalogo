using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiCatalogo.Entities
{
    public class Produto
    {
        public int Id { get; set; }

        [StringLength(80, MinimumLength = 4)]
        public string? Nome { get; set; }

        [StringLength(80, MinimumLength = 4)]
        public string? Descricao { get; set; }

        [StringLength(80, MinimumLength = 4)]
        public string? Categoria { get; set; }

        public bool Ativo { get; set; } = true;

        [Column(TypeName = "decimal(10,2)")]
        public decimal Preco { get; set; }
    }
}
