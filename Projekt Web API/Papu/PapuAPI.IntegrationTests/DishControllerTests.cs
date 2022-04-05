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
    public class DishControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        //Konstruktor po to, aby nie tworzyć klienta oddzielnie dla każdego testu
        //jeśli chcemy aby kontekst był współdzielony między testami (czyli obiekt Dish
        //ControllerTests był stworzony raz, a nie za każdym razem, kiedy uruchamia się test)
        public DishControllerTests(WebApplicationFactory<Startup> factory)
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
        [InlineData("77")]
        [InlineData("73")]
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
        [InlineData("1000")]
        [InlineData("2000")]
        public async Task AnotherGetDish_WithInvalidParameter_ReturnsNotFound(string queryParams)
        {
            //arrange

            //act

            var response = await _client.GetAsync("https://localhost:5001/api/dish/" + queryParams);

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy not found
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }

        //getAllDishes
        [Fact]
        public async Task GetAllDishes_WithParameter_ReturnsOkResult()
        {
            //arrange

            //act

            var response = await _client.GetAsync("https://localhost:5001/api/dish");

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy ok
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //createDish
        [Fact]
        public async Task CreateDish_WithValidModel_ReturnsCreated()
        {
            //arrange

            //Tworzymy model, ktory chcemy wysłać na serwer

            var model = new CreateDishDto
            {
                DishName = "PotrawaTestowa",
                DishDescription = "PrzykładowyOpis",
                DishImagePath = "PrzykładowyLink",
                MethodOfPeparation = "PrzykładowaMetoda",
                PreparationTime = 1,
                Portions = 2,
                Size = 1,
                TypeId = new int[] { 1 },
                KindOfId = new int[] { 1 }
            };

            //Serializujemy model do formatu json
            var json = JsonConvert.SerializeObject(model);

            StringContent httpContent = new(json, Encoding.UTF8, "application/json");

            //act

            //Wysyłamy model na serwer
            var response = await _client.PostAsync("https://localhost:5001/api/dish", httpContent);

            //assert

            //Sprawdzamy czy status kod z tej odpowiedzi jest równy created
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);

            //Sprawdzamy czy odpowiedź serwera zawiera nagłówek z lokacją
            response.Headers.Location.Should().NotBeNull();
        }

        //createAnotherDish
        [Fact]
        public async Task CreateAnotherDish_WithInvalidModel_ReturnsBadRequest()
        {
            //arrange

            //Tworzymy model, ktory chcemy wysłać na serwer

            var model = new CreateDishDto
            {
                KindOfId = new int[] { 1 },
                Portions = 200
            };

            //Serializujemy model do formatu json
            var json = JsonConvert.SerializeObject(model);

            StringContent httpContent = new(json, Encoding.UTF8, "application/json");

            //act

            //Wysyłamy model na serwer
            var response = await _client.PostAsync("https://localhost:5001/api/dish", httpContent);

            //assert

            //Sprawdzamy czy status kod z tej odpowiedzi jest równy created
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);

            //Sprawdzamy czy odpowiedź serwera zawiera nagłówek z lokacją
            response.Headers.Location.Should().BeNull();
        }

        //deleteDish
        [Fact]
        public async Task DeleteDish_WithParameter_ReturnsNoContentResult()
        {
            //arrange

            //Tworzymy model, ktory chcemy wysłać na serwer

            var model = new CreateDishDto
            {
                DishName = "NazwaTestowa",
                DishDescription = "PrzykładowyOpis",
                DishImagePath = "LinkTestowy"
            };

            //Serializujemy model do formatu json
            var json = JsonConvert.SerializeObject(model);

            StringContent httpContent = new(json, Encoding.UTF8, "application/json");

            //Wysyłamy model na serwer
            await _client.PostAsync("https://localhost:5001/api/dish", httpContent);

            //act

            var response2 = await _client.DeleteAsync("https://localhost:5001/api/dish/145");

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy no content
            response2.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);
        }

        //deleteAnotherDish
        [Fact]
        public async Task DeleteDish_WithParameter_ReturnsForbiddenResult()
        {
            //arrange

            //act

            var response = await _client.DeleteAsync("https://localhost:5001/api/dish/71");

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy no content
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Forbidden);
        }
    }
}
