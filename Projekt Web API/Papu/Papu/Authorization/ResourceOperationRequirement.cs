using Microsoft.AspNetCore.Authorization;

namespace Papu.Authorization
{
    //Klasa określająca jaką akcję chce wykonać dany użytkownik
    public enum ResourceOperation
    {
        Create,
        Read,
        Update,
        Delete
    }

    //Klasa reperezentująca nasze wymagania oraz typ konkrentej akcji 
    public class ResourceOperationRequirement : IAuthorizationRequirement
    {
        public ResourceOperationRequirement(ResourceOperation resourceOperation)
        {
            ResourceOperation = resourceOperation;
        }

        //Pobieranie konkretnej akcji 
        public ResourceOperation ResourceOperation { get; }
    }
}
