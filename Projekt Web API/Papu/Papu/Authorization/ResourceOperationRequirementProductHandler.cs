using Microsoft.AspNetCore.Authorization;
using Papu.Entities;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Papu.Authorization
{
    public class ResourceOperationRequirementProductHandler : AuthorizationHandler<ResourceOperationRequirementProduct, Product>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, 
            ResourceOperationRequirementProduct requirement, Product product)
        {
            //Sprawdzamy czy chodzi o akcję czytania i tworzenia (dostępna dla wszystkich użytkowników)
            if (requirement.ResourceOperation == ResourceOperation.Read ||
                requirement.ResourceOperation == ResourceOperation.Create)
            {
                //Zezwalamy na autoryzację
                context.Succeed(requirement);
            }

            //Przypisujemy id użytkownika 
            var userId = context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value;

            //Sprawdzamy czy pobrane id pokrywa się z twórcą danego produktu 
            if (product.CreatedById == int.Parse(userId))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
