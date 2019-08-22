using SistemaGestaoEstacionamentos.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeEstacionamentos.Model
{
    public class Tickets
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Handle { get; set; }
        public double Valor { get; set; }
        public DateTime DataHoraEntrada { get; set; }
        public DateTime Validade { get; set; }
        public DateTime DataHoraValidacao { get; set; }
        public TimeSpan TempoDecorrido { get; set; }
        public Veiculos Veiculo { get; set; }
        public long VeiculoId { get; set; }


        public Tickets()
        {
            DataHoraEntrada = DateTime.Now;
            DataHoraValidacao = DateTime.Now.AddMinutes(15);
            //DECOY - Alterar assim que passagem de carencia estiver funcionando

        }

        public string validaTicket()
        {
            TabelaDePreco tabelaDePreco = new TabelaDePreco();
            if (DataHoraEntrada.Subtract(DataHoraValidacao) < TempoDecorrido)
            {
                DataHoraValidacao = DateTime.Now;
                TempoDecorrido = DataHoraValidacao.Subtract(DataHoraEntrada);
                Validade = DateTime.Now.Add(tabelaDePreco.ValidoPor(this));
                Valor = tabelaDePreco.calculaPrecoTicket(TempoDecorrido);
                return ("Ticket válido até " + tabelaDePreco.ValidoPor(this));
            }
            else
            {
                return ("Ticket já validado.");
            }

        }
    }
}
