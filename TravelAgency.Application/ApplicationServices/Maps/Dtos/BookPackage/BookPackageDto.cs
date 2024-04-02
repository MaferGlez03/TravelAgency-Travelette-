using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.Application.ApplicationServices.Maps.Dtos.BookPackage
{
    public class BookPackageDto
    {
        public int PackageId { get; set; }
        public int NumberOfPeople { get; set; }
        public string? AirlineCompany {get;set;}
    }
}