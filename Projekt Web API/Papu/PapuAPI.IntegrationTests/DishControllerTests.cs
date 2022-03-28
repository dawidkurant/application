using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Papu;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace PapuAPI.IntegrationTests
{
    public class DishControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private HttpClient _client;

        //Konstruktor po to, aby nie tworzyć klienta oddzielnie dla każdego testu
        //jeśli chcemy aby kontekst był współdzielony między testami (czyli obiekt Dish
        //ControllerTests był stworzony raz, a nie za każdym razem, kiedy uruchamia się test)
        public DishControllerTests(WebApplicationFactory<Startup> factory)
        {
            //Tutaj chcemy uruchomić nasze Api po to abyśmy byli w stanie wysłać zapytanie http jakimś
            //klientem http z kodu 
            //należy dodać zależność, aby startup działał
            _client = factory.CreateClient();
            //Wykorzystujemy fabrykę aby zwróciła nam odpowiedniego klienta http
            //z pomocą klienta odwołujemy się do metod z naszego api
        }

        //getOneDish
        [Fact]
        public async Task GetDish_WithParameter_ReturnsOkResult()
        {
            //arrange

            //act

            var response = await _client.GetAsync("https://localhost:5001/api/dish/1");

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy ok
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //getAnotherOneDish
        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        public async Task AnotherGetDish_WithParameter_ReturnsOkResult(string queryParams)
        {
            //arrange

            //act

            var response = await _client.GetAsync("https://localhost:5001/api/dish/" + queryParams);

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy ok
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //getAnotherOneDish
        [Theory]
        [InlineData("100")]
        [InlineData("200")]
        public async Task AnotherGetDish_WithInvalidParameter_ReturnsNotFound(string queryParams)
        {
            //arrange

            //act

            var response = await _client.GetAsync("https://localhost:5001/api/dish/" + queryParams);

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy not found
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }
    }
}
