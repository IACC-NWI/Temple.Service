﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temple.Service.Database.Model
{
    public class OfferedService
    {
        [Key]
        public Guid ServiceId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(4000)]
        public string Description { get; set; }

        public Guid? FestivalId { get; set; }
        [MaxLength(50)]
        public string FestivalName { get; set; }

        public decimal SuggestedDonation { get; set; }
    }
}
