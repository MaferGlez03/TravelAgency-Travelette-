using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Domain.Common;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Domain.Relations
{
    public class BookPackage:BaseEntity
    {
        public int TouristId { get; set; }
        public Tourist? Tourist { get; set; }
        public int PackageId { get; set; }
        public Package? Package { get; set; }
        public double Price { get; set; }
        public int NumberOfPeople { get; set; }
        public string AirlineCompany{ get; set; } = null!;




    }
}