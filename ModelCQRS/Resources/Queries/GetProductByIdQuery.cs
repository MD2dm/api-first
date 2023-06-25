using MediatR;
using ModelCQRS.Models;

namespace ModelCQRS.Resources.Queries
{
	public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }
    }
}

