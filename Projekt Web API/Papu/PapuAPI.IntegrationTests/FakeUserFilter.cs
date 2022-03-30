using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PapuAPI.IntegrationTests
{
    //Fejkowy użytkownik z konkretnymi claimami, aby testy z autentykacją mogły być realizowane  
    public class FakeUserFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var claimsPrincipal = new ClaimsPrincipal();

            claimsPrincipal.AddIdentity(new ClaimsIdentity(
                new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, "2"),
                    new Claim(ClaimTypes.Role, "Manager"),
                }));

            context.HttpContext.User = claimsPrincipal;

            await next();
        }
    }
}
