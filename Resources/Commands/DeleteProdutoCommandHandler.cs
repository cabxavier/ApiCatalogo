using ApiCatalogo.Context;
using ApiCatalogo.Entities;
using MediatR;

namespace ApiCatalogo.Resources.Commands
{
    public class DeleteProdutoCommandHandler : IRequestHandler<DeleteProdutoCommand, Produto>    
    {
        private readonly AppDbContext context;

        public DeleteProdutoCommandHandler(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Produto> Handle(DeleteProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = this.context.Produtos.FirstOrDefault(p=>p.Id == request.Id);

            if (produto is null)
                return default;

            this.context.Produtos.Remove(produto);
            await this.context.SaveChangesAsync();
            return produto;
        }
    }
}
