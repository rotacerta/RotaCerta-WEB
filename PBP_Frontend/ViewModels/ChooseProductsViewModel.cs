using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PBP_Frontend.ViewModels
{
    public class ChooseProductsViewModel
    {
        public List<ProductToChoose> ProductsToChoose { get; set; }
    }

    public class ProductToChoose
    {
        public int ProductId { get; set; }

        [Display(Name = "Produto", Prompt = "Produto", Order = 1)]
        public string ProductName { get; set; }

        [Display(Name = "Localização", Prompt = "Localização", Order = 2)]
        public string ProductLocation { get; set; }

        [Display(Name = "Escolhido", Prompt = "Escolhido", Order = 3)]
        public bool Chosen { get; set; }
    }
}