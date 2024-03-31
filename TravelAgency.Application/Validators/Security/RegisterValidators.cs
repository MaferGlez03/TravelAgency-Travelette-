using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TravelAgency.Application.Validators.Utils;

namespace TravelAgency.Application.Validators.Security;

 public class RegisterValidators : _List
{

    [Required]
    [MinLength(4, ErrorMessage = "El nombre de usuario debe contener al menos 4 caracteres.")]
    public string UserName { get; set; }

    [Required]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z\d\s]).{8,}$", ErrorMessage = "La contraseña debe contener al menos: 8 caracteres, una minúscula, una mayúscula, un número, un carácter especial.")]
    public string Password { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MatchList(nameof(base.Countries))]
    public string Nacionality { get; set; }   
}