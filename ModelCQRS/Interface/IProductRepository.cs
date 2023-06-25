using ModelCQRS.DTO;
using ModelCQRS.Models;

namespace ModelCQRS.Interface
{
	public interface IProductRepository 
	{
        Task<IEnumerable<Product>> Get();
        Boolean GetById(int ID);
        Task<ProductDTO> PostProduct(Product todoDTO);
        Task<int> EditProduct(Product todoDTO);
        Task<int> Delete(int ID);
       
    }
}

