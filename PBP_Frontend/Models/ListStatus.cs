using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PBP_Frontend.Models
{
    public class ListStatus
    {
        [Key]
        public int ListStatusId { get; set; }
        public string Status { get; set; }

        public virtual ICollection<ChangeLog> ChangeLogs { get; set; }
    }
}