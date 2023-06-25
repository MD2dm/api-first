using MediatR;
using ModelCQRS.Interface;
using ModelCQRS.Models;

namespace ModelCQRS.Resources.Commands
{
	public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {

            var item = new Product()
            {
                Id = request.Id,
                ProductName = request.ProductName,
                Price = request.Price,
                Image = request.Image,
                Des = request.Des
            };

            var product =  await _productRepository.EditProduct(item);

            if (product == 0)
                return default;
         
            return product;
        }
    }
}

