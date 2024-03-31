using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Domain.Entities;
using TravelAgency.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgency.Application.Validators.Entities;

public class LodgingOffer : BaseEntity
{
    [Required]
    //Añadir una lista con los id's válidos de un hotel según la tabla 
    public int HotelId { get; set; }

    [Required] 
    [MinLength(1)]  
    public string Description { get; set; }

    [Required]
    [Range(0.01, float.MaxValue)]
    public double Price { get; set; }
}