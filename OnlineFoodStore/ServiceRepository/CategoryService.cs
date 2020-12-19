using OnlineFoodStore.Data;
using OnlineFoodStore.Models;
using OnlineFoodStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineFoodStore.ServiceRepository
{
    public class CategoryService : ICategory
    { 
        private readonly ApplicationDbContext _context;
        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Category> GetAll()
        {
           return  _context.Categories;
        }

        public Category GetById(int id)
        {
            return _context.Categories.FirstOrDefault(c => c.Id == id);
        }
    }
}
