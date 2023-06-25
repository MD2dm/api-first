using MediatR;
using ModelCQRS.DTO;
using ModelCQRS.Models;


namespace ProductCatalog.Resources.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<ProductDTO>>
    {
    }
}
