using System.ComponentModel.DataAnnotations;

namespace PBP_Frontend.Models
{
    public class ProductList
    {
        [Key]
        public int ProductListId { get; set; }
        public int QuantityCatched { get; set; }
        public int RequiredQuantity { get; set; }

        public int ListId { get; set; }
        public virtual List List { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}