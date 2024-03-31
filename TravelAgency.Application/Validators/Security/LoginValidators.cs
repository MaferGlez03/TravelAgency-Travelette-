using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgency.Application.Validators.Security;

public class LoginValidators
{
    [Required]
    public string UserName {get; set;}

    [Required]
    public string Password {get; set;}
}