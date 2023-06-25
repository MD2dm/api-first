using Microsoft.EntityFrameworkCore;
using ModelCQRS.DTO;
using ModelCQRS.Infrastructure;
using ModelCQRS.Interface;
using ModelCQRS.Models;

namespace ModelCQRS.Repository
{
    public class ProductRepository : IProductRepository
    {

        private ShopContext _context;

        public ProductRepository(ShopContext context)
        {
            _context = context;

        }
        public async Task<int> Delete(int ID)
        {
            var item = await _context.Products.FirstOrDefaultAsync(x => x.Id == ID);
            if (item == null)
            {
                return 0;
            }

            _context.Products.Remove(item);
            var i = await _context.SaveChangesAsync();

            return i;
        }

        public async Task<int> EditProduct(Product todoDTO)
        {
            var item = await _context.Products.FindAsync(todoDTO.Id);
            if (item == null)
            {
                return 0;
            }
            item.Id = todoDTO.Id;
            item.ProductName = todoDTO.ProductName;
            item.Price = todoDTO.Price;
            item.Image = todoDTO.Image;
            item.Des = todoDTO.Des;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!GetById(todoDTO.Id))
            {
                return 0;
            }

            return 1;
        }

        public async Task<IEnumerable<Product>> Get()
        {
            return await _context.Products.ToListAsync();
        }

        public bool GetById(int ID)
        {
            return _context.Products.Any(e => e.Id == ID);
        }

        public async Task<ProductDTO> PostProduct(Product todoDTO)
        {
            var item = new Product
            {
                Id = todoDTO.Id,
                ProductName = todoDTO.ProductName,
                Price = todoDTO.Price,
                Image = todoDTO.Image,
                Des = todoDTO.Des,
                CategoryId = todoDTO.CategoryId
            };

            _context.Products.Add(item);
            await _context.SaveChangesAsync();

            return new ProductDTO()
            {
                Id = item.Id,
                ProductName = item.ProductName,
                Price = item.Price,
                Image = item.Image,
                Des = item.Des,
                CategoryId = item.CategoryId
            };
        }
    }
}

