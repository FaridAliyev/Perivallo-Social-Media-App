using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Perivallo.Models
{
    public class UserReport
    {
        public int Id { get; set; }
        [ForeignKey("ReportFrom")]
        public string ReportFromId { get; set; }
        [ForeignKey("ReportTo")]
        public string ReportToId { get; set; }
        public User ReportFrom { get; set; }
        public User ReportTo { get; set; }
        public string Reason { get; set; }
        public DateTime Date { get; set; }
    }
}
