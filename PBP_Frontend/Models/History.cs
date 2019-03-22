using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pfcWeb.Models
{
    public class History
    {
        [Key] public int Id { get; set; }
        public int ListID { get; set; }
        public DateTime date { get; set; }
    }
}