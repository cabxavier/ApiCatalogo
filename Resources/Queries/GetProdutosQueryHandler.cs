using ApiCatalogo.Context;
using ApiCatalogo.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Resources.Queries
{
    public class GetProdutosQueryHandler : IRequestHandler<GetProdutosQuery, IEnumerable<Produto>>
    {
        private readonly AppDbContext context;

        public GetProdutosQueryHandler(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Produto>> Handle(GetProdutosQuery request, CancellationToken cancellationToken) => await this.context.Produtos.ToListAsync();
    }
}
