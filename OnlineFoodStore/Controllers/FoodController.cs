using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineFoodStore.Models;
using OnlineFoodStore.Services;
using OnlineFoodStore.ViewModel;
using OnlineFoodStore.ViewModel.FoodModel;

namespace OnlineFoodStore.Controllers
{
    public class FoodController : Controller
    {
        private readonly ICategory _category;
        private readonly IFood _food;
     
        public FoodController(ICategory category, IFood food)
        {
            _category = category;
            _food = food;
        }
        // GET: FoodController
        public ActionResult Index()
        {
            var food = _food.GetAll();         
        
            return View(food);
        }

        // GET: FoodController/Details/5
        public ActionResult Details(int id)
        {
            var model = _food.GetById(id);
            return View(model);
        }

        // GET: FoodController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FoodController/Create
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

        // GET: FoodController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FoodController/Edit/5
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

        // GET: FoodController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FoodController/Delete/5
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
