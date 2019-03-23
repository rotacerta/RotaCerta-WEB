using System;
using System.ComponentModel.DataAnnotations;

namespace pfcWeb.Models
{
    public class History
    {
        [Key]
        public int HistoryId { get; set; }
        public int ListID { get; set; }
        public DateTime Date { get; set; }
    }
}