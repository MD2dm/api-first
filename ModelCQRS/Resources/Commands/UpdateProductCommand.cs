using MediatR;
using ModelCQRS.DTO;
using ModelCQRS.Models;

namespace ModelCQRS.Resources.Commands
{
	public class UpdateProductCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public byte? Image { get; set; }
        public string Des { get; set; }
        public int Category { get; set; }
    }
}

