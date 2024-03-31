using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Domain.Entities;
using TravelAgency.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgency.Domain.Validators;

[Table("Agencies")]
 public class Agency : BaseEntity
{
    [Key]
    [Column("Id")]
    public override int Id { get; set; }

    [Column("Name")]
    [Required]
    [StringLength(30, MinimumLength = 1)]
    public string Name {get; set;} = null!;

    [Column("Fax")]
    public string Fax {get; set;} = null!;

    [Column("Address")]
    public string Address {get; set;} = null!;

    [Column("ElectronicAddress")]
    [Required]
    [EmailAddress]
    public string ElectronicAddress {get; set;} = null!;
}

[Table("Hotels")]
public class Hotel : BaseEntity
{
    [Key]
    [Column("Id")]
    public override int Id { get; set; }
    
    [Column("Name")]
    [Required]
    [StringLength(30, MinimumLength = 1)]
    public string Name {get; set;} = null!;

    [Column("Category")]
    [Required]
    public string Category{get; set;} = null!;

    [Column("Address")]
    [Required]
    public string Address {get; set;} = null!;
}

[Table("Facilities")]
public class Facility : BaseEntity
{
    [Key]
    [Column("Id")]
    public override int Id { get; set; }
    
    [Column("Name")]
    [Required]
    [StringLength(30, MinimumLength = 1)]
    public string Name {get; set;} = null!; 
}

[Table("Tourists")]
public class Tourist : BaseEntity
{
    [Key]
    [Column("Id")]
    public override int Id { get; set; }

    [Column("Name")]
    [Required]
    [StringLength(50, MinimumLength = 1)]
    public string Name {get; set;} = null!;
    
    [Column("Nationality")]
    [Required]
    public string Nationality {get; set;} = null!;
}