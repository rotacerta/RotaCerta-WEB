using System.Collections.Generic;
using System.ComponentModel;

namespace PBP_Frontend.ViewModels
{
    public class ChooseProductsViewModel
    {
        public List<ProductToChoose> ProductsToChoose { get; set; }
    }

    public class ProductToChoose
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductLocation { get; set; }
        public bool Chosen { get; set; }
    }
}