using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pfcWeb.Models
{
    public class Location
    {

        [Key] public int Id { get; set; }
        public int Structure { get; set; }
        public int Street { get; set; }
        public int Building { get; set; }
        public int Flat { get; set; }
    }
}