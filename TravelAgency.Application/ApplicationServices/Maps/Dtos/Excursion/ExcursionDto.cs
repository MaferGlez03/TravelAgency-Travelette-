using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.Application.ApplicationServices.Maps.Dtos.Excursion
{
    public class ExcursionDto
    {
        public int Id {get; set;}
        public string Name {get; set;} = null!; 
        public int Capacity {get; set;} = 0; 
        public float Price {get; set;} = 0; 
        public DateTime ArrivalDate {get; set;} = DateTime.MinValue; //1 de enero de 0001 a las 00:00:00 AM
        public DateTime DepartureDate {get; set;} = DateTime.MinValue; //1 de enero de 0001 a las 00:00:00 AM
        public string ArrivalPlace {get; set;} = null!; 
        public string DeparturePlace {get; set;} = null!; 
        public string Guia {get; set;} = null!; 
    }
}