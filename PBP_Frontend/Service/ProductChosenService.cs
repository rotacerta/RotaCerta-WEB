using PBP_Frontend.Models;
using PBP_Frontend.ViewModels;
using System;
using System.Collections.Generic;

namespace PBP_Frontend.Service
{
    public class ProductChosenService
    {
        private ApplicationContext db;

        public ProductChosenService(ApplicationContext context)
        {
            db = context;
        }

        public List<string> InsertProductsChosen(int listId, List<ProductChosen> products)
        {
            List<string> errors = new List<string>();
            try
            {
                List<ProductList> productList = new List<ProductList>();
                foreach (ProductChosen productChosen in products)
                {
                    db.ProductLists.Add(new ProductList { ListId = listId, ProductId = productChosen.ProductId, RequiredQuantity = productChosen.RequiredQuantity, QuantityCatched = 0 });
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                errors.Add("Erro ao inserir produtos.");
            }
            return errors;
        }
    }
}