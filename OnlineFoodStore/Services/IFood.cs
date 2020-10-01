using OnlineFoodStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineFoodStore.Services
{
 public   interface IFood
    {
        IEnumerable<Food> GetAll();
        IEnumerable<Food> GetFoodsByCategoryId(int categoryId);
        IEnumerable<Food> GetPreferred();
        Food GetById(int id);
    }
}
