using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using SolucionCacao.Models;

namespace SolucionCacao.Validations
{
    public class ValidateLogin : AbstractValidator<Login>
    {
       /* public ValidateLogin()
        {
            RuleFor(x => x.Usuario).NotNull().WithMessage("Debe ingresar su nombre de usuario.");
            RuleFor(x => x.Password).NotNull().WithMessage("Debe ingresar su contraseña.");
        }*/
        
    }
}