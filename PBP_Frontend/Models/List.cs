using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PBP_Frontend.Models
{
    public class List
    {
        [Key]
        public int ListId { get; set; }
        public string Name { get; set; }
        public string Requester { get; set; }

        public virtual ICollection<ProductList> ProductsList { get; set; }
        public virtual ICollection<ChangeLog> ChangeLogs { get; set; }
    }
}