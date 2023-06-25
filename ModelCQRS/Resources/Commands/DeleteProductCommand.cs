using MediatR;
using ModelCQRS.DTO;


namespace ModelCQRS.Resources.Commands
{
	public class DeleteProductCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}

