using Microsoft.AspNetCore.Mvc;
using Repositories;
using Services.Contracts;

namespace StoreApp.Components
{
    public class ProductSummaryViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly IServiceManager manager;

        public ProductSummaryViewComponent(IServiceManager manager)
        {
            this.manager = manager;
        }

        public string Invoke()
        {
            return manager.ProductService.GetAllProducts(false).Count().ToString();
        }
    }
}
