using MediatR;
using ModelCQRS.DTO;

namespace ModelCQRS.Resources.Queries.Category
{
	public class GetAllCategoriesQuery: IRequest<IEnumerable<CategoryDTO>>
	{
		
	}
}

