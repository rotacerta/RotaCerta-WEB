using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PBP_Frontend.Models
{
    public class ListStatus
    {
        [Key]
        public int ListStatusId { get; set; }
        [StringLength(50, ErrorMessage = "Máximo de {1} caracteres.")]
        [Display(Name = "Status", Prompt = "Status", Order = 1)]
        public string Status { get; set; }

        public virtual ICollection<ChangeLog> ChangeLogs { get; set; }
    }
}