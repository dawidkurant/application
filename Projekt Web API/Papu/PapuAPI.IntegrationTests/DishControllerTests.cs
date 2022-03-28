﻿using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Papu;
using System.Threading.Tasks;
using Xunit;

namespace PapuAPI.IntegrationTests
{
    public class DishControllerTests
    {

        //getOneDish
        [Fact]
        public async Task GetDish_WithParameter_ReturnsOkResult()
        {
            //arrange

            var factory = new WebApplicationFactory<Startup>();
            var client = factory.CreateClient();

            //act

            var response = await client.GetAsync("https://localhost:5001/api/dish/1");

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

            var factory = new WebApplicationFactory<Startup>();
            var client = factory.CreateClient();

            //act

            var response = await client.GetAsync("https://localhost:5001/api/dish/" + queryParams);

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

            var factory = new WebApplicationFactory<Startup>();
            var client = factory.CreateClient();

            //act

            var response = await client.GetAsync("https://localhost:5001/api/dish/" + queryParams);

            //assert

            //sprawdzamy czy status kod z tej odpowiedzi jest równy not found
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }
    }
}
