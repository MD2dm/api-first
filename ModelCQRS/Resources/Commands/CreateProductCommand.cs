using MediatR;
using ModelCQRS.DTO;

namespace ModelCQRS.Resources.Commands
{
	public class CreateProductCommand : IRequest<ProductDTO>
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public byte? Image { get; set; }
        public string Des { get; set; }
        public int CategoryId { get; set; }
    }
}

