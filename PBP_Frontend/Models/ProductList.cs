using System.ComponentModel.DataAnnotations;

namespace PBP_Frontend.Models
{
    public class ProductList
    {
        [Key]
        public int ProductListId { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Insira valores maiores que {1}.")]
        [Display(Name = "Quantidade Recolhida", Prompt = "Quantidade Recolhida", Order = 4)]
        public int QuantityCatched { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "Insira valores maiores que 0.")]
        [Display(Name = "Quantidade Requerida", Prompt = "Quantidade Requerida", Order = 3)]
        public int RequiredQuantity { get; set; }

        [Display(Name = "Lista", Prompt = "Lista", Order = 2)]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int ListId { get; set; }
        public virtual List List { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Produto", Prompt = "Produto", Order = 1)]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}