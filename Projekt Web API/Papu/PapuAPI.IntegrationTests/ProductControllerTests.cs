using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Papu;
using System.Threading.Tasks;
using Xunit;

namespace PapuAPI.IntegrationTests
{
    public class ProductControllerTests
    {

        //getOneProduct
        [Fact]
        public async Task GetProduct_WithParameter_ReturnsOkResult()
        {
            //arrange

            var factory = new WebApplicationFactory<Startup>();
            var client = factory.CreateClient();

            //act

            var response = await client.GetAsync("https://localhost:5001/api/product/1");

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy ok
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //getAnotherOneProduct
        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        public async Task AnotherGetProduct_WithParameter_ReturnsOkResult(string queryParams)
        {
            //arrange

            var factory = new WebApplicationFactory<Startup>();
            var client = factory.CreateClient();

            //act

            var response = await client.GetAsync("https://localhost:5001/api/product/" + queryParams);

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy ok
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        //getAnotherOneProduct
        [Theory]
        [InlineData("100")]
        [InlineData("200")]
        public async Task AnotherGetProduct_WithInvalidParameter_ReturnsNotFound(string queryParams)
        {
            //arrange

            var factory = new WebApplicationFactory<Startup>();
            var client = factory.CreateClient();

            //act

            var response = await client.GetAsync("https://localhost:5001/api/product/" + queryParams);

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy not found
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }
    }
}
