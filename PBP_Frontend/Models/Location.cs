using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PBP_Frontend.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }
        public int Structure { get; set; }
        public int Street { get; set; }
        public int Building { get; set; }
        public int Flat { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}