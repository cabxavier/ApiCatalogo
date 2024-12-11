using ApiCatalogo.Entities;
using MediatR;

namespace ApiCatalogo.Resources.Commands
{
    public abstract class ProdutoCommand : IRequest<Produto>
    {
        public string? Nome { get; set; }

        public string? Descricao { get; set; }

        public string? Categoria { get; set; }

        public bool Ativo { get; set; } = true;

        public decimal Preco { get; set; }
    }
}
