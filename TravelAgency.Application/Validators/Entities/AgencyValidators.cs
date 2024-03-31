using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Domain.Entities;
using TravelAgency.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgency.Application.Validators.Entities;

public class Agency : BaseEntity
{
    [Required] 
    [StringLength(30, MinimumLength = 1)]
    public string Name {get; set;} = null!;
    public string Fax {get; set;} = null!;
    public string Address {get; set;} = null!;

    [Required]
    [EmailAddress]
    public string ElectronicAddress {get; set;} = null!;
}