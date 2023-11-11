using Microsoft.AspNetCore.Authorization;

namespace Papu.Authorization
{
    /// <summary>
    /// Klasa określająca jaką akcję chce wykonać dany użytkownik
    /// </summary>
    public enum ResourceOperation
    {
        Create,
        Read,
        Update,
        Delete
    }

    /// <summary>
    /// Klasa reperezentująca nasze wymagania oraz typ konkrentej akcji 
    /// </summary>
    public class ResourceOperationRequirement : IAuthorizationRequirement
    {
        public ResourceOperationRequirement(ResourceOperation resourceOperation)
        {
            ResourceOperation = resourceOperation;
        }

        /// <summary>
        /// Pobieranie konkretnej akcji 
        /// </summary>
        public ResourceOperation ResourceOperation { get; }
    }
}
