using MediatR;
using ModelCQRS.DTO;
using ModelCQRS.Interface;

namespace ModelCQRS.Resources.Queries.Category
{
	public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<CategoryDTO>>
	{
		private readonly ICategoryRepository _categoryRepository;
		public GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}

		public async Task<IEnumerable<CategoryDTO>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
		{
			var item = await _categoryRepository.Get();
			var result = item.Select(x => new CategoryDTO()
			{
				Id = x.Id,
                NameCategory = x.NameCategory
            });
			return result;
		}
    }
}

