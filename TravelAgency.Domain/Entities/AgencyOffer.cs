using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using TravelAgency.Domain.Common;

namespace TravelAgency.Domain.Entities
{
    public class AgencyOffer : BaseEntity
    {
        public int HotelId { get; set; }
        public int AgencyId { get; set; }
        public double Price { get; set; }
    }
}