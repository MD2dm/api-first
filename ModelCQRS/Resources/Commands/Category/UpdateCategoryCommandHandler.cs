using MediatR;
using ModelCQRS.Interface;

namespace ModelCQRS.Resources.Commands.Category
{
	public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand,int>
	{
        private readonly ICategoryRepository _categoryRepository;
        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
		{
            _categoryRepository = categoryRepository;
        }
        public async Task<int> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var item = new Models.Category
            {
                Id = request.Id,
                NameCategory = request.NameCategory
            };
            var category = await _categoryRepository.EditCategory(item);

            if (category == 0)
                return default;

            return category;
        }
	}
}

