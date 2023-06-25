using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelCQRS.Infrastructure;
using ModelCQRS.Models;

namespace ModelCQRS.Resources.Queries
{
	public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly ShopContext _context;
        public GetProductByIdQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<Product> Handle(GetProductByIdQuery request,  CancellationToken cancellationToken)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        }
    }
}

