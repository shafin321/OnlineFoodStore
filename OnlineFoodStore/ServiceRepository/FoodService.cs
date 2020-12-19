using Microsoft.EntityFrameworkCore;
using OnlineFoodStore.Data;
using OnlineFoodStore.Models;
using OnlineFoodStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineFoodStore.ServiceRepository
{
    public class FoodService : IFood
    {
        private readonly ApplicationDbContext _context;
        public FoodService(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Food> GetAll()
        {
            return _context.Foods.Include(food => food.Category);
        }

        public Food GetById(int id)
        {
          return  _context.Foods.Include(food => food.Category).FirstOrDefault(f => f.Id == id);
        }

        public IEnumerable<Food> GetFoodsByCategoryId(int categoryId)
        {
          return  _context.Foods.Where(f => f.Id == categoryId);
        }

        public IEnumerable<Food> GetPreferred()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Food> GetPreferred(int count)
        {
            return _context.Foods.Where(food => food.IsPreferedFood).Take(count);
        }
    }
}
