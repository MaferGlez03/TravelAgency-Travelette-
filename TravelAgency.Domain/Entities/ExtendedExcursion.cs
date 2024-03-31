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
    public class ExtendedExcursion : Excursion
    {
        public int NumberOfDays {get; set;} = 0;
    }
}