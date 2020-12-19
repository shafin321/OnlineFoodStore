using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineFoodStore.ViewModel.FoodModel
{
    public class HomeIndexModel
    {
        public string SearchQuery { get; set; }
        public IEnumerable<FoodListingModel> PreferedFoods { get; set; }
    }
}
