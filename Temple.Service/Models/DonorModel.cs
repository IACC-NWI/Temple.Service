using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temple.Service.Models
{
    public class DonorModel
    {
        public Guid DonorId { get; set; }
        public Guid? MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public decimal TotalDonation { get; set; }
    }
}
