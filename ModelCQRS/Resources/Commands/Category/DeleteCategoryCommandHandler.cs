using MediatR;
using ModelCQRS.Interface;

namespace ModelCQRS.Resources.Commands.Category
{
	public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, int>
	{
        private readonly ICategoryRepository _categoryRepository;
        public DeleteProductCommandHandler(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}
		public async Task<int> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
		{
			var category = await _categoryRepository.Delete(request.Id);

			return category;
		}
	}
}

