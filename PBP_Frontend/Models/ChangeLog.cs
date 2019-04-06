using System;
using System.ComponentModel.DataAnnotations;

namespace PBP_Frontend.Models
{
    public class ChangeLog
    {
        [Key]
        public int ChangeLogId { get; set; }
        [Display(Name = "Data", Prompt = "Data", Order = 2)]
        public DateTime Date { get; set; }

        [Display(Name = "Lista", Prompt = "Lista", Order = 1)]
        public int ListId { get; set; }
        public virtual List List { get; set; }

        [Display(Name = "Status", Prompt = "Status", Order = 3)]
        public int ListStatusId { get; set; }
        public virtual ListStatus ListStatus { get; set; }
    }
}