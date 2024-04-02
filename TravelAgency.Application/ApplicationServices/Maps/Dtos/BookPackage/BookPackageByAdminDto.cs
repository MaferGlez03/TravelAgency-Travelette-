using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.Application.ApplicationServices.Maps.Dtos.BookPackage
{
    public class BookPackageByAdminDto:BookPackageDto
    {
        public string UserName {get; set;} = null!;
        public int Nacionality{get;set;} 
    }
}