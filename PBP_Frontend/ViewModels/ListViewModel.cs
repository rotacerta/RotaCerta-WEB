using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PBP_Frontend.ViewModels
{
    public class ListViewModel
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(50, ErrorMessage = "Máximo de {1} caracteres no campo {0}.")]
        public string ListName { get; set; }

        [Display(Name = "Solicitante")]
        [Required(ErrorMessage = "O campo Solicitante é obrigatório.")]
        [StringLength(50, ErrorMessage = "Máximo de {1} caracteres no campo {0}.")]
        public string ListRequester { get; set; }
        public List<ProductChosen> ProductsChosen { get; set; }
    }

    public class ProductChosen
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        [Display(Name = "Quantidade")]
        [Range(1, 300, ErrorMessage = "Insira valores entre {1} e {2}.")]
        public int RequiredQuantity { get; set; }
    }
}