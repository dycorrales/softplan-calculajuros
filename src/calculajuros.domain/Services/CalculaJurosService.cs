using calculajuros.domain.Models;

namespace CalculaJuros.Domain.Services
{
    public class CalculaJurosService : ICalculaJurosService
    {
        private readonly ITaxaJurosService _taxaJurosService;

        public CalculaJurosService(ITaxaJurosService taxaJurosService)
        {
            _taxaJurosService = taxaJurosService;
        }

        public decimal RetornarCalculoJuros(decimal valorInicial, int tempo)
        {
            var taxaJuros = _taxaJurosService.RetornarTaxaJurosAsync();

            var calculadoraJuros = new CalculadoraJuros(valorInicial, tempo, taxaJuros.Result);
            return calculadoraJuros.CacularJuros();
        }
    }
}
