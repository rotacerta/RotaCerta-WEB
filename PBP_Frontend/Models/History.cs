using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace pfcWeb.Models
{
    public class History
    {
        [Key]
        public int HistoryId { get; set; }
        public int ListID { get; set; }
        public DateTime Date { get; set; }

        public virtual ICollection<ProductList> ProductsList { get; set; }
        public virtual ICollection<List> Lists { get; set; }
    }
}