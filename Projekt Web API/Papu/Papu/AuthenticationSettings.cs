namespace Papu
{
    // Klasa odpowiednio reprezentująca wartości z appsettings.json
    public class AuthenticationSettings
    {
        // Klucz potrzebny do wygenerowania tokenu JWT
        public string JwtKey { get; set; }

        // Czas przez jakiś token będzie ważny
        public int JwtExpireDays { get; set; }

        // Podmiot, który generuje dany token 
        public string JwtIssuer { get; set; }
    }
}
