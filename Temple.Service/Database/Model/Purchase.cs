using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temple.Service.Database.Model
{
    public class Purchase
    {
        [Key]
        public Guid PurchaseId { get; set; }
        public Guid DonorId { get; set; }
        public Guid? MemberId { get; set; }
        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(100)]
        public string AddressLine1 { get; set; }
        [MaxLength(100)]
        public string AddressLine2 { get; set; }
        [MaxLength(50)]
        public string City { get; set; }
        [MaxLength(2)]
        public string State { get; set; }
        [MaxLength(5)]
        public string Zip { get; set; }
        public Guid FestivalId { get; set; }
        [MaxLength(50)]
        public string FestivalName { get; set; }
        public Guid OfferedServiceId { get; set; }
        [MaxLength(100)]
        public string OfferedServiceName { get; set; }
        public decimal SuggestedDonation { get; set; }
        public decimal ActualDonation { get; set; }
        [Column(TypeName = "Date")]
        public DateTime ServiceDate { get; set; }
    }
}
