using MediatR;
using ModelCQRS.DTO;

namespace ModelCQRS.Resources.Commands.Category
{
    public class CreateCategoryCommand : IRequest<CategoryDTO>
	{
        public int Id { get; set; }
		public string CategoryName { get; set; }
	}
}

