using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineFoodStore.ViewModel.CategoryModel
{
    public class CategoryTopicModel
    {
        public CategoryListingModel Category { get; set; }
        public IEnumerable<FoodListingModel> Foods { get; set; }
        public string SearchQuery { get; set; }
    }
}
