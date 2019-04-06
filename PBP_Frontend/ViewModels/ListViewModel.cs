using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PBP_Frontend.ViewModels
{
    public class ListViewModel
    {
        [Display(Name = "Nome", Prompt = "Nome", Order = -4)]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(50, ErrorMessage = "Máximo de {1} caracteres no campo {0}.")]
        public string ListName { get; set; }

        [Display(Name = "Solicitante", Prompt = "Solicitante", Order = -3)]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(50, ErrorMessage = "Máximo de {1} caracteres no campo {0}.")]
        public string ListRequester { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data de criação", Prompt = "Data de criação", Order = -2)]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Tempo de Execução", Prompt = "Tempo de Execução", Order = -1)]
        public TimeSpan RunningTime { get; set; }

        public int LastListStatusId { get; set; }

        public List<ProductChosen> ProductsChosen { get; set; }
    }

    public class ProductChosen
    {
        public int ProductId { get; set; }

        [Display(Name = "Produto", Prompt = "Produto")]
        public string ProductName { get; set; }

        [Range(1, 300, ErrorMessage = "Insira valores entre {1} e {2}.")]
        [Display(Name = "Quantidade Requerida", Prompt = "Quantidade Requerida")]
        public int RequiredQuantity { get; set; }

        [Display(Name = "Quantidade Recolhida", Prompt = "Quantidade Recolhida")]
        public int QuantityCatched { get; set; }
    }
}