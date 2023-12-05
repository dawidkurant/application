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
    public class ProductControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        // Konstruktor po to, aby nie tworzyć klienta oddzielnie dla każdego testu
        // jeśli chcemy aby kontekst był współdzielony między testami (czyli obiekt Product
        // ControllerTests był stworzony raz, a nie za każdym razem, kiedy uruchamia się test)
        public ProductControllerTests(WebApplicationFactory<Startup> factory)
        {
            // Tutaj chcemy uruchomić nasze Api po to abyśmy byli w stanie wysłać zapytanie http jakimś
            // klientem http z kodu należy dodać zależność, aby startup działał
            // Wykorzystujemy fabrykę aby zwróciła nam odpowiedniego klienta http
            // z pomocą klienta odwołujemy się do metod z naszego api
            _client = factory
                // Umożliwia nam modyfikację wbudowanego webhosta, aby podczas testów nie korzystać z bazy danych sql
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        // Szukamy zarejestrowanego już serwisu dla istniejących opcji dbcontext
                        var dbContextOptions = services
                        .SingleOrDefault(service => service.ServiceType == typeof(DbContextOptions<PapuDbContext>));

                        services.Remove(dbContextOptions);

                        services.AddDbContext<PapuDbContext>(options => options.UseInMemoryDatabase("PapuDb"));

                        // Rejestrujemy żeby uniknąć autentykacji podczas testów
                        services.AddSingleton<IPolicyEvaluator, FakePolicyEvaluator>();
                        services.AddMvc(option => option.Filters.Add(new FakeUserFilter()));
                    });
                })
                .CreateClient();
        }

        // getOneProduct
        [Fact]
        public async Task GetProduct_WithParameter_ReturnsOkResult()
        {
            // arrange

            // act

            var response = await _client.GetAsync("https://localhost:5001/api/product/1");

            // assert

            // sprawdzamy czy status kod z tej odpowiedzi jest równy ok
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        // getAnotherOneProduct
        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        public async Task AnotherGetProduct_WithParameter_ReturnsOkResult(string queryParams)
        {
            // arrange

            // act

            var response = await _client.GetAsync($"https://localhost:5001/api/product/{queryParams}");

            // assert

            // sprawdzamy czy status kod z tej odpowiedzi jest równy ok
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        // getAnotherOneProduct
        [Theory]
        [InlineData("1000")]
        [InlineData("2000")]
        public async Task AnotherGetProduct_WithInvalidParameter_ReturnsNotFound(string queryParams)
        {
            // arrange

            // act

            var response = await _client.GetAsync("https://localhost:5001/api/product/" + queryParams);

            // assert

            // Sprawdzamy czy status kod z tej odpowiedzi jest równy not found
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }

        // getAllProducts
        [Fact]
        public async Task GetAllProducts_WithParameter_ReturnsOkResult()
        {
            // arrange

            // act

            var response = await _client.GetAsync("https://localhost:5001/api/product");

            // assert

            // sprawdzamy czy status kod z tej odpowiedzi jest równy ok
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        // createProduct
        [Fact]
        public async Task CreateProduct_WithValidModel_ReturnsCreated()
        {
            // arrange

            // Tworzymy model, ktory chcemy wysłać na serwer

            var model = new CreateProductDto
            {
                ProductName = "NazwaTestowa",
                GroupId = new int[] { 1 },
                Weight = 200
            };

            // Serializujemy model do formatu json
            var json = JsonConvert.SerializeObject(model);

            StringContent httpContent = new(json, Encoding.UTF8, "application/json");

            // act

            // Wysyłamy model na serwer
            var response = await _client.PostAsync("https://localhost:5001/api/product", httpContent);

            // assert

            // Sprawdzamy czy status kod z tej odpowiedzi jest równy created
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);

            // Sprawdzamy czy odpowiedź serwera zawiera nagłówek z lokacją
            response.Headers.Location.Should().NotBeNull();
        }

        // createAnotherProduct
        [Fact]
        public async Task CreateAnotherProduct_WithInvalidModel_ReturnsBadRequest()
        {
            // arrange

            // Tworzymy model, ktory chcemy wysłać na serwer

            var model = new CreateProductDto
            {
                ProductName = "NazwaTestowaBłędnaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                GroupId = new int[] { 1 },
                Weight = 200
            };

            // Serializujemy model do formatu json
            var json = JsonConvert.SerializeObject(model);

            StringContent httpContent = new(json, Encoding.UTF8, "application/json");

            // act
             
            // Wysyłamy model na serwer
            var response = await _client.PostAsync("https://localhost:5001/api/product", httpContent);

            // assert

            // Sprawdzamy czy status kod z tej odpowiedzi jest równy created
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);

            // Sprawdzamy czy odpowiedź serwera zawiera nagłówek z lokacją
            response.Headers.Location.Should().BeNull();
        }

        // updateProduct
        [Fact]
        public async Task UpdateProduct_WithValidModel_ReturnsOKResult()
        {
            // arrange

            // Tworzymy model, ktory chcemy edytować i wysłać na serwer

            var model = new CreateProductDto
            {
                ProductName = "NazwaTestowa",
                GroupId = new int[] { 1 },
                Weight = 200
            };

            // Serializujemy model do formatu json
            var json = JsonConvert.SerializeObject(model);

            StringContent httpContent = new(json, Encoding.UTF8, "application/json");

            // Wysyłamy model na serwer
            await _client.PostAsync("https://localhost:5001/api/product", httpContent);

            // Edytujemy model

            var modelUpdated = new UpdateProductDto
            {
                ProductName = "NazwaTestowaEdytowana",
                GroupId = new int[] { 1 },
                Weight = 200
            };

            // Serializujemy model do formatu json
            var json2 = JsonConvert.SerializeObject(modelUpdated);

            StringContent httpContent2 = new(json2, Encoding.UTF8, "application/json");

            // act

            var response2 = await _client.PutAsync("https://localhost:5001/api/product/148", httpContent2);

            // assert

            // sprawdzamy czy status kod z tej odpowiedzi jest równy OK
            response2.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        // updateAnotherProduct
        [Fact]
        public async Task UpdateProduct_WithInvalidModel_ReturnsMethodNotAllowedResult()
        {
            // arrange

            // Tworzymy model, ktory chcemy edytować i wysłać na serwer

            var model = new UpdateProductDto
            {
                ProductName = "NazwaTestowaEdytowana",
                GroupId = new int[] { 1 },
                Weight = 200
            };

            // Serializujemy model do formatu json
            var json = JsonConvert.SerializeObject(model);

            StringContent httpContent = new(json, Encoding.UTF8, "application/json");

            // act

            var response = await _client.PatchAsync("https://localhost:5001/api/product/2", httpContent);

            // assert

            // sprawdzamy czy status kod z tej odpowiedzi jest równy method not allowed
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.MethodNotAllowed);
        }

        // deleteProduct
        [Fact]
        public async Task DeleteProduct_WithParameter_ReturnsNoContentResult()
        {
            // arrange

            // Tworzymy model, ktory chcemy wysłać na serwer

            var model = new CreateProductDto
            {
                ProductName = "NazwaTestowa",
                GroupId = new int[] { 1 },
                Weight = 200
            };

            // Serializujemy model do formatu json
            var json = JsonConvert.SerializeObject(model);

            StringContent httpContent = new(json, Encoding.UTF8, "application/json");

            // Wysyłamy model na serwer
            await _client.PostAsync("https://localhost:5001/api/product", httpContent);

            // act

            var response2 = await _client.DeleteAsync("https://localhost:5001/api/product/148");

            // assert

            // sprawdzamy czy status kod z tej odpowiedzi jest równy no content
            response2.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);
        }

        // deleteAnotherProduct
        [Fact]
        public async Task DeleteProduct_WithParameter_ReturnsForbiddenResult()
        {
            // arrange

            // act

            var response = await _client.DeleteAsync("https://localhost:5001/api/product/2");

            // assert

            // sprawdzamy czy status kod z tej odpowiedzi jest równy no content
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Forbidden);
        }
    }
}
