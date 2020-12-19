using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineFoodStore.Models;
using OnlineFoodStore.Services;
using OnlineFoodStore.ViewModel;
using OnlineFoodStore.ViewModel.CategoryModel;
using OnlineFoodStore.ViewModel.FoodModel;

namespace OnlineFoodStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFood _foodService;

        public HomeController(IFood foodService)
        {
            _foodService = foodService;
        }

        public IActionResult Index()
        {
            
            var model = BuildIndexModel();
            return View(model);
        }

        private HomeIndexModel BuildIndexModel()
        {
     
            var preferedFoods = _foodService.GetPreferred(2);
            var foods = preferedFoods.Select(food => new FoodListingModel
            {
                Id = food.Id,
                Name = food.Name,
                //Category = BuildCategoryListing(food.Category),
                ImageUrl = food.ImageUrl,
                InStock = food.InStock,
                Price = food.Price,
                ShortDescription = food.ShortDescription
            });

            return new HomeIndexModel
            {
                PreferedFoods = foods
            };
        }

            private CategoryListingModel BuildCategoryListing(Category category)
            {
                return new CategoryListingModel
                {
                    Id = category.Id,
                    Description = category.Description,
                    Name = category.Name,
                    ImageUrl = category.ImageUrl
                };
            }
        }
    }
    