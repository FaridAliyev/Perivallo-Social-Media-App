using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Perivallo.Models
{
    public class PostReport
    {
        public int Id { get; set; }
        [ForeignKey("ReportFrom")]
        public string ReportFromId { get; set; }
        public int PostId { get; set; }
        public User ReportFrom { get; set; }
        public virtual Post Post { get; set; }
        public string Reason { get; set; }
        public DateTime Date { get; set; }
    }
}
