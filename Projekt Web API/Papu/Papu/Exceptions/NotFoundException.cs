using System;

namespace Papu.Exceptions
{
    // Obsługa zasady, że użytkownik nie ma dostępu do jakiegoś zasobu 
    // lub jakiś zasób nie istnieje 
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {

        }
    }
}
