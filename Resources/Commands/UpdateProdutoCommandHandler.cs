using ApiCatalogo.Context;
using ApiCatalogo.Entities;
using MediatR;

namespace ApiCatalogo.Resources.Commands
{
    public class UpdateProdutoCommandHandler : IRequestHandler<UpdateProdutoCommand, Produto>
    {
        private readonly AppDbContext context;

        public UpdateProdutoCommandHandler(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Produto> Handle(UpdateProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = this.context.Produtos.FirstOrDefault(p=>p.Id == request.Id);

            if (produto is null)
                return default;

            produto.Nome = request.Nome;
            produto.Descricao = request.Descricao;
            produto.Categoria = request.Categoria;
            produto.Preco = request.Preco;

            await this.context.SaveChangesAsync();
            return produto;
        }
    }
}
