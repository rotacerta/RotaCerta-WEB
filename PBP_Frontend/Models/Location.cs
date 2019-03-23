using System.ComponentModel.DataAnnotations;

namespace pfcWeb.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }
        public int Structure { get; set; }
        public int Street { get; set; }
        public int Building { get; set; }
        public int Flat { get; set; }
        public virtual Product Product { get; set; }
    }
}