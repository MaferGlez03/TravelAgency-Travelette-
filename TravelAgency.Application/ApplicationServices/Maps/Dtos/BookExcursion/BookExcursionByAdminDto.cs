using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.Application.ApplicationServices.Maps.Dtos.BookExcursion;

public class BookExcursionByAdminDto : BookExcursionDto
{
     public string UserName {get; set;} = null!;
     public string Email {get; set;} = null!;
     public int Nacionality{get;set;}    
}