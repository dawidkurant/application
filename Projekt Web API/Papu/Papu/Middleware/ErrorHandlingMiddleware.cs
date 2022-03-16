using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Papu.Exceptions;
using System;
using System.Threading.Tasks;

namespace Papu.Middleware
{
    //Middleware - jest dodany do klasy startup przez co każde zapytanie
    //przychodzące do naszego api, będzie procesowane przez niego
    //aby wyłapywać wyjątki np.brak możliwości połączenia z bazą danych
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (NotFoundException notFoundException)
            {
                //Jeśli do naszego api przyjdzie jakiekolwiek zapytanie, dla którego istnieje
                //walidacja modelu, to if (!ModelState.IsValid) zostanie wywołany automatycznie
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(notFoundException.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);

                //Aby obsłużyć zapytanie, w którym wystąpi wyjątek możemy również do odpowiedzi
                //dla klienta wypisać jakis generyczny tekst po to aby nie miał on informacji
                //bezpośrednio z kodu czyli kod statusu
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Something went wrong");
            }
        }
    }
}
