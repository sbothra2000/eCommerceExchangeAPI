using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using eCommerceExchange.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace eCommerceExchangeTests
{
    public class CurrencyExchangeRateControllerTest : IClassFixture<WebApplicationFactory<eCommerceExchange.Startup>>
    {
        private readonly HttpClient _client;

        public CurrencyExchangeRateControllerTest(WebApplicationFactory<eCommerceExchange.Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetCurrencyExchangeRate_ReturnsSuccessStatusCode()
        {
            var response = await _client.GetAsync("/api/currencyexchangerates");
            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task GetCurrencyExchangeRate_ReturnsOkWithProducts()
        {
            var response = await _client.GetAsync("/api/currencyexchangerates");
            var countries = await response.Content.ReadFromJsonAsync<List<Product>>();
            Assert.Equal(6, countries.Count);
            Assert.NotEmpty(countries);
        }
    }
}
