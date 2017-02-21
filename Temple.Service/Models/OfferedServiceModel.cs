using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temple.Service.Models
{
    public class OfferedServiceModel
    {
        [Required]
        public Guid ServiceId { get; set; }
        [StringLength(50), Required]
        public string Name { get; set; }
        [StringLength(4000)]
        public string Description { get; set; }

        public Guid? FestivalId { get; set; }
        [StringLength(50)]
        public string FestivalName { get; set; }
        public decimal SuggestedDonation { get; set; }
    }
}
