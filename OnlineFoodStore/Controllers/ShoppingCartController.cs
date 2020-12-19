using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineFoodStore.Data;
using OnlineFoodStore.Models;
using OnlineFoodStore.Services;
using OnlineFoodStore.ViewModel;
using OnlineFoodStore.ViewModel.CategoryModel;

namespace OnlineFoodStore.Controllers
{
    public class ShoppingCartController : Controller
    {

        private readonly ShoppingCart _cart;
        private readonly IFood _food;
        public ShoppingCartController(ShoppingCart cart, IFood food)
        {
            _cart = cart;
            _food = food;
            
        }

        public IActionResult Index()
        {
            _cart.GetShoppingCartItems();
            var viewmodel = new ShoppingCartViewModel
            {
                ShoppingCart = _cart,
                ShoppingCartTotal=_cart.GetShoppingCartTotal()
            };
            return View(viewmodel);
        }

        public IActionResult AddToCart(int id)
        {
            var food = _food.GetById(id);
            if(food != null)
            {
                _cart.AddToCart(food, 1);
            }

            return RedirectToAction("Index");
        }
    }
}
