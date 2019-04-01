using System.Collections.Generic;

namespace PBP_Frontend.ViewModels
{
    public class ListViewModel
    {
        public string ListName { get; set; }
        public string ListRequester { get; set; }
        public List<ProductChosen> ProductsChosen { get; set; }
    }

    public class ProductChosen
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int RequiredQuantity { get; set; }
    }
}