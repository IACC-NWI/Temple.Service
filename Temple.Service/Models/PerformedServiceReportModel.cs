using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temple.Service.Models
{
    public class PerformedServiceReportModel
    {
        public string Name { get; set; }
        public Guid ServiceId { get; set; }
        public int Count { get; set; }
        public decimal TotalDonations { get; set; }
    }
}
