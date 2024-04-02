using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.Application.ApplicationServices.Maps.Dtos.BookAgency;

public class BookAgencyDto 
{
    public int AgencyId {get; set;}
    public string AgencyName { get; set; }
    public int TotalBooks {get; set;}
    public double ExpectedAmount { get; set; } 
}