using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;

namespace StoreApp.Pages
{
    public class CartModel : PageModel
    {
        private readonly IServiceManager manager;
        public Cart Cart { get; set; } //IoC
        public string ReturnUrl { get; set; } = "/";

        public CartModel(IServiceManager _manager, Cart _cart)
        {
            manager = _manager;
            Cart = _cart;
        }


        public void OnGet(string _ReturnUrl)
        {
            ReturnUrl = _ReturnUrl ?? "/";
        }

        public IActionResult OnPost(int productId, string returnUrl)
        {
            Product? product = manager.
                ProductService.
                GetProductById(productId, false);

            if (product is not null)
            {
                Cart.AddItem(product, 1);
            }
            return Page(); //return URl gelecek
        }

        public IActionResult OnPostRemove(int id,string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl => cl.Product.ProductId == id).Product);
            return Page(); //return url
        }
    }
}
