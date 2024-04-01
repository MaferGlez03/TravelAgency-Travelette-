using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Domain.Common;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Domain.Relations
{
    public class PackageExtendedExcursion:BaseEntity
    {
        public int PackageId { get; set; }
        public int ExtendedExcursionId { get; set; }
        public Package? Package{get;set;}
        public ExtendedExcursion? Excursion{get;set;}
    }
}