using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Papu;
using System.Threading.Tasks;
using Xunit;

namespace PapuAPI.IntegrationTests
{
    public class MenuControllerTests
    {

        //getOneMenu
        [Fact]
        public async Task GetMenu_WithParameter_ReturnsOkResult()
        {
            //arrange

            var factory = new WebApplicationFactory<Startup>();
            var client = factory.CreateClient();

            //act

            var response = await client.GetAsync("https://localhost:5001/api/menu/1");

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy ok
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //getAnotherOneMenu
        [Theory]
        [InlineData("1")]
        public async Task AnotherGetMenu_WithParameter_ReturnsOkResult(string queryParams)
        {
            //arrange

            var factory = new WebApplicationFactory<Startup>();
            var client = factory.CreateClient();

            //act

            var response = await client.GetAsync("https://localhost:5001/api/menu/" + queryParams);

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy ok
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //getAnotherOneMenu
        [Theory]
        [InlineData("100")]
        [InlineData("200")]
        public async Task AnotherGetMenu_WithInvalidParameter_ReturnsNotFound(string queryParams)
        {
            //arrange

            var factory = new WebApplicationFactory<Startup>();
            var client = factory.CreateClient();

            //act

            var response = await client.GetAsync("https://localhost:5001/api/menu/" + queryParams);

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy not found
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }
    }
}
