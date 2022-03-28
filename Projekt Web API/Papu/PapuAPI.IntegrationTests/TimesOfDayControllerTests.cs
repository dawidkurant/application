using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Papu;
using System.Threading.Tasks;
using Xunit;

namespace PapuAPI.IntegrationTests
{
    public class TimesOfDayControllerTests
    {

        //getOneBreakfast
        [Fact]
        public async Task GetBreakfast_WithParameter_ReturnsOkResult()
        {
            //arrange

            var factory = new WebApplicationFactory<Startup>();
            var client = factory.CreateClient();

            //act

            var response = await client.GetAsync("https://localhost:5001/api/breakfast/1");

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy ok
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //getOneSecondBreakfast
        [Fact]
        public async Task GetSecondBreakfast_WithParameter_ReturnsOkResult()
        {
            //arrange

            var factory = new WebApplicationFactory<Startup>();
            var client = factory.CreateClient();

            //act

            var response = await client.GetAsync("https://localhost:5001/api/secondbreakfast/1");

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy ok
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //getOneLunch
        [Fact]
        public async Task GetLunch_WithParameter_ReturnsOkResult()
        {
            //arrange

            var factory = new WebApplicationFactory<Startup>();
            var client = factory.CreateClient();

            //act

            var response = await client.GetAsync("https://localhost:5001/api/lunch/1");

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy ok
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //getOneSnack
        [Fact]
        public async Task GetSnack_WithParameter_ReturnsOkResult()
        {
            //arrange

            var factory = new WebApplicationFactory<Startup>();
            var client = factory.CreateClient();

            //act

            var response = await client.GetAsync("https://localhost:5001/api/snack/1");

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy ok
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //getOneDinner
        [Fact]
        public async Task GetDinner_WithParameter_ReturnsOkResult()
        {
            //arrange

            var factory = new WebApplicationFactory<Startup>();
            var client = factory.CreateClient();

            //act

            var response = await client.GetAsync("https://localhost:5001/api/dinner/1");

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

            var factory = new WebApplicationFactory<Startup>();
            var client = factory.CreateClient();

            //act

            var response = await client.GetAsync("https://localhost:5001/api/breakfast/" + queryParams);

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

            var factory = new WebApplicationFactory<Startup>();
            var client = factory.CreateClient();

            //act

            var response = await client.GetAsync("https://localhost:5001/api/secondbreakfast/" + queryParams);

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

            var factory = new WebApplicationFactory<Startup>();
            var client = factory.CreateClient();

            //act

            var response = await client.GetAsync("https://localhost:5001/api/lunch/" + queryParams);

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

            var factory = new WebApplicationFactory<Startup>();
            var client = factory.CreateClient();

            //act

            var response = await client.GetAsync("https://localhost:5001/api/snack/" + queryParams);

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

            var factory = new WebApplicationFactory<Startup>();
            var client = factory.CreateClient();

            //act

            var response = await client.GetAsync("https://localhost:5001/api/dinner/" + queryParams);

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

            var factory = new WebApplicationFactory<Startup>();
            var client = factory.CreateClient();

            //act

            var response = await client.GetAsync("https://localhost:5001/api/breakfast/" + queryParams);

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

            var factory = new WebApplicationFactory<Startup>();
            var client = factory.CreateClient();

            //act

            var response = await client.GetAsync("https://localhost:5001/api/secondbreakfast/" + queryParams);

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

            var factory = new WebApplicationFactory<Startup>();
            var client = factory.CreateClient();

            //act

            var response = await client.GetAsync("https://localhost:5001/api/lunch/" + queryParams);

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

            var factory = new WebApplicationFactory<Startup>();
            var client = factory.CreateClient();

            //act

            var response = await client.GetAsync("https://localhost:5001/api/snack/" + queryParams);

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

            var factory = new WebApplicationFactory<Startup>();
            var client = factory.CreateClient();

            //act

            var response = await client.GetAsync("https://localhost:5001/api/dinner/" + queryParams);

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy not found
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }
    }
}
