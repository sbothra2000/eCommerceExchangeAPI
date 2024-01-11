using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using eCommerceExchange.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace eCommerceExchangeTests
{
    public class productControllerTest: IClassFixture<WebApplicationFactory<eCommerceExchange.Startup>>
    {
        private readonly HttpClient _client;

        public productControllerTest(WebApplicationFactory<eCommerceExchange.Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetProducts_ReturnsSuccessStatusCode()
        {
            var response = await _client.GetAsync("/api/products");
            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task GetProducts_ReturnsOkWithProducts()
        {
            var response = await _client.GetAsync("/api/products");
            var products = await response.Content.ReadFromJsonAsync<List<Product>>();
            Assert.Equal(5,products.Count);
            Assert.NotEmpty(products);
        }
    }
}
