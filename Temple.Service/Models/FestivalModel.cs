using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temple.Service.Models
{
    public class FestivalModel
    {
        [Required]
        public Guid FestivalId { get; set; }
        [StringLength(50), Required]
        public string Name { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
    }
}
