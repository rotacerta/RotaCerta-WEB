using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace pfcWeb.Models
{
    public class List
    {
        [Key]
        public int ListId { get; set; }
        public string Name { get; set; }
        public string Requester { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<ProductList> ProductsList { get; set; }
        public virtual History History { get; set; }
    }
}