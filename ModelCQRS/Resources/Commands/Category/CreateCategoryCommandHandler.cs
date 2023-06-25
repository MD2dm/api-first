using MediatR;
using ModelCQRS.DTO;
using ModelCQRS.Interface;
using ModelCQRS.Repository;

namespace ModelCQRS.Resources.Commands.Category
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryDTO>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<CategoryDTO> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Models.Category
            {
                Id = request.Id,
                NameCategory = request.CategoryName
            };
            var item = await _categoryRepository.PostCategory(category);
            return item;
        }
    }
}

