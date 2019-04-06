using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PBP_Frontend.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Estrutura", Prompt = "Estrutura", Order = 1)]
        public int Structure { get; set; }

        [Display(Name = "Rua", Prompt = "Rua", Order = 2)]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int Street { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Prédio", Prompt = "Prédio", Order = 3)]
        public int Building { get; set; }

        [Display(Name = "Andar", Prompt = "Andar", Order = 4)]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int Flat { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public override string ToString()
        {
            return String.Format("{0}.{1}.{2}.{3}", this.Structure, this.Street, this.Building, this.Flat);
        }
    }
}