using MediatR;
using ModelCQRS.DTO;
using ModelCQRS.Interface;
using ProductCatalog.Resources.Queries;

namespace ModelCQRS.Resources.Queries
{
	public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDTO>>
	{
        private readonly IProductRepository _productRepository;
        public GetAllProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDTO>> Handle(GetAllProductsQuery request,  CancellationToken cancellationToken)
        {
            var item = await _productRepository.Get();
            var result = item.Select(x => new ProductDTO()
            {
                Id = x.Id,
                ProductName = x.ProductName,
                Price = x.Price,
                Image = x.Image,
                Des = x.Des,
                CategoryId = x.CategoryId
              
            }); ;
            return result;
        }
            

    }
}

