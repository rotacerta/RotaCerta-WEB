using System.ComponentModel.DataAnnotations;

namespace pfcWeb.Models
{
    public class ProductHistory
    {
        [Key]
        public int ProductHistoryId { get; set; }
        public int HistoryId { get; set; }
        public int ProductId { get; set; }
        public int QuantityCatched { get; set; }
        public int RequiredQuantity { get; set; }

        public virtual History History { get; set; }
        public virtual Product Product { get; set; }
    }
}