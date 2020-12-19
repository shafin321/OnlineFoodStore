using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnlineFoodStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineFoodStore.Models
{
    public class ShoppingCart
    {
        private readonly ApplicationDbContext _context;

        public ShoppingCart(ApplicationDbContext context)
        {
            _context = context;

        }

        public string CartId { get; set; }
        public IEnumerable<ShoppingCartItem> ShoppingCartItems { get; set; }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<ApplicationDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);
            return new ShoppingCart(context) { CartId = cartId };
        }

        public void AddToCart(Food food, int amount)
        {
            var cartItem = _context.ShoppingCartItems.FirstOrDefault(c => c.Food.Id == food.Id && c.ShoppingCartId == CartId);

            if (cartItem == null)
            {
                cartItem = new ShoppingCartItem
                {
                    Food=food,
                    Amount=1,
                    ShoppingCartId=CartId,

                };
                _context.ShoppingCartItems.Add(cartItem);
            }

            else
            {
                //cartItem.Amount = cartItem.Amount + 1;
                cartItem.Amount++;
            }
            _context.SaveChanges();
        }

        public void RemoveItem(Food food)
        {
            var item = _context.ShoppingCartItems.FirstOrDefault(c => c.Food.Id == food.Id && c.ShoppingCartId == CartId);

            var localAmount = 0;

            if (item != null)
            {

                if (item.Amount > 0)
                {
                    item.Amount--;
                    localAmount = item.Amount;
                }



                else
                {
                    _context.ShoppingCartItems.Remove(item);
                }
            }
            _context.SaveChanges();
        }

        public IEnumerable<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??(ShoppingCartItems = _context.ShoppingCartItems.Where(c => c.ShoppingCartId == CartId).Include(c=>c.Food));
                
        }

        public void ClearCart()
        {
          var items=  _context.ShoppingCartItems.Where(c => c.ShoppingCartId == CartId);
            _context.ShoppingCartItems.RemoveRange(items);
            _context.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total= _context.ShoppingCartItems.Where(c => c.ShoppingCartId == CartId).
                    Select(c => c.Food.Price * c.Amount).Sum();
            return total;
        }
    }
}
