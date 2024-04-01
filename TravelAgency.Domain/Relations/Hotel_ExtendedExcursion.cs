using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Domain.Common;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Domain.Relations;

public class Hotel_ExtendedExcursion : BaseEntity
{
    public int HotelId {get; set;}
    public int ExtendedExcursionId {get; set;}
    public Hotel? Hotel {get; set;}
    public ExtendedExcursion? ExtendedExcursion {get; set;}
    public DateTime ArrivalDate {get; set;}
}