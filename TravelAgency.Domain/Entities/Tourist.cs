using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Domain.Common;

namespace TravelAgency.Domain.Entities
{
    public class Tourist:BaseEntity
    {
        //!Set restrictions

        public string Name {get; set;} = null!;
        public string Nationality {get; set;} = null!;
    }
}