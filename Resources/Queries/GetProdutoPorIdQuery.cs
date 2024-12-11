using ApiCatalogo.Entities;
using MediatR;

namespace ApiCatalogo.Resources.Queries
{
    public class GetProdutoPorIdQuery : IRequest<Produto>
    {
        public int Id { get; set; }
    }
}
