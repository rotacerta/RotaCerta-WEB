using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace PBP_Frontend.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Display(Name = "Nome", Prompt = "Nome", Order = 1)]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(50, ErrorMessage = "Máximo de {1} caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Localização", Prompt = "Localização", Order = 2)]
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }

        public virtual ICollection<ProductList> ProductLists { get; set; }
    }

    public static class StringExt
    {
        public static bool ContainsInsensitive(this String source, String search)
        {
            return ((new CultureInfo("pt-BR").CompareInfo).IndexOf(source, search, CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace) >= 0);
        }
    }
}