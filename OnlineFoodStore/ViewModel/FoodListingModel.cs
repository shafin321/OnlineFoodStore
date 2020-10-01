using OnlineFoodStore.ViewModel.CategoryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineFoodStore.ViewModel
{
    public class FoodListingModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
        public string ShortDescription { get; set; }
        public CategoryListingModel Category { get; set; }
    }
}
