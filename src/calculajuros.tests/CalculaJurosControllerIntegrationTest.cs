using System.Net.Http;
using Xunit;
using System.Threading.Tasks;
using System;
using System.Globalization;
using System.Net;
using CalculaJuros.WebApi;
using Microsoft.AspNetCore.Mvc.Testing;

namespace CalculaJuros.Tests
{
    public class CalculaJurosControllerIntegrationTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public CalculaJurosControllerIntegrationTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData(100, 5)]
        public async Task GetCalculaJuros105Virgula10(decimal valorInicial, int tempo)
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync($"/retornacalculojuros/api/v1/calculajuros?valorInicial={valorInicial}&tempo={tempo}");

            response.EnsureSuccessStatusCode();
            var calculoJuros = 0.0M;

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<Result>().Result;
                calculoJuros = Convert.ToDecimal(result.Data, CultureInfo.InvariantCulture);
            }

            Assert.Equal(105.10M, calculoJuros);
        }

        [Fact]
        public async Task GetOkAsync()
        { 
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/retornacalculojuros/api/v1/calculajuros/healthcheck");

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }

    public class Result
    {
        public string Response { get; set; }
        public string Data { get; set; }
    }
}
