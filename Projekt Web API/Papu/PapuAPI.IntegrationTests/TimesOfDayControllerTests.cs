using FluentAssertions;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Papu;
using Papu.Entities;
using Papu.Models;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PapuAPI.IntegrationTests
{
    public class TimesOfDayControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        //Konstruktor po to, aby nie tworzyć klienta oddzielnie dla każdego testu
        //jeśli chcemy aby kontekst był współdzielony między testami (czyli obiekt TimesOfDay
        //ControllerTests był stworzony raz, a nie za każdym razem, kiedy uruchamia się test)
        public TimesOfDayControllerTests(WebApplicationFactory<Startup> factory)
        {
            //Tutaj chcemy uruchomić nasze Api po to abyśmy byli w stanie wysłać zapytanie http jakimś
            //klientem http z kodu 
            //należy dodać zależność, aby startup działał
            //Wykorzystujemy fabrykę aby zwróciła nam odpowiedniego klienta http
            //z pomocą klienta odwołujemy się do metod z naszego api
            _client = factory
                //Umożliwia nam modyfikację wbudowanego webhosta, aby podczas testów nie korzystać z bazy danych sql
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        //Szukamy zarejestrowanego już serwisu dla istniejących opcji dbcontext
                        var dbContextOptions = services
                        .SingleOrDefault(service => service.ServiceType == typeof(DbContextOptions<PapuDbContext>));

                        services.Remove(dbContextOptions);

                        services.AddDbContext<PapuDbContext>(options => options.UseInMemoryDatabase("PapuDb"));

                        //Rejestrujemy żeby uniknąć autentykacji podczas testów
                        services.AddSingleton<IPolicyEvaluator, FakePolicyEvaluator>();
                        services.AddMvc(option => option.Filters.Add(new FakeUserFilter()));
                    });
                })
                .CreateClient();
        }

        //getOneBreakfast
        [Fact]
        public async Task GetBreakfast_WithParameter_ReturnsOkResult()
        {
            //arrange

            //act

            var response = await _client.GetAsync("https://localhost:5001/api/breakfast/1");

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy ok
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //getOneSecondBreakfast
        [Fact]
        public async Task GetSecondBreakfast_WithParameter_ReturnsOkResult()
        {
            //arrange

            //act

            var response = await _client.GetAsync("https://localhost:5001/api/secondbreakfast/1");

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy ok
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //getOneLunch
        [Fact]
        public async Task GetLunch_WithParameter_ReturnsOkResult()
        {
            //arrange

            //act

            var response = await _client.GetAsync("https://localhost:5001/api/lunch/1");

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy ok
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //getOneSnack
        [Fact]
        public async Task GetSnack_WithParameter_ReturnsOkResult()
        {
            //arrange

            //act

            var response = await _client.GetAsync("https://localhost:5001/api/snack/1");

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy ok
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //getOneDinner
        [Fact]
        public async Task GetDinner_WithParameter_ReturnsOkResult()
        {
            //arrange

            //act

            var response = await _client.GetAsync("https://localhost:5001/api/dinner/1");

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy ok
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //getAnotherOneBreakfast
        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        public async Task AnotherGetBreakfast_WithParameter_ReturnsOkResult(string queryParams)
        {
            //arrange

            //act

            var response = await _client.GetAsync("https://localhost:5001/api/breakfast/" + queryParams);

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy ok
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //getAnotherOneSecondBreakfast
        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        public async Task AnotherGetSecondBreakfast_WithParameter_ReturnsOkResult(string queryParams)
        {
            //arrange

            //act

            var response = await _client.GetAsync("https://localhost:5001/api/secondbreakfast/" + queryParams);

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy ok
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //getAnotherOneLunch
        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        public async Task AnotherGetLunch_WithParameter_ReturnsOkResult(string queryParams)
        {
            //arrange

            //act

            var response = await _client.GetAsync("https://localhost:5001/api/lunch/" + queryParams);

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy ok
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //getAnotherOneSnack
        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        public async Task AnotherGetSnack_WithParameter_ReturnsOkResult(string queryParams)
        {
            //arrange

            //act

            var response = await _client.GetAsync("https://localhost:5001/api/snack/" + queryParams);

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy ok
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //getAnotherOneDinner
        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        public async Task AnotherGetDinner_WithParameter_ReturnsOkResult(string queryParams)
        {
            //arrange

            //act

            var response = await _client.GetAsync("https://localhost:5001/api/dinner/" + queryParams);

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy ok
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //getAnotherOneBreakfast
        [Theory]
        [InlineData("100")]
        [InlineData("200")]
        public async Task AnotherGetBreakfast_WithInvalidParameter_ReturnsNotFound(string queryParams)
        {
            //arrange

            //act

            var response = await _client.GetAsync("https://localhost:5001/api/breakfast/" + queryParams);

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy not found
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }

        //getAnotherOneSecondBreakfast
        [Theory]
        [InlineData("100")]
        [InlineData("200")]
        public async Task AnotherGetSecondBreakfast_WithInvalidParameter_ReturnsNotFound(string queryParams)
        {
            //arrange

            //act

            var response = await _client.GetAsync("https://localhost:5001/api/secondbreakfast/" + queryParams);

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy not found
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }

        //getAnotherOneLunch
        [Theory]
        [InlineData("100")]
        [InlineData("200")]
        public async Task AnotherGetLunch_WithInvalidParameter_ReturnsNotFound(string queryParams)
        {
            //arrange

            //act

            var response = await _client.GetAsync("https://localhost:5001/api/lunch/" + queryParams);

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy not found
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }

        //getAnotherOneSnack
        [Theory]
        [InlineData("100")]
        [InlineData("200")]
        public async Task AnotherGetSnack_WithInvalidParameter_ReturnsNotFound(string queryParams)
        {
            //arrange

            //act

            var response = await _client.GetAsync("https://localhost:5001/api/snack/" + queryParams);

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy not found
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }

        //getAnotherOneDinner
        [Theory]
        [InlineData("100")]
        [InlineData("200")]
        public async Task AnotherGetDinner_WithInvalidParameter_ReturnsNotFound(string queryParams)
        {
            //arrange

            //act

            var response = await _client.GetAsync("https://localhost:5001/api/dinner/" + queryParams);

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy not found
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }

        //getAllBreakfast
        [Fact]
        public async Task GetAllBreakfasts_WithParameter_ReturnsOkResult()
        {
            //arrange

            //act

            var response = await _client.GetAsync("https://localhost:5001/api/breakfast");

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy ok
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //getAllSecondBreakfasts
        [Fact]
        public async Task GetAllSecondBreakfasts_WithParameter_ReturnsOkResult()
        {
            //arrange

            //act

            var response = await _client.GetAsync("https://localhost:5001/api/secondbreakfast");

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy ok
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //getAllLunches
        [Fact]
        public async Task GetAllLunches_WithParameter_ReturnsOkResult()
        {
            //arrange

            //act

            var response = await _client.GetAsync("https://localhost:5001/api/lunch");

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy ok
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //getAllSnacks
        [Fact]
        public async Task GetAllSnacks_WithParameter_ReturnsOkResult()
        {
            //arrange

            //act

            var response = await _client.GetAsync("https://localhost:5001/api/snack");

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy ok
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //getAllDinners
        [Fact]
        public async Task GetAllDinners_WithParameter_ReturnsOkResult()
        {
            //arrange

            //act

            var response = await _client.GetAsync("https://localhost:5001/api/dinner");

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy ok
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //createBreakfast
        [Fact]
        public async Task CreateBreakfast_WithValidModel_ReturnsCreated()
        {
            //arrange

            //Tworzymy model, ktory chcemy wysłać na serwer

            var model = new CreateBreakfastDto
            {
                DishId = new int[] { 1 },
                ProductId = new int[] { 1 }
            };

            //Serializujemy model do formatu json
            var json = JsonConvert.SerializeObject(model);

            StringContent httpContent = new(json, Encoding.UTF8, "application/json");

            //act

            //Wysyłamy model na serwer
            var response = await _client.PostAsync("https://localhost:5001/api/createbreakfast", httpContent);

            //assert

            //Sprawdzamy czy status kod z tej odpowiedzi jest równy created
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);

            //Sprawdzamy czy odpowiedź serwera zawiera nagłówek z lokacją
            response.Headers.Location.Should().NotBeNull();
        }

        //createSecondBreakfast
        [Fact]
        public async Task CreateSecondBreakfast_WithValidModel_ReturnsCreated()
        {
            //arrange

            //Tworzymy model, ktory chcemy wysłać na serwer

            var model = new CreateSecondBreakfastDto
            {
                DishId = new int[] { 1 },
                ProductId = new int[] { 1 }
            };

            //Serializujemy model do formatu json
            var json = JsonConvert.SerializeObject(model);

            StringContent httpContent = new(json, Encoding.UTF8, "application/json");

            //act

            //Wysyłamy model na serwer
            var response = await _client.PostAsync("https://localhost:5001/api/createsecondbreakfast", httpContent);

            //assert

            //Sprawdzamy czy status kod z tej odpowiedzi jest równy created
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);

            //Sprawdzamy czy odpowiedź serwera zawiera nagłówek z lokacją
            response.Headers.Location.Should().NotBeNull();
        }

        //createLunch
        [Fact]
        public async Task CreateLunch_WithValidModel_ReturnsCreated()
        {
            //arrange

            //Tworzymy model, ktory chcemy wysłać na serwer

            var model = new CreateLunchDto
            {
                DishId = new int[] { 1 },
                ProductId = new int[] { 1 }
            };

            //Serializujemy model do formatu json
            var json = JsonConvert.SerializeObject(model);

            StringContent httpContent = new(json, Encoding.UTF8, "application/json");

            //act

            //Wysyłamy model na serwer
            var response = await _client.PostAsync("https://localhost:5001/api/createlunch", httpContent);

            //assert

            //Sprawdzamy czy status kod z tej odpowiedzi jest równy created
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);

            //Sprawdzamy czy odpowiedź serwera zawiera nagłówek z lokacją
            response.Headers.Location.Should().NotBeNull();
        }

        //createSnack
        [Fact]
        public async Task CreateSnack_WithValidModel_ReturnsCreated()
        {
            //arrange

            //Tworzymy model, ktory chcemy wysłać na serwer

            var model = new CreateSnackDto
            {
                DishId = new int[] { 1 },
                ProductId = new int[] { 1 }
            };

            //Serializujemy model do formatu json
            var json = JsonConvert.SerializeObject(model);

            StringContent httpContent = new(json, Encoding.UTF8, "application/json");

            //act

            //Wysyłamy model na serwer
            var response = await _client.PostAsync("https://localhost:5001/api/createsnack", httpContent);

            //assert

            //Sprawdzamy czy status kod z tej odpowiedzi jest równy created
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);

            //Sprawdzamy czy odpowiedź serwera zawiera nagłówek z lokacją
            response.Headers.Location.Should().NotBeNull();
        }

        //createDinner
        [Fact]
        public async Task CreateDinner_WithValidModel_ReturnsCreated()
        {
            //arrange

            //Tworzymy model, ktory chcemy wysłać na serwer

            var model = new CreateDinnerDto
            {
                DishId = new int[] { 1 },
                ProductId = new int[] { 1 }
            };

            //Serializujemy model do formatu json
            var json = JsonConvert.SerializeObject(model);

            StringContent httpContent = new(json, Encoding.UTF8, "application/json");

            //act

            //Wysyłamy model na serwer
            var response = await _client.PostAsync("https://localhost:5001/api/createdinner", httpContent);

            //assert

            //Sprawdzamy czy status kod z tej odpowiedzi jest równy created
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);

            //Sprawdzamy czy odpowiedź serwera zawiera nagłówek z lokacją
            response.Headers.Location.Should().NotBeNull();
        }

        //deleteBreakfast
        [Fact]
        public async Task DeleteBreakfast_WithParameter_ReturnsNoContentResult()
        {
            //arrange

            //Tworzymy model, ktory chcemy wysłać na serwer

            var model = new CreateBreakfastDto
            {
                DishId = new int[] { 1 },
                ProductId = new int[] { 1 }
            };

            //Serializujemy model do formatu json
            var json = JsonConvert.SerializeObject(model);

            StringContent httpContent = new(json, Encoding.UTF8, "application/json");

            //Wysyłamy model na serwer
            await _client.PostAsync("https://localhost:5001/api/createbreakfast", httpContent);

            //act

            var response2 = await _client.DeleteAsync("https://localhost:5001/api/breakfast/17");

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy no content
            response2.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);
        }

        //deleteSecondBreakfast
        [Fact]
        public async Task DeleteSecondBreakfast_WithParameter_ReturnsNoContentResult()
        {
            //arrange

            //Tworzymy model, ktory chcemy wysłać na serwer

            var model = new CreateSecondBreakfastDto
            {
                DishId = new int[] { 1 },
                ProductId = new int[] { 1 }
            };

            //Serializujemy model do formatu json
            var json = JsonConvert.SerializeObject(model);

            StringContent httpContent = new(json, Encoding.UTF8, "application/json");

            //Wysyłamy model na serwer
            await _client.PostAsync("https://localhost:5001/api/createsecondbreakfast", httpContent);

            //act

            var response2 = await _client.DeleteAsync("https://localhost:5001/api/secondbreakfast/18");

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy no content
            response2.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);
        }

        //deleteLunch
        [Fact]
        public async Task DeleteLunch_WithParameter_ReturnsNoContentResult()
        {
            //arrange

            //Tworzymy model, ktory chcemy wysłać na serwer

            var model = new CreateLunchDto
            {
                DishId = new int[] { 1 },
                ProductId = new int[] { 1 }
            };

            //Serializujemy model do formatu json
            var json = JsonConvert.SerializeObject(model);

            StringContent httpContent = new(json, Encoding.UTF8, "application/json");

            //Wysyłamy model na serwer
            await _client.PostAsync("https://localhost:5001/api/createlunch", httpContent);

            //act

            var response2 = await _client.DeleteAsync("https://localhost:5001/api/lunch/16");

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy no content
            response2.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);
        }

        //deleteSnack
        [Fact]
        public async Task DeleteSnack_WithParameter_ReturnsNoContentResult()
        {
            //arrange

            //Tworzymy model, ktory chcemy wysłać na serwer

            var model = new CreateSnackDto
            {
                DishId = new int[] { 1 },
                ProductId = new int[] { 1 }
            };

            //Serializujemy model do formatu json
            var json = JsonConvert.SerializeObject(model);

            StringContent httpContent = new(json, Encoding.UTF8, "application/json");

            //Wysyłamy model na serwer
            await _client.PostAsync("https://localhost:5001/api/createsnack", httpContent);

            //act

            var response2 = await _client.DeleteAsync("https://localhost:5001/api/snack/16");

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy no content
            response2.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);
        }

        //deleteDinner
        [Fact]
        public async Task DeleteDinner_WithParameter_ReturnsNoContentResult()
        {
            //arrange

            //Tworzymy model, ktory chcemy wysłać na serwer

            var model = new CreateDinnerDto
            {
                DishId = new int[] { 1 },
                ProductId = new int[] { 1 }
            };

            //Serializujemy model do formatu json
            var json = JsonConvert.SerializeObject(model);

            StringContent httpContent = new(json, Encoding.UTF8, "application/json");

            //Wysyłamy model na serwer
            await _client.PostAsync("https://localhost:5001/api/createdinner", httpContent);

            //act

            var response2 = await _client.DeleteAsync("https://localhost:5001/api/dinner/16");

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy no content
            response2.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);
        }
    }
}
