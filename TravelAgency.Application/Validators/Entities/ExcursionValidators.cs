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

public class Excursion : BaseEntity
    {
        [Required] 
        [StringLength(30, MinimumLength = 1)]
        public string Name {get; set;} = null!; 

        [Required]
        [Range(1, int.MaxValue)]
        public int Capacity {get; set;} = 0;

        [Required]
        [Range(0.01, float.MaxValue)]
        public float Price {get; set;} = 0; 

        [Required] 
        [MinLength(1)]
        public string DeparturePlace {get; set;} = null!;

        [Required]
        [MinLength(1)] 
        public string ArrivalPlace {get; set;} = null!;

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd, HH':'mm}", ApplyFormatInEditMode = true)]
        [FutureDate(ErrorMessage = "The date must be greater than the current date.")]
        public DateTime DepartureDate {get; set;} = DateTime.MinValue; //1 de enero de 0001 a las 00:00:00 AM

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd, HH':'mm}", ApplyFormatInEditMode = true)]
        [FutureDate(ErrorMessage = "The date must be greater than the current date.")]
        public DateTime ArrivalDate {get; set;} = DateTime.MinValue; //1 de enero de 0001 a las 00:00:00 AM

        [StringLength(30, MinimumLength = 1)]
        public string Guia {get; set;} = null!; 
    }