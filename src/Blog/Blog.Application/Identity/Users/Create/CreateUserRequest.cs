using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.Enums;
using MediatR;

namespace Blog.Application.Identity.Users.Create;
public class CreateUserRequest
{
    public string Username { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public UserRole Role { get; set; }

    public CreateUserCommand ToCommand() => new(Username, Password, Phone, Email, Role);
}
