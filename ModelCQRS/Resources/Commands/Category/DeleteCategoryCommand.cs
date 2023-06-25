using MediatR;
namespace ModelCQRS.Resources.Commands.Category
{
	public class DeleteProductCommand : IRequest<int>
	{
		public int Id { get; set; }
	}
}

