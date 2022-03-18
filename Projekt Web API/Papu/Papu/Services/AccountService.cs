using Microsoft.AspNetCore.Identity;
using Papu.Entities;
using Papu.Models;

namespace Papu.Services
{
    //Jest odpowiedzialny za tworzenie i logowanie nowych użytkowników
    public class AccountService : IAccountService
    {
        private readonly PapuDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AccountService(PapuDbContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public void RegisterUser(RegisterUserDto dto)
        {
            //Na początku dodawaliśmy użytkownika bez hasła,
            //ponieważ trzeba było je odpowiednio zhashować
            var newUser = new User()
            {
                Email = dto.Email,
                DateOfBirth = dto.DateOfBirth,
                Nationality = dto.Nationality,
                RoleId = dto.RoleId
            };

            //Hasło jest hashowane przed dodaniem użytkownika
            var hashedPassword = _passwordHasher.HashPassword(newUser, dto.Password);

            //Zhashowane hasło jest dodawane do użytkownika
            newUser.PasswordHash = hashedPassword;
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }

    }
}
