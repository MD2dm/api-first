using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelCQRS.Infrastructure;

namespace ModelCQRS.Resources.Queries.Categorys
{
	public class GetProductByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Models.Category>
	{
		private readonly ShopContext _context;
		public GetProductByIdQueryHandler(ShopContext context)
		{
			_context = context;
		}
		public async Task<Models.Category> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
		{
			return await _context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
		}
	}
}

