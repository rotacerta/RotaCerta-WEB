using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PBP_Frontend.Models
{
    public class ChangeLog
    {
        [Key]
        public int ChangeLogId { get; set; }
        public DateTime Date { get; set; }

        public int ListId { get; set; }
        public virtual List List { get; set; }

        public int ListStatusId { get; set; }
        public virtual ListStatus ListStatus { get; set; }
    }
}