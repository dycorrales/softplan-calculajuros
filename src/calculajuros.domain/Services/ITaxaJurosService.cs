using System.Threading.Tasks;

namespace CalculaJuros.Domain.Services
{
    public interface ITaxaJurosService
    {
        Task<decimal> RetornarTaxaJurosAsync();
    }
}
