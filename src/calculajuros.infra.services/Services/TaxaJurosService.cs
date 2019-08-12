using CalculaJuros.Domain.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;

namespace calculajuros.infra.services.Services
{
    public class TaxaJurosService : ITaxaJurosService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;

        public TaxaJurosService(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _clientFactory = clientFactory;
            _configuration = configuration;
        }

        public async Task<decimal> RetornarTaxaJurosAsync()
        {
            var taxaJurosEndoint = _configuration["ExternalUrl:TaxaJurosApi"];

            var request = new HttpRequestMessage(HttpMethod.Get, taxaJurosEndoint);
            request.Headers.Add("Accept", "application/json");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<Result>(response.Content.ReadAsStringAsync().Result);
                var taxaJuros = Convert.ToDecimal(result.Data, CultureInfo.InvariantCulture);
                return taxaJuros;
            }

            return 0;
        }
    }
    public class Result
    {
        public string Response { get; set; }
        public string Data { get; set; }
    }
}
