using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Papu.Services
{
    //Korzysta z IHttp Context Accessora,
    //po to aby udostępniać informację o zalogowanym użytkowniku
    public class UserContextService : IUserContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContextService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        //Udostępniamy informacje o użytkowniku
        //dzięki znakowi zapytania unikniemy wystąpienia wyjątku, jeśli klient 
        //nie będzie posiadał autentykacji
        public ClaimsPrincipal User => _httpContextAccessor.HttpContext?.User;

        //Id zalogowane użytkownika
        //nie każde zapytanie będzie zawierać nagłówek autoryzacji dlatego ?
        //jeśli istnieje zwracamy id, a jeśli nie null
        public int? GetUserId =>
            User is null ? null : (int?)int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
    }
}
