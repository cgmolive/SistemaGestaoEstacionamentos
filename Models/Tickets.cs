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

        }

        public string validaTicket()
        {
            TabelaDePreco tabelaDePreco = new TabelaDePreco();
            if (DataHoraValidacao == null)
            {
                DataHoraValidacao = DateTime.Now;
                TempoDecorrido = DataHoraValidacao.Subtract(DataHoraEntrada);
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
