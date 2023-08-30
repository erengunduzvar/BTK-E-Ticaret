using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;
using StoreApp.Infrastructure.Extensions;

namespace StoreApp.Pages
{
    public class CartModel : PageModel
    {
        private readonly IServiceManager manager;
        public Cart Cart { get; set; } //IoC
        public string ReturnUrl { get; set; } = "/";

        public CartModel(IServiceManager _manager)
        {
            manager = _manager;
        }


        public void OnGet(string _ReturnUrl)
        {
            ReturnUrl = _ReturnUrl ?? "/";
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(int productId, string returnUrl)
        {
            Product? product = manager.
                ProductService.
                GetProductById(productId, false);

            if (product is not null)
            {
                Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(product, 1);
                HttpContext.Session.SetJson<Cart>("cart",Cart);
            }
            return Page(); //return URl gelecek
        }

        public IActionResult OnPostRemove(int id,string returnUrl)
        {
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            Cart.RemoveLine(Cart.Lines.First(cl => cl.Product.ProductId == id).Product);
            HttpContext.Session.SetJson<Cart>("cart", Cart);
            return Page(); //return url
        }
    }
}
