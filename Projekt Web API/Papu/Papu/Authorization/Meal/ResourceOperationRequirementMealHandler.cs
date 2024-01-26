using Microsoft.AspNetCore.Authorization;
using Papu.Entities;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Papu.Authorization
{
    public class ResourceOperationRequirementMealHandler : AuthorizationHandler<ResourceOperationRequirement, Meal>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            ResourceOperationRequirement requirement, Meal meal)
        {
            // Sprawdzamy czy chodzi o akcję czytania i tworzenia (dostępna dla wszystkich użytkowników)
            if (requirement.ResourceOperation == ResourceOperation.Read ||
                requirement.ResourceOperation == ResourceOperation.Create)
            {
                // Zezwalamy na autoryzację
                context.Succeed(requirement);
            }

            // Przypisujemy id użytkownika 
            var userId = context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value;

            // Sprawdzamy czy pobrane id pokrywa się z twórcą danej pory dnia 
            if (meal.CreatedById == int.Parse(userId))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
