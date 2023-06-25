using MediatR;
namespace ModelCQRS.Resources.Commands.Category
{
	public class UpdateCategoryCommand : IRequest<int>
	{
		public int Id { get; set; }
		public string NameCategory { get; set; }
	}
}

