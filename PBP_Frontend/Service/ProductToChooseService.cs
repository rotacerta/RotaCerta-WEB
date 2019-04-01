using PBP_Frontend.Models;
using System.Data.Entity;
using PBP_Frontend.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace PBP_Frontend.Service
{
    public class ProductToChooseService
    {
        private readonly ApplicationContext db = new ApplicationContext();

        public ProductToChooseService(ApplicationContext context)
        {
            db = context;
        }

        public List<ProductToChoose> GetProductsToChoose()
        {
            List<ProductToChoose> productsToChoose = new List<ProductToChoose>();
            List<Product> products = db.Products.Include(p => p.Location).ToList();
            foreach(Product product in products)
            {
                productsToChoose.Add(new ProductToChoose
                {
                    ProductId = product.ProductId,
                    ProductName = product.Name,
                    ProductLocation = product.Location.ToString(),
                    Chosen = false
                });
            }
            return productsToChoose;
        }
    }
}