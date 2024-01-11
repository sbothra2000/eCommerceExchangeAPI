using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using eCommerceExchange.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace eCommerceExchangeTests
{
    public class CountryControllerTest : IClassFixture<WebApplicationFactory<eCommerceExchange.Startup>>
    {
        private readonly HttpClient _client;

        public CountryControllerTest(WebApplicationFactory<eCommerceExchange.Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetCountries_ReturnsSuccessStatusCode()
        {
            var response = await _client.GetAsync("/api/countries");
            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task GetCountries_ReturnsOkWithProducts()
        {
            var response = await _client.GetAsync("/api/countries");
            var countries = await response.Content.ReadFromJsonAsync<List<Product>>();
            Assert.Equal(3, countries.Count);
            Assert.NotEmpty(countries);
        }
    }
}
