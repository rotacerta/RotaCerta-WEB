using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pfcWeb.Models
{
    public class Product
    {
        [Key] public int Id { get; set; }
        public string Name;
        public int LocationId { get; set; }

        public bool setName(string name)
        {
            if(name != null) {
                int sizeName = name.Length;
                if (sizeName > 0 && sizeName <= 50)
                {
                    this.Name = name;
                    return true;
                }
            }
            return false;
        }
        public string getName()
        {
             return this.Name;
        }
    }
}