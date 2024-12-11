using ApiCatalogo.Context;
using ApiCatalogo.Entities;
using MediatR;

namespace ApiCatalogo.Resources.Commands
{
    public class CreateProdutoCommandHandler : IRequestHandler<CreateProdutoCommand, Produto>
    {
        private readonly AppDbContext context;

        public CreateProdutoCommandHandler(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Produto> Handle(CreateProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = new Produto
            {
                Nome = request.Nome,
                Descricao = request.Descricao,
                Categoria = request.Categoria,
                Preco = request.Preco,
            };

            this.context.Produtos.Add(produto);
            await this.context.SaveChangesAsync();
            return produto;
        }
    }
}
