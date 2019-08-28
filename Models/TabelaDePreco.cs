using SistemaDeEstacionamentos.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeEstacionamentos.Model
{
    public class TabelaDePreco
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Handle { get; set; }
        public float AteQuatroHoras { get; set; }
        public float AdicionalPorHora { get; set; }
        public float ValorDiaria { get; set; }
        public TimeSpan Carencia { get; set; }
        public int EstacionamentoId { get; set; }
        public Estacionamento Estacionamento { get; set; }

        public TabelaDePreco()
        {
            Carencia = TimeSpan.FromMinutes(15);
        }
        public TabelaDePreco(float AteQuatroHoras, float AdicionalPorHora, float ValorDiaria)
        {
            this.AteQuatroHoras = AteQuatroHoras;
            this.AdicionalPorHora = AdicionalPorHora;
            this.ValorDiaria = ValorDiaria;
        }

        public float calculaPrecoTicket(TimeSpan TempoDecorrido)
        {
            float valorFinal = 0;


            //Decisão do valor pago
            //Por padrão, vou assumir que a diária custa mais que 8 horas, e definir como limite.
            if (TempoDecorrido > Carencia)
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
            }
            return valorFinal;
        }
        public TimeSpan ValidoPor(Tickets ticket)
        {
            TimeSpan TempoValidade = DateTime.Now.AddMinutes(Carencia.Minutes).Subtract(ticket.DataHoraEntrada);
            return TempoValidade;
        }
            
        public void DefinirCarencia(int tempoCarencia)
        {
            Carencia = TimeSpan.FromMinutes(tempoCarencia);
        }
    }
}
