using ModelCQRS.DTO;
using ModelCQRS.Models;

namespace ModelCQRS.Interface
{
	public interface ICategoryRepository
	{
        Task<IEnumerable<Category>> Get();
        Boolean GetById(int ID);
        Task<CategoryDTO> PostCategory(Category todoDTO);
        Task<int> EditCategory(Category todoDTO);
        Task<int> Delete(int ID);
    }
}

