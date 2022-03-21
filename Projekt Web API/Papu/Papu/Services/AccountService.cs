using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Papu.Entities;
using Papu.Exceptions;
using Papu.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Papu.Services
{
    //Jest odpowiedzialny za tworzenie i logowanie nowych użytkowników
    public class AccountService : IAccountService
    {
        private readonly PapuDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;

        public AccountService(PapuDbContext context, IPasswordHasher<User> passwordHasher, 
            AuthenticationSettings authenticationSettings)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
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

        public string GenerateJwt(LoginDto dto)
        {
            var user = _context.Users
                .Include(u => u.Role)
                .FirstOrDefault(u => u.Email == dto.Email);

            if (user is null)
            {
                throw new BadRequestException("Invalid username or password");
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);

            if (result == PasswordVerificationResult.Failed)
            {
                throw new BadRequestException("Invalid username or password");
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Role, $"{user.Role.Name}"),
                new Claim("DateOfBirth", user.DateOfBirth.Value.ToString("yyyy-MM-dd")),
                new Claim("Nationality", user.Nationality)
            };

            //Przekazujemy nasz klucz prywatny jako tablicę bajtów
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            //Credential potrzebny do podpisania tokenu JWT
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            //Data do której ten token będzie poprawny
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            //Utworzenie tokenu
            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();
            //Generowanie tokenu
            return tokenHandler.WriteToken(token);
        }

    }
}
