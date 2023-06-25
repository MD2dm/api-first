using MediatR;
using ModelCQRS.DTO;
using ModelCQRS.Infrastructure;
using ModelCQRS.Interface;
using ModelCQRS.Models;

namespace ModelCQRS.Resources.Commands
{
	public class DeleteProductCommandHandler: IRequestHandler<DeleteProductCommand, int>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.Delete(request.Id);

            return product;
        }

        
    }
}

