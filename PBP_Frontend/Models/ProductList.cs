using System.ComponentModel.DataAnnotations;

namespace pfcWeb.Models
{
    public class ProductList
    {
        [Key]
        public int ProductListId { get; set; }
        public int ListID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
    }
}