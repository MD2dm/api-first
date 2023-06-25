using System;
using Microsoft.EntityFrameworkCore;
using ModelCQRS.DTO;
using ModelCQRS.Infrastructure;
using ModelCQRS.Interface;
using ModelCQRS.Models;

namespace ModelCQRS.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private ShopContext _context;

        public CategoryRepository(ShopContext context)
        {
            _context = context;
        }
        public async Task<int> Delete(int ID)
        {
            var item = await _context.Categories.FirstOrDefaultAsync(x => x.Id == ID);
            if (item == null)
            {
                return 0;
            }
            _context.Categories.Remove(item);
            var i = await _context.SaveChangesAsync();

            return i;
        }

        public async Task<int> EditCategory(Category todoDTO)
        {
            var item = await _context.Categories.FindAsync(todoDTO.Id);
            if(item ==null)
            {
                return 0; 
            }
            item.Id = todoDTO.Id;
            item.NameCategory = todoDTO.NameCategory;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when ( !GetById(todoDTO.Id))
            {
                return 0;
            }
            return 1;
        }

        public async Task<IEnumerable<Category>> Get()
        {
            return await _context.Categories.ToListAsync();
        }

        public bool GetById(int ID)
        {
            return _context.Categories.Any(e => e.Id == ID);
        }

        public async Task<CategoryDTO> PostCategory(Category todoDTO)
        {
            var item = new Category
            {
                Id = todoDTO.Id,
                NameCategory = todoDTO.NameCategory
            };

            _context.Categories.Add(item);
            await _context.SaveChangesAsync();

            return new CategoryDTO()
            {
                Id = item.Id,
                NameCategory = item.NameCategory
            };
        }
    }
}

