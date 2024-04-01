using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Domain.Common;
using TravelAgency.Domain.Relations;

namespace TravelAgency.Domain.Entities
{
    public class ExtendedExcursion : Excursion
    {
        public int NumberOfDays { get; set; } = 0;
        public IList<Hotel_ExtendedExcursion> HotelExtendedExcursions { get; private set; } = new List<Hotel_ExtendedExcursion>();
        public IList<PackageExtendedExcursion> PackageExtendedExcursions{get; private set;}= new List<PackageExtendedExcursion>();
        #region "Methods"
        public void AddExtendedExcursions(List<Hotel_ExtendedExcursion> _hotel_ExtendedExcursions)
        {
            foreach (Hotel_ExtendedExcursion extendedExcursion in _hotel_ExtendedExcursions)
            {
                if (!HotelExtendedExcursions.Contains(extendedExcursion))
                    HotelExtendedExcursions.Add(extendedExcursion);
            }
        }
        #endregion
    }
}