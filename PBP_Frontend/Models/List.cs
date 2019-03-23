using System.ComponentModel.DataAnnotations;

namespace pfcWeb.Models
{
    public class List
    {
        [Key]
        public int ListId { get; set; }
        public string Name { get; set; }
        public string Requester { get; set; }
    }
}