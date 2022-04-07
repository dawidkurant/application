using FluentAssertions;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Papu;
using Papu.Entities;
using Papu.Models;
using Papu.Models.Update.DayOfTheWeek;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PapuAPI.IntegrationTests
{
    public class DaysOfTheWeekControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        //Konstruktor po to, aby nie tworzyć klienta oddzielnie dla każdego testu
        //jeśli chcemy aby kontekst był współdzielony między testami (czyli obiekt DaysOfTheWeek
        //ControllerTests był stworzony raz, a nie za każdym razem, kiedy uruchamia się test)
        public DaysOfTheWeekControllerTests(WebApplicationFactory<Startup> factory)
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

        //getOneMonday
        [Fact]
        public async Task GetMonday_WithParameter_ReturnsOkResult()
        {
            //arrange

            //act

            var response = await _client.GetAsync("https://localhost:5001/api/monday/1");

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy ok
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //getOneTuesday
        [Fact]
        public async Task GetTuesday_WithParameter_ReturnsOkResult()
        {
            //arrange

            //act

            var response = await _client.GetAsync("https://localhost:5001/api/tuesday/1");

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy ok
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //getOneWednesday
        [Fact]
        public async Task GetWednesday_WithParameter_ReturnsOkResult()
        {
            //arrange

            //act

            var response = await _client.GetAsync("https://localhost:5001/api/wednesday/1");

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy ok
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //getOneThursday
        [Fact]
        public async Task GetThursday_WithParameter_ReturnsOkResult()
        {
            //arrange

            //act

            var response = await _client.GetAsync("https://localhost:5001/api/thursday/1");

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy ok
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //getOneFriday
        [Fact]
        public async Task GetFriday_WithParameter_ReturnsOkResult()
        {
            //arrange

            //act

            var response = await _client.GetAsync("https://localhost:5001/api/friday/1");

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy ok
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //getOneSaturday
        [Fact]
        public async Task GetSaturday_WithParameter_ReturnsOkResult()
        {
            //arrange

            //act

            var response = await _client.GetAsync("https://localhost:5001/api/saturday/1");

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy ok
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //getOneSunday
        [Fact]
        public async Task GetSunday_WithParameter_ReturnsOkResult()
        {
            //arrange

            //act

            var response = await _client.GetAsync("https://localhost:5001/api/sunday/1");

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy ok
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //getAnotherOneMonday
        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        public async Task AnotherGetMonday_WithParameter_ReturnsOkResult(string queryParams)
        {
            //arrange

            //act

            var response = await _client.GetAsync("https://localhost:5001/api/monday/" + queryParams);

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy ok
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //getAnotherOneTuesday
        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        public async Task AnotherGetTuesday_WithParameter_ReturnsOkResult(string queryParams)
        {
            //arrange

            //act

            var response = await _client.GetAsync("https://localhost:5001/api/tuesday/" + queryParams);

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy ok
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //getAnotherOneWednesday
        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        public async Task AnotherGetWednesday_WithParameter_ReturnsOkResult(string queryParams)
        {
            //arrange

            //act

            var response = await _client.GetAsync("https://localhost:5001/api/wednesday/" + queryParams);

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy ok
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //getAnotherOneThursday
        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        public async Task AnotherGetThursday_WithParameter_ReturnsOkResult(string queryParams)
        {
            //arrange

            //act

            var response = await _client.GetAsync("https://localhost:5001/api/thursday/" + queryParams);

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy ok
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //getAnotherOneFriday
        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        public async Task AnotherGetFriday_WithParameter_ReturnsOkResult(string queryParams)
        {
            //arrange

            //act

            var response = await _client.GetAsync("https://localhost:5001/api/friday/" + queryParams);

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy ok
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //getAnotherOneSaturday
        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        public async Task AnotherGetSaturday_WithParameter_ReturnsOkResult(string queryParams)
        {
            //arrange

            //act

            var response = await _client.GetAsync("https://localhost:5001/api/saturday/" + queryParams);

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy ok
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //getAnotherOneSunday
        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        public async Task AnotherGetSunday_WithParameter_ReturnsOkResult(string queryParams)
        {
            //arrange

            //act

            var response = await _client.GetAsync("https://localhost:5001/api/sunday/" + queryParams);

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy ok
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //getAnotherOneMonday
        [Theory]
        [InlineData("100")]
        [InlineData("200")]
        public async Task AnotherGetMonday_WithInvalidParameter_ReturnsNotFound(string queryParams)
        {
            //arrange

            //act

            var response = await _client.GetAsync("https://localhost:5001/api/monday/" + queryParams);

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy not found
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }

        //getAnotherOneTuesday
        [Theory]
        [InlineData("100")]
        [InlineData("200")]
        public async Task AnotherGetTuesday_WithInvalidParameter_ReturnsNotFound(string queryParams)
        {
            //arrange

            //act

            var response = await _client.GetAsync("https://localhost:5001/api/tuesday/" + queryParams);

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy not found
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }

        //getAnotherOneWednesday
        [Theory]
        [InlineData("100")]
        [InlineData("200")]
        public async Task AnotherGetWednesday_WithInvalidParameter_ReturnsNotFound(string queryParams)
        {
            //arrange

            //act

            var response = await _client.GetAsync("https://localhost:5001/api/wednesday/" + queryParams);

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy not found
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }

        //getAnotherOneThursday
        [Theory]
        [InlineData("100")]
        [InlineData("200")]
        public async Task AnotherGetThursday_WithInvalidParameter_ReturnsNotFound(string queryParams)
        {
            //arrange

            //act

            var response = await _client.GetAsync("https://localhost:5001/api/thursday/" + queryParams);

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy not found
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }

        //getAnotherOneFriday
        [Theory]
        [InlineData("100")]
        [InlineData("200")]
        public async Task AnotherGetFriday_WithInvalidParameter_ReturnsNotFound(string queryParams)
        {
            //arrange

            //act

            var response = await _client.GetAsync("https://localhost:5001/api/friday/" + queryParams);

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy not found
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }

        //getAnotherOneSaturday
        [Theory]
        [InlineData("100")]
        [InlineData("200")]
        public async Task AnotherGetSaturday_WithInvalidParameter_ReturnsNotFound(string queryParams)
        {
            //arrange

            //act

            var response = await _client.GetAsync("https://localhost:5001/api/saturday/" + queryParams);

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy not found
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }

        //getAnotherOneSunday
        [Theory]
        [InlineData("100")]
        [InlineData("200")]
        public async Task AnotherGetSunday_WithInvalidParameter_ReturnsNotFound(string queryParams)
        {
            //arrange

            //act

            var response = await _client.GetAsync("https://localhost:5001/api/sunday/" + queryParams);

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy not found
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }

        //getAllMondays
        [Fact]
        public async Task GetAllMondays_WithParameter_ReturnsOkResult()
        {
            //arrange

            //act

            var response = await _client.GetAsync("https://localhost:5001/api/monday");

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy ok
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //getAllTuesdays
        [Fact]
        public async Task GetAllTuesdays_WithParameter_ReturnsOkResult()
        {
            //arrange

            //act

            var response = await _client.GetAsync("https://localhost:5001/api/tuesday");

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy ok
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //getAllWednesdays
        [Fact]
        public async Task GetAllWednesdays_WithParameter_ReturnsOkResult()
        {
            //arrange

            //act

            var response = await _client.GetAsync("https://localhost:5001/api/wednesday");

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy ok
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //getAllThursdays
        [Fact]
        public async Task GetAllThursdays_WithParameter_ReturnsOkResult()
        {
            //arrange

            //act

            var response = await _client.GetAsync("https://localhost:5001/api/thursday");

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy ok
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //getAllFridays
        [Fact]
        public async Task GetAllFridays_WithParameter_ReturnsOkResult()
        {
            //arrange

            //act

            var response = await _client.GetAsync("https://localhost:5001/api/friday");

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy ok
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //getAllSaturdays
        [Fact]
        public async Task GetAllSaturdays_WithParameter_ReturnsOkResult()
        {
            //arrange

            //act

            var response = await _client.GetAsync("https://localhost:5001/api/saturday");

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy ok
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //getAllSundays
        [Fact]
        public async Task GetAllSundays_WithParameter_ReturnsOkResult()
        {
            //arrange

            //act

            var response = await _client.GetAsync("https://localhost:5001/api/sunday");

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy ok
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //createMonday
        [Fact]
        public async Task CreateMonday_WithValidModel_ReturnsCreated()
        {
            //arrange

            //Tworzymy model, ktory chcemy wysłać na serwer

            var model = new CreateMondayDto
            {
                BreakfastMondayId = 1,
                SecondBreakfastMondayId = 1
            };

            //Serializujemy model do formatu json
            var json = JsonConvert.SerializeObject(model);

            StringContent httpContent = new(json, Encoding.UTF8, "application/json");

            //act

            //Wysyłamy model na serwer
            var response = await _client.PostAsync("https://localhost:5001/api/createmonday", httpContent);

            //assert

            //Sprawdzamy czy status kod z tej odpowiedzi jest równy created
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);

            //Sprawdzamy czy odpowiedź serwera zawiera nagłówek z lokacją
            response.Headers.Location.Should().NotBeNull();
        }

        //createTuesday
        [Fact]
        public async Task CreateTuesday_WithValidModel_ReturnsCreated()
        {
            //arrange

            //Tworzymy model, ktory chcemy wysłać na serwer

            var model = new CreateTuesdayDto
            {
                BreakfastTuesdayId = 1,
                SecondBreakfastTuesdayId = 1
            };

            //Serializujemy model do formatu json
            var json = JsonConvert.SerializeObject(model);

            StringContent httpContent = new(json, Encoding.UTF8, "application/json");

            //act

            //Wysyłamy model na serwer
            var response = await _client.PostAsync("https://localhost:5001/api/createtuesday", httpContent);

            //assert

            //Sprawdzamy czy status kod z tej odpowiedzi jest równy created
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);

            //Sprawdzamy czy odpowiedź serwera zawiera nagłówek z lokacją
            response.Headers.Location.Should().NotBeNull();
        }

        //createWednesday
        [Fact]
        public async Task CreateWednesday_WithValidModel_ReturnsCreated()
        {
            //arrange

            //Tworzymy model, ktory chcemy wysłać na serwer

            var model = new CreateWednesdayDto
            {
                BreakfastWednesdayId = 1,
                SecondBreakfastWednesdayId = 1
            };

            //Serializujemy model do formatu json
            var json = JsonConvert.SerializeObject(model);

            StringContent httpContent = new(json, Encoding.UTF8, "application/json");

            //act

            //Wysyłamy model na serwer
            var response = await _client.PostAsync("https://localhost:5001/api/createwednesday", httpContent);

            //assert

            //Sprawdzamy czy status kod z tej odpowiedzi jest równy created
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);

            //Sprawdzamy czy odpowiedź serwera zawiera nagłówek z lokacją
            response.Headers.Location.Should().NotBeNull();
        }

        //createThursday
        [Fact]
        public async Task CreateThursday_WithValidModel_ReturnsCreated()
        {
            //arrange

            //Tworzymy model, ktory chcemy wysłać na serwer

            var model = new CreateThursdayDto
            {
                BreakfastThursdayId = 1,
                SecondBreakfastThursdayId = 1
            };

            //Serializujemy model do formatu json
            var json = JsonConvert.SerializeObject(model);

            StringContent httpContent = new(json, Encoding.UTF8, "application/json");

            //act

            //Wysyłamy model na serwer
            var response = await _client.PostAsync("https://localhost:5001/api/createthursday", httpContent);

            //assert

            //Sprawdzamy czy status kod z tej odpowiedzi jest równy created
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);

            //Sprawdzamy czy odpowiedź serwera zawiera nagłówek z lokacją
            response.Headers.Location.Should().NotBeNull();
        }

        //createFriday
        [Fact]
        public async Task CreateFriday_WithValidModel_ReturnsCreated()
        {
            //arrange

            //Tworzymy model, ktory chcemy wysłać na serwer

            var model = new CreateFridayDto
            {
                BreakfastFridayId = 1,
                SecondBreakfastFridayId = 1
            };

            //Serializujemy model do formatu json
            var json = JsonConvert.SerializeObject(model);

            StringContent httpContent = new(json, Encoding.UTF8, "application/json");

            //act

            //Wysyłamy model na serwer
            var response = await _client.PostAsync("https://localhost:5001/api/createfriday", httpContent);

            //assert

            //Sprawdzamy czy status kod z tej odpowiedzi jest równy created
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);

            //Sprawdzamy czy odpowiedź serwera zawiera nagłówek z lokacją
            response.Headers.Location.Should().NotBeNull();
        }

        //createSaturday
        [Fact]
        public async Task CreateSaturday_WithValidModel_ReturnsCreated()
        {
            //arrange

            //Tworzymy model, ktory chcemy wysłać na serwer

            var model = new CreateSaturdayDto
            {
                BreakfastSaturdayId = 1,
                SecondBreakfastSaturdayId = 1
            };

            //Serializujemy model do formatu json
            var json = JsonConvert.SerializeObject(model);

            StringContent httpContent = new(json, Encoding.UTF8, "application/json");

            //act

            //Wysyłamy model na serwer
            var response = await _client.PostAsync("https://localhost:5001/api/createsaturday", httpContent);

            //assert

            //Sprawdzamy czy status kod z tej odpowiedzi jest równy created
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);

            //Sprawdzamy czy odpowiedź serwera zawiera nagłówek z lokacją
            response.Headers.Location.Should().NotBeNull();
        }

        //createSunday
        [Fact]
        public async Task CreateSunday_WithValidModel_ReturnsCreated()
        {
            //arrange

            //Tworzymy model, ktory chcemy wysłać na serwer

            var model = new CreateSundayDto
            {
                BreakfastSundayId = 1,
                SecondBreakfastSundayId = 1
            };

            //Serializujemy model do formatu json
            var json = JsonConvert.SerializeObject(model);

            StringContent httpContent = new(json, Encoding.UTF8, "application/json");

            //act

            //Wysyłamy model na serwer
            var response = await _client.PostAsync("https://localhost:5001/api/createsunday", httpContent);

            //assert

            //Sprawdzamy czy status kod z tej odpowiedzi jest równy created
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);

            //Sprawdzamy czy odpowiedź serwera zawiera nagłówek z lokacją
            response.Headers.Location.Should().NotBeNull();
        }

        //updateMonday
        [Fact]
        public async Task UpdateMonday_WithValidModel_ReturnsOKResult()
        {
            //arrange

            //Tworzymy model, ktory chcemy edytować i wysłać na serwer

            var model = new CreateMondayDto
            {
                BreakfastMondayId = 1,
                SecondBreakfastMondayId = 1
            };

            //Serializujemy model do formatu json
            var json = JsonConvert.SerializeObject(model);

            StringContent httpContent = new(json, Encoding.UTF8, "application/json");

            //Wysyłamy model na serwer
            await _client.PostAsync("https://localhost:5001/api/createmonday", httpContent);

            //Edytujemy model

            var modelUpdated = new UpdateMondayDto
            {
                BreakfastMondayId = 1,
                SecondBreakfastMondayId = 1
            };

            //Serializujemy model do formatu json
            var json2 = JsonConvert.SerializeObject(modelUpdated);

            StringContent httpContent2 = new(json2, Encoding.UTF8, "application/json");

            //act

            var response2 = await _client.PutAsync("https://localhost:5001/api/monday/4", httpContent2);

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy OK
            response2.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //updateTuesday
        [Fact]
        public async Task UpdateTuesday_WithValidModel_ReturnsOKResult()
        {
            //arrange

            //Tworzymy model, ktory chcemy edytować i wysłać na serwer

            var model = new CreateTuesdayDto
            {
                BreakfastTuesdayId = 1,
                SecondBreakfastTuesdayId = 1
            };

            //Serializujemy model do formatu json
            var json = JsonConvert.SerializeObject(model);

            StringContent httpContent = new(json, Encoding.UTF8, "application/json");

            //Wysyłamy model na serwer
            await _client.PostAsync("https://localhost:5001/api/createtuesday", httpContent);

            //Edytujemy model

            var modelUpdated = new UpdateTuesdayDto
            {
                BreakfastTuesdayId = 1,
                SecondBreakfastTuesdayId = 1
            };

            //Serializujemy model do formatu json
            var json2 = JsonConvert.SerializeObject(modelUpdated);

            StringContent httpContent2 = new(json2, Encoding.UTF8, "application/json");

            //act

            var response2 = await _client.PutAsync("https://localhost:5001/api/tuesday/3", httpContent2);

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy OK
            response2.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //updateWednesday
        [Fact]
        public async Task UpdateWednesday_WithValidModel_ReturnsOKResult()
        {
            //arrange

            //Tworzymy model, ktory chcemy edytować i wysłać na serwer

            var model = new CreateWednesdayDto
            {
                BreakfastWednesdayId = 1,
                SecondBreakfastWednesdayId = 1
            };

            //Serializujemy model do formatu json
            var json = JsonConvert.SerializeObject(model);

            StringContent httpContent = new(json, Encoding.UTF8, "application/json");

            //Wysyłamy model na serwer
            await _client.PostAsync("https://localhost:5001/api/createwednesday", httpContent);

            //Edytujemy model

            var modelUpdated = new UpdateWednesdayDto
            {
                BreakfastWednesdayId = 1,
                SecondBreakfastWednesdayId = 1
            };

            //Serializujemy model do formatu json
            var json2 = JsonConvert.SerializeObject(modelUpdated);

            StringContent httpContent2 = new(json2, Encoding.UTF8, "application/json");

            //act

            var response2 = await _client.PutAsync("https://localhost:5001/api/wednesday/4", httpContent2);

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy OK
            response2.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //updateThursday
        [Fact]
        public async Task UpdateThursday_WithValidModel_ReturnsOKResult()
        {
            //arrange

            //Tworzymy model, ktory chcemy edytować i wysłać na serwer

            var model = new CreateThursdayDto
            {
                BreakfastThursdayId = 1,
                SecondBreakfastThursdayId = 1
            };

            //Serializujemy model do formatu json
            var json = JsonConvert.SerializeObject(model);

            StringContent httpContent = new(json, Encoding.UTF8, "application/json");

            //Wysyłamy model na serwer
            await _client.PostAsync("https://localhost:5001/api/createthursday", httpContent);

            //Edytujemy model

            var modelUpdated = new UpdateThursdayDto
            {
                BreakfastThursdayId = 1,
                SecondBreakfastThursdayId = 1
            };

            //Serializujemy model do formatu json
            var json2 = JsonConvert.SerializeObject(modelUpdated);

            StringContent httpContent2 = new(json2, Encoding.UTF8, "application/json");

            //act

            var response2 = await _client.PutAsync("https://localhost:5001/api/thursday/3", httpContent2);

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy OK
            response2.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //updateFriday
        [Fact]
        public async Task UpdateFriday_WithValidModel_ReturnsOKResult()
        {
            //arrange

            //Tworzymy model, ktory chcemy edytować i wysłać na serwer

            var model = new CreateFridayDto
            {
                BreakfastFridayId = 1,
                SecondBreakfastFridayId = 1
            };

            //Serializujemy model do formatu json
            var json = JsonConvert.SerializeObject(model);

            StringContent httpContent = new(json, Encoding.UTF8, "application/json");

            //Wysyłamy model na serwer
            await _client.PostAsync("https://localhost:5001/api/createfriday", httpContent);

            //Edytujemy model

            var modelUpdated = new UpdateFridayDto
            {
                BreakfastFridayId = 1,
                SecondBreakfastFridayId = 1
            };

            //Serializujemy model do formatu json
            var json2 = JsonConvert.SerializeObject(modelUpdated);

            StringContent httpContent2 = new(json2, Encoding.UTF8, "application/json");

            //act

            var response2 = await _client.PutAsync("https://localhost:5001/api/friday/3", httpContent2);

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy OK
            response2.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //updateSaturday
        [Fact]
        public async Task UpdateSaturday_WithValidModel_ReturnsOKResult()
        {
            //arrange

            //Tworzymy model, ktory chcemy edytować i wysłać na serwer

            var model = new CreateSaturdayDto
            {
                BreakfastSaturdayId = 1,
                SecondBreakfastSaturdayId = 1
            };

            //Serializujemy model do formatu json
            var json = JsonConvert.SerializeObject(model);

            StringContent httpContent = new(json, Encoding.UTF8, "application/json");

            //Wysyłamy model na serwer
            await _client.PostAsync("https://localhost:5001/api/createsaturday", httpContent);

            //Edytujemy model

            var modelUpdated = new UpdateSaturdayDto
            {
                BreakfastSaturdayId = 1,
                SecondBreakfastSaturdayId = 1
            };

            //Serializujemy model do formatu json
            var json2 = JsonConvert.SerializeObject(modelUpdated);

            StringContent httpContent2 = new(json2, Encoding.UTF8, "application/json");

            //act

            var response2 = await _client.PutAsync("https://localhost:5001/api/saturday/4", httpContent2);

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy OK
            response2.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //updateSunday
        [Fact]
        public async Task UpdateSunday_WithValidModel_ReturnsOKResult()
        {
            //arrange

            //Tworzymy model, ktory chcemy edytować i wysłać na serwer

            var model = new CreateSundayDto
            {
                BreakfastSundayId = 1,
                SecondBreakfastSundayId = 1
            };

            //Serializujemy model do formatu json
            var json = JsonConvert.SerializeObject(model);

            StringContent httpContent = new(json, Encoding.UTF8, "application/json");

            //Wysyłamy model na serwer
            await _client.PostAsync("https://localhost:5001/api/createsunday", httpContent);

            //Edytujemy model

            var modelUpdated = new UpdateSundayDto
            {
                BreakfastSundayId = 1,
                SecondBreakfastSundayId = 1
            };

            //Serializujemy model do formatu json
            var json2 = JsonConvert.SerializeObject(modelUpdated);

            StringContent httpContent2 = new(json2, Encoding.UTF8, "application/json");

            //act

            var response2 = await _client.PutAsync("https://localhost:5001/api/sunday/4", httpContent2);

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy OK
            response2.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //updateAnotherMonday
        [Fact]
        public async Task UpdateMonday_WithInvalidModel_ReturnsMethodNotAllowedResult()
        {
            //arrange

            //Tworzymy model, ktory chcemy edytować i wysłać na serwer

            var model = new UpdateMondayDto
            {
                BreakfastMondayId = 1 ,
                SecondBreakfastMondayId = 1
            };

            //Serializujemy model do formatu json
            var json = JsonConvert.SerializeObject(model);

            StringContent httpContent = new(json, Encoding.UTF8, "application/json");

            //act

            var response = await _client.PatchAsync("https://localhost:5001/api/monday/1", httpContent);

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy method not allowed
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.MethodNotAllowed);
        }

        //updateAnotherTuesday
        [Fact]
        public async Task UpdateTuesday_WithInvalidModel_ReturnsMethodNotAllowedResult()
        {
            //arrange

            //Tworzymy model, ktory chcemy edytować i wysłać na serwer

            var model = new UpdateTuesdayDto
            {
                BreakfastTuesdayId = 1,
                SecondBreakfastTuesdayId = 1
            };

            //Serializujemy model do formatu json
            var json = JsonConvert.SerializeObject(model);

            StringContent httpContent = new(json, Encoding.UTF8, "application/json");

            //act

            var response = await _client.PatchAsync("https://localhost:5001/api/tuesday/1", httpContent);

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy method not allowed
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.MethodNotAllowed);
        }

        //updateAnotherWednesday
        [Fact]
        public async Task UpdateWednesday_WithInvalidModel_ReturnsMethodNotAllowedResult()
        {
            //arrange

            //Tworzymy model, ktory chcemy edytować i wysłać na serwer

            var model = new UpdateWednesdayDto
            {
                BreakfastWednesdayId = 1,
                SecondBreakfastWednesdayId = 1
            };

            //Serializujemy model do formatu json
            var json = JsonConvert.SerializeObject(model);

            StringContent httpContent = new(json, Encoding.UTF8, "application/json");

            //act

            var response = await _client.PatchAsync("https://localhost:5001/api/wednesday/1", httpContent);

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy method not allowed
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.MethodNotAllowed);
        }

        //updateAnotherThursday
        [Fact]
        public async Task UpdateThursday_WithInvalidModel_ReturnsMethodNotAllowedResult()
        {
            //arrange

            //Tworzymy model, ktory chcemy edytować i wysłać na serwer

            var model = new UpdateThursdayDto
            {
                BreakfastThursdayId = 1,
                SecondBreakfastThursdayId = 1
            };

            //Serializujemy model do formatu json
            var json = JsonConvert.SerializeObject(model);

            StringContent httpContent = new(json, Encoding.UTF8, "application/json");

            //act

            var response = await _client.PatchAsync("https://localhost:5001/api/thursday/1", httpContent);

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy method not allowed
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.MethodNotAllowed);
        }

        //updateAnotherFriday
        [Fact]
        public async Task UpdateFriday_WithInvalidModel_ReturnsMethodNotAllowedResult()
        {
            //arrange

            //Tworzymy model, ktory chcemy edytować i wysłać na serwer

            var model = new UpdateFridayDto
            {
                BreakfastFridayId = 1,
                SecondBreakfastFridayId = 1
            };

            //Serializujemy model do formatu json
            var json = JsonConvert.SerializeObject(model);

            StringContent httpContent = new(json, Encoding.UTF8, "application/json");

            //act

            var response = await _client.PatchAsync("https://localhost:5001/api/friday/1", httpContent);

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy method not allowed
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.MethodNotAllowed);
        }

        //updateAnotherSaturday
        [Fact]
        public async Task UpdateSaturday_WithInvalidModel_ReturnsMethodNotAllowedResult()
        {
            //arrange

            //Tworzymy model, ktory chcemy edytować i wysłać na serwer

            var model = new UpdateSaturdayDto
            {
                BreakfastSaturdayId = 1,
                SecondBreakfastSaturdayId = 1
            };

            //Serializujemy model do formatu json
            var json = JsonConvert.SerializeObject(model);

            StringContent httpContent = new(json, Encoding.UTF8, "application/json");

            //act

            var response = await _client.PatchAsync("https://localhost:5001/api/saturday/1", httpContent);

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy method not allowed
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.MethodNotAllowed);
        }

        //updateAnotherSunday
        [Fact]
        public async Task UpdateSunday_WithInvalidModel_ReturnsMethodNotAllowedResult()
        {
            //arrange

            //Tworzymy model, ktory chcemy edytować i wysłać na serwer

            var model = new UpdateSundayDto
            {
                BreakfastSundayId = 1,
                SecondBreakfastSundayId = 1
            };

            //Serializujemy model do formatu json
            var json = JsonConvert.SerializeObject(model);

            StringContent httpContent = new(json, Encoding.UTF8, "application/json");

            //act

            var response = await _client.PatchAsync("https://localhost:5001/api/sunday/1", httpContent);

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy method not allowed
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.MethodNotAllowed);
        }

        //deleteMonday
        [Fact]
        public async Task DeleteMonday_WithParameter_ReturnsNoContentResult()
        {
            //arrange

            //Tworzymy model, ktory chcemy wysłać na serwer

            var model = new CreateMondayDto
            {
                BreakfastMondayId = 1,
                SecondBreakfastMondayId = 1
            };

            //Serializujemy model do formatu json
            var json = JsonConvert.SerializeObject(model);

            StringContent httpContent = new(json, Encoding.UTF8, "application/json");

            //Wysyłamy model na serwer
            await _client.PostAsync("https://localhost:5001/api/createmonday", httpContent);

            //act

            var response2 = await _client.DeleteAsync("https://localhost:5001/api/monday/3");

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy no content
            response2.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);
        }

        //deleteTuesday
        [Fact]
        public async Task DeleteTuesday_WithParameter_ReturnsNoContentResult()
        {
            //arrange

            //Tworzymy model, ktory chcemy wysłać na serwer

            var model = new CreateTuesdayDto
            {
                BreakfastTuesdayId = 1,
                SecondBreakfastTuesdayId = 1
            };

            //Serializujemy model do formatu json
            var json = JsonConvert.SerializeObject(model);

            StringContent httpContent = new(json, Encoding.UTF8, "application/json");

            //Wysyłamy model na serwer
            await _client.PostAsync("https://localhost:5001/api/createtuesday", httpContent);

            //act

            var response2 = await _client.DeleteAsync("https://localhost:5001/api/tuesday/3");

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy no content
            response2.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);
        }

        //deleteWednesday
        [Fact]
        public async Task DeleteWednesday_WithParameter_ReturnsNoContentResult()
        {
            //arrange

            //Tworzymy model, ktory chcemy wysłać na serwer

            var model = new CreateWednesdayDto
            {
                BreakfastWednesdayId = 1,
                SecondBreakfastWednesdayId = 1
            };

            //Serializujemy model do formatu json
            var json = JsonConvert.SerializeObject(model);

            StringContent httpContent = new(json, Encoding.UTF8, "application/json");

            //Wysyłamy model na serwer
            await _client.PostAsync("https://localhost:5001/api/createwednesday", httpContent);

            //act

            var response2 = await _client.DeleteAsync("https://localhost:5001/api/wednesday/3");

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy no content
            response2.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);
        }

        //deleteThursday
        [Fact]
        public async Task DeleteThursday_WithParameter_ReturnsNoContentResult()
        {
            //arrange

            //Tworzymy model, ktory chcemy wysłać na serwer

            var model = new CreateThursdayDto
            {
                BreakfastThursdayId = 1,
                SecondBreakfastThursdayId = 1
            };

            //Serializujemy model do formatu json
            var json = JsonConvert.SerializeObject(model);

            StringContent httpContent = new(json, Encoding.UTF8, "application/json");

            //Wysyłamy model na serwer
            await _client.PostAsync("https://localhost:5001/api/createthursday", httpContent);

            //act

            var response2 = await _client.DeleteAsync("https://localhost:5001/api/thursday/3");

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy no content
            response2.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);
        }

        //deleteFriday
        [Fact]
        public async Task DeleteFriday_WithParameter_ReturnsNoContentResult()
        {
            //arrange

            //Tworzymy model, ktory chcemy wysłać na serwer

            var model = new CreateFridayDto
            {
                BreakfastFridayId = 1,
                SecondBreakfastFridayId = 1
            };

            //Serializujemy model do formatu json
            var json = JsonConvert.SerializeObject(model);

            StringContent httpContent = new(json, Encoding.UTF8, "application/json");

            //Wysyłamy model na serwer
            await _client.PostAsync("https://localhost:5001/api/createfriday", httpContent);

            //act

            var response2 = await _client.DeleteAsync("https://localhost:5001/api/friday/3");

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy no content
            response2.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);
        }

        //deleteSaturday
        [Fact]
        public async Task DeleteSaturday_WithParameter_ReturnsNoContentResult()
        {
            //arrange

            //Tworzymy model, ktory chcemy wysłać na serwer

            var model = new CreateSaturdayDto
            {
                BreakfastSaturdayId = 1,
                SecondBreakfastSaturdayId = 1
            };

            //Serializujemy model do formatu json
            var json = JsonConvert.SerializeObject(model);

            StringContent httpContent = new(json, Encoding.UTF8, "application/json");

            //Wysyłamy model na serwer
            await _client.PostAsync("https://localhost:5001/api/createsaturday", httpContent);

            //act

            var response2 = await _client.DeleteAsync("https://localhost:5001/api/saturday/3");

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy no content
            response2.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);
        }

        //deleteSunday
        [Fact]
        public async Task DeleteSunday_WithParameter_ReturnsNoContentResult()
        {
            //arrange

            //Tworzymy model, ktory chcemy wysłać na serwer

            var model = new CreateSundayDto
            {
                BreakfastSundayId = 1,
                SecondBreakfastSundayId = 1
            };

            //Serializujemy model do formatu json
            var json = JsonConvert.SerializeObject(model);

            StringContent httpContent = new(json, Encoding.UTF8, "application/json");

            //Wysyłamy model na serwer
            await _client.PostAsync("https://localhost:5001/api/createsunday", httpContent);

            //act

            var response2 = await _client.DeleteAsync("https://localhost:5001/api/sunday/3");

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy no content
            response2.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);
        }

        //deleteAnotherMonday
        [Fact]
        public async Task DeleteMonday_WithParameter_ReturnsForbiddenResult()
        {
            //arrange

            //act

            var response = await _client.DeleteAsync("https://localhost:5001/api/monday/2");

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy no content
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Forbidden);
        }

        //deleteAnotherTuesday
        [Fact]
        public async Task DeleteTuesday_WithParameter_ReturnsForbiddenResult()
        {
            //arrange

            //act

            var response = await _client.DeleteAsync("https://localhost:5001/api/tuesday/2");

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy no content
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Forbidden);
        }

        //deleteAnotherWednesday
        [Fact]
        public async Task DeleteWednesday_WithParameter_ReturnsForbiddenResult()
        {
            //arrange

            //act

            var response = await _client.DeleteAsync("https://localhost:5001/api/wednesday/2");

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy no content
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Forbidden);
        }

        //deleteAnotherThursday
        [Fact]
        public async Task DeleteThursday_WithParameter_ReturnsForbiddenResult()
        {
            //arrange

            //act

            var response = await _client.DeleteAsync("https://localhost:5001/api/thursday/2");

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy no content
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Forbidden);
        }

        //deleteAnotherFriday
        [Fact]
        public async Task DeleteFriday_WithParameter_ReturnsForbiddenResult()
        {
            //arrange

            //act

            var response = await _client.DeleteAsync("https://localhost:5001/api/friday/2");

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy no content
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Forbidden);
        }

        //deleteAnotherSaturday
        [Fact]
        public async Task DeleteSaturday_WithParameter_ReturnsForbiddenResult()
        {
            //arrange

            //act

            var response = await _client.DeleteAsync("https://localhost:5001/api/saturday/2");

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy no content
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Forbidden);
        }

        //deleteAnotherSunday
        [Fact]
        public async Task DeleteSunday_WithParameter_ReturnsForbiddenResult()
        {
            //arrange

            //act

            var response = await _client.DeleteAsync("https://localhost:5001/api/sunday/2");

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy no content
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Forbidden);
        }


    }
}
