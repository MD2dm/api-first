using MediatR;
using ModelCQRS.DTO;
using ModelCQRS.Interface;
using ModelCQRS.Models;

namespace ModelCQRS.Resources.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDTO>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDTO> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Id = request.Id,
                ProductName = request.ProductName,
                Price = request.Price,
                Image = request.Image,
                Des = request.Des,
                CategoryId = request.CategoryId
            };
            var item = await _productRepository.PostProduct(product);
            return item;

        }
    }
}

