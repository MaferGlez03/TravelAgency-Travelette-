using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using TravelAgency.Domain.Common;
using TravelAgency.Domain.Relations;

namespace TravelAgency.Domain.Entities
{
    public class Package : BaseEntity
    {
        public string Description { get; set; } = null!;
        public double Price { get; set; }
        public int Capacity { get; set; }
        public int Duration { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int AgencyID {get; set; }
        public Agency? agency { get; set; }
        public IList<PackageFacility> packageFacilities { get; set; } = new List<PackageFacility>();
        public IList<PackageExtendedExcursion> PackageExtendedExcursions{get; private set;}= new List<PackageExtendedExcursion>();
        public IList<BookPackage> BookPackages{get; private set;}= new List<BookPackage>();



        #region "Methods"
        public void AddFacilities(List<PackageFacility> _packageFacilities)
        {
            foreach (PackageFacility facility in _packageFacilities)
            {
                if(!packageFacilities.Contains(facility))
                packageFacilities.Add(facility);
            }
        }
        public void AddExcursions(List<PackageExtendedExcursion> _PackageExtendedExcursions)
        {
            foreach (var extendedExcursion in _PackageExtendedExcursions)
            {
                if(!PackageExtendedExcursions.Contains(extendedExcursion))
                PackageExtendedExcursions.Add(extendedExcursion);
            }
        }
        public void RemoveExcursions(List<PackageExtendedExcursion> _PackageExtendedExcursions)
        {
            foreach (var extendedExcursion in _PackageExtendedExcursions)
            {
                if(PackageExtendedExcursions.Contains(extendedExcursion))
                PackageExtendedExcursions.Remove(extendedExcursion);
            }
        }
        #endregion
    }
}