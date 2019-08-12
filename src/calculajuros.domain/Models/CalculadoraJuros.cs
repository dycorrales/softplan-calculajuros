using calculajuros.domain.Helpers;
using System;

namespace calculajuros.domain.Models
{
    public class CalculadoraJuros
    {
        public decimal _valorInicial;
        public int _tempo;
        public decimal _taxaJuros;

        public CalculadoraJuros(decimal valorInicial, int tempo, decimal taxaJuros)
        {
            _valorInicial = valorInicial;
            _tempo = tempo;
            _taxaJuros = taxaJuros;
        }

        public decimal CacularJuros()
        {
            return (_valorInicial * (1 + _taxaJuros).Power(_tempo)).Truncate(2);
        }
    }
}
