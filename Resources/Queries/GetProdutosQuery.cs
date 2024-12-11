using ApiCatalogo.Entities;
using MediatR;

namespace ApiCatalogo.Resources.Queries
{
    public class GetProdutosQuery : IRequest<IEnumerable<Produto>>
    {
    }
}
