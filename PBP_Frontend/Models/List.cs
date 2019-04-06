using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PBP_Frontend.Models
{
    public class List
    {
        [Key]

        public int ListId { get; set; }

        [Display(Name = "Nome", Prompt = "Nome", Order = 1)]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(50, ErrorMessage = "Máximo de {1} caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(50, ErrorMessage = "Máximo de {1} caracteres.")]
        [Display(Name = "Solicitante", Prompt = "Solicitante", Order = 2)]
        public string Requester { get; set; }

        [Display(Name = "Tempo de Execução", Prompt = "Tempo de Execução", Order = 3)]
        public TimeSpan RunningTime { get; set; }

        public virtual ICollection<ProductList> ProductsList { get; set; }
        public virtual ICollection<ChangeLog> ChangeLogs { get; set; }
    }
}