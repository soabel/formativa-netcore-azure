using System;
using FluentValidation;
using Formativa.Users.Api.Infraestructure.Persistence.Entities;

namespace Formativa.Users.Api.Infraestructure.Core.Validations
{
    public class UsersValidation: AbstractValidator<User>
    {
        public UsersValidation()
        {
            //RuleFor(r => r.Name).NotEmpty().WithMessage("{PropertyName} No puede estar vacío.")
            //   .MinimumLength(5).WithMessage("{PropertyName} Debe ser mayor a 5 caracteres.");
            //RuleFor(r => r.Email).NotEmpty().WithMessage("{PropertyName} No puede estar vacío.")
            //    .EmailAddress().WithMessage("{PropertyName} nos válido.");

        }
    }
}
