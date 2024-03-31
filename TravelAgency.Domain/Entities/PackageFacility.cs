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
    public class PackageFacility : BaseEntity
    {
        public int PackageId { get; set; }
        public Package? package { get; set; }
        public int FacilityId { get; set; }
        public Facility? facility { get; set; }
        
    }
}