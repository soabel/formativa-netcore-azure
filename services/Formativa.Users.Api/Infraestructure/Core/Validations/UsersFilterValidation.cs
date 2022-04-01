using System;
using FluentValidation;
using Formativa.Users.Api.Wrappers;

namespace Formativa.Users.Api.Infraestructure.Core.Validations
{
    public class UsersFilterValidation: AbstractValidator<UserFilter>
    {
        public UsersFilterValidation()
        {
            RuleFor(r => r.Name).NotEmpty().WithMessage("{PropertyName} No puede estar vacío.")
               .MinimumLength(3).WithMessage("{PropertyName} Debe tener al menos 3 caracteres.")
               .Must(x => !x.Contains("TRUNCATE")).WithMessage("{PropertyName} no debe contener palabras prohibidas.")
               .MaximumLength(30).WithMessage("{PropertyName} no debe ser mayor a 30 caracteres.");

        }
    }
}
