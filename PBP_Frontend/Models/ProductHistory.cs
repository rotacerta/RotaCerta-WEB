using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace pfcWeb.Models
{
    public class ProductHistory
    {
        [Key]
        public int ProductHistoryId { get; set; }
        public int ListId { get; set; }
        public int ProductId { get; set; }
        public int QuantityCatched { get; set; }
        public int RequiredQuantity { get; set; }
    }
}