using OnlineFoodStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineFoodStore.Services
{
 public   interface ICategory
    {
        IEnumerable<Category> GetAll();
        Category GetById(int id);
    }
}
