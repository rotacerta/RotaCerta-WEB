using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace pfcWeb.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }

        public virtual ICollection<ProductHistory> ProductsHistory { get; set; }
        public virtual List List { get; set; }
    }
}