using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temple.Service.Models
{
    public class PurchaseOfferingModel
    {
        public Guid PurchaseId { get; set; }
        public Guid MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public Guid FestivalId { get; set; }
        public string FestivalName { get; set; }
        public Guid OfferedServiceId { get; set; }
        public string OfferedServiceName { get; set; }
        public decimal SuggestedDonation { get; set; }
        public decimal ActualDonation { get; set; }
        public DateTime ServiceDate { get; set; }
    }
}
