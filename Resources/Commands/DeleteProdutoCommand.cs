using ApiCatalogo.Entities;
using MediatR;

namespace ApiCatalogo.Resources.Commands
{
    public class DeleteProdutoCommand : IRequest<Produto>
    {
        public int Id { get; set; }
    }
}
