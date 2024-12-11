using ApiCatalogo.Context;
using ApiCatalogo.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Resources.Queries
{
    public class GetProdutoPorIdQueryHandler : IRequestHandler<GetProdutoPorIdQuery, Produto>
    {
        private readonly AppDbContext context;

        public GetProdutoPorIdQueryHandler(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Produto> Handle(GetProdutoPorIdQuery request, CancellationToken cancellationToken)
        {
            var produto = await this.context.Produtos.FirstOrDefaultAsync(x => x.Id == request.Id,cancellationToken);

            return produto;
        }
    }
}
