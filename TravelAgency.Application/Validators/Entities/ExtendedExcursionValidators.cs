using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Domain.Entities;
using TravelAgency.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TravelAgency.Application.Validators.Utils;

namespace TravelAgency.Application.Validators.Entities;

public class ExtendedExcursion : Excursion
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int NumberOfDays {get; set;} = 0; 
    }