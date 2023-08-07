using QueHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueHub.Domain.Entity.User;

public class UserEntity: Auditable
{
    [MaxLength(25)]
    public string FirstName { get; set; } = string.Empty;


    [MaxLength(25)]
    public string LastName { get; set; } = string.Empty;


    [MaxLength(25)]
    public string UserName { get; set; } = string.Empty;


    public string ImagePath { get; set; } = string.Empty;


    public string Email { get; set; } = string.Empty;


    public bool EmailIsVerify { get; set; }


    public string Password { get; set; } = string.Empty;


    public string Salt { get; set; } = string.Empty;


    public long Rating { get; set; }


}