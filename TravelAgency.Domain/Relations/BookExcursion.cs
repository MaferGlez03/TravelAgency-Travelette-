using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Domain.Common;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Domain.Relations;

public class BookExcursion : BaseEntity
{
    public int ExcursionId {get; set;}
    public int TouristId {get; set;}
    public Excursion? Excursion {get; set;}
    public Tourist? Tourist {get; set;}
    public float TotalPrice {get; set;}
    public int NumberOfCompanions {get; set;}
}