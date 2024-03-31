using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.Application.ApplicationServices.Maps.Dtos.Agency
{
    public class AgencyDto
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; }
        public string Address { get; set; }
        public string Fax { get; set; }
        public string ElectronicAddress { get; set; }
    }
}