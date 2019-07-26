using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaGestaoEstacionamentos.Model
{
    public class TabelaDePreco
    {
        public float AteQuatroHoras { get; set; }
        public float AdicionalPorHora { get; set; }
        public float ValorDiaria { get; set; }
        public TimeSpan Carencia { get; set; }

        public TabelaDePreco(float AteQuatroHoras, float AdicionalPorHora, float ValorDiaria)
        {
            this.AteQuatroHoras = AteQuatroHoras;
            this.AdicionalPorHora = AdicionalPorHora;
            this.ValorDiaria = ValorDiaria;
        }

        public float calculaPrecoTicket(DateTime HorarioDeEntrada, DateTime HorarioDeSaida)
        {
            float valorFinal;
            TimeSpan TempoDecorrido = HorarioDeEntrada.Subtract(HorarioDeSaida);

            //Decisão do valor pago
            //Por padrão, vou assumir que a diária custa mais que 8 horas, e definir como limite.
            if (TempoDecorrido.Minutes > 15)
            {


                if (TempoDecorrido.Hours <= 4)
                {
                    valorFinal = AteQuatroHoras;
                }
                else if (TempoDecorrido.Hours >= 8)
                {
                    valorFinal = ValorDiaria;
                }
                else
                {
                    valorFinal = AteQuatroHoras + ((TempoDecorrido.Hours - 4) * AdicionalPorHora);
                }
                return valorFinal;

            }
            else
            {
                return 0;
            }
        }
    }
}
