using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pfcWeb.Models
{
    public class ProductList
    {
        public int Id { get; set; }
        public int ListID { get; set; }
        public int ProductID { get; set; }
        public int Quantity;

        public bool setQuantity(int quantity) {
            if (quantity > 0)
            {
                this.Quantity = quantity;
                return true;
            }
            return false;
        }

        public int getQuantity() {
            return this.Quantity;
        }


    }
}