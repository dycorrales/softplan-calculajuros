namespace CalculaJuros.Domain.Services
{
    public interface ICalculaJurosService
    {
        decimal RetornarCalculoJuros(decimal valorInicial, int tempo);
    }
}
