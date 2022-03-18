using FluentValidation;
using Papu.Entities;
using System.Linq;

namespace Papu.Models.Validators
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator(PapuDbContext dbContext)
        {
            RuleFor(x => x.Email)

                //Nie może być to pole puste
                .NotEmpty()

                //To pole musi być w formacie adresu email
                .EmailAddress();

            //Musi mieć conajmniej 6 znaków
            RuleFor(x => x.Password).MinimumLength(6);

            //Drugi raz podane hasło będzie porównywane z hasłem podanym za pierwszym razem
            RuleFor(x => x.ConfirmPassword).Equal(e => e.Password);

            //Sprawdzamy czy wartość email jest unikalna, czyli czy nie istnieje już użytkownik
            //z takim samym adresem email
            RuleFor(x => x.Email)
                .Custom((value, context) =>
                {
                    var emailInUse = dbContext.Users.Any(u => u.Email == value);
                    if (emailInUse)
                    {
                        context.AddFailure("Email", "That email is taken");
                    }
                });
        }
    }
}
