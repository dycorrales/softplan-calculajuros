using Xunit;
using calculajuros.domain.Models;

namespace CalculaJuros.Tests
{
    public class CalculaJurosUnitTest
    {
        [Theory]
        [InlineData(100, 5)]
        public void RetornaCalculoJuros105Virgula10(decimal valorInicial, int tempo)
        {
            var calculadoraJuros = new CalculadoraJuros(valorInicial, tempo, 0.01M);

            var calculoJuros = calculadoraJuros.CacularJuros();
            
            Assert.Equal(105.10M, calculoJuros);
        }
    }
}
