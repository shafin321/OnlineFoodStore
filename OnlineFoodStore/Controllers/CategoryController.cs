using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineFoodStore.Models;
using OnlineFoodStore.Services;
using OnlineFoodStore.ViewModel;
using OnlineFoodStore.ViewModel.CategoryModel;

namespace OnlineFoodStore.Controllers
{
    public class CategoryController : Controller
    {
        private ICategory _categoryService;
        private IFood _foodService;
        public CategoryController(ICategory category, IFood food)
        {
            _categoryService = category;
            _foodService = food;
        }
        // GET: CategoryController
        public IActionResult Index()
        {
            IEnumerable<CategoryListingModel> categories = _categoryService.GetAll().
                 Select(category => new CategoryListingModel
                 {
                     Name = category.Name,
                     Description = category.Description,
                     Id = category.Id,
                     ImageUrl = category.ImageUrl
                 });


            var model = new CategoryIndexModel
            {
                CategoryList = categories
            };

            //var model = new CategoryIndexModel
            //{
            //    CategoryList = categories
            //};

            return View(model);
        }

        // GET: CategoryController/Details/5
        public ActionResult Topic(int id)
        {
            var category = _categoryService.GetById(id);
            var foods = _foodService.GetFoodsByCategoryId(id);

            var foodListings = foods.Select(food => new FoodListingModel
            {
                Id = food.Id,
                Name = food.Name,
                InStock = food.InStock,
                Price = food.Price,
                ShortDescription = food.ShortDescription,
                Category = BuildCategoryListing(food)


            }) ;

            var model = new CategoryTopicModel
            {
                Category = BuildCategoryListing(category),
                Foods = foodListings

            };

            return View(model);
        }

        private CategoryListingModel BuildCategoryListing(Food food)
        {
            var category = food.Category;
            return BuildCategoryListing(category);
        }

        private CategoryListingModel BuildCategoryListing(Category category)
        {
            return new CategoryListingModel
            {
                
              Name=category.Name,
              Description=category.Description,
              Id=category.Id,
              ImageUrl = category.ImageUrl

            };
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
