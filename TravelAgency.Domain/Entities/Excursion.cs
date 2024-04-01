using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Domain.Common;

namespace TravelAgency.Domain.Entities
{
    public class Excursion : BaseEntity
    {
        public string Name {get; set;} = null!; 
        public int Capacity {get; set;} = 0; 
        public float Price {get; set;} = 0; 
        public string DeparturePlace {get; set;} = null!; 
        public string ArrivalPlace {get; set;} = null!; 
        public DateTime DepartureDate {get; set;} = DateTime.MinValue; //1 de enero de 0001 a las 00:00:00 AM
        public DateTime ArrivalDate {get; set;} = DateTime.MinValue; //1 de enero de 0001 a las 00:00:00 AM
        public string Guia {get; set;} = null!; 
        public int AgencyID {get; set; }
        public Agency? agency { get; set; }
    }
}