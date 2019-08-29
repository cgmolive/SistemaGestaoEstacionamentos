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
        public bool Validado { get; set; }
        public int EstacionamentoId { get; set; }
        public Estacionamento EstacionamentoDeOrigem { get; set; }

        public Tickets()
        {
            DataHoraEntrada = DateTime.Now;
            Validado = false;

        }

        public void ValidaTicket(Tickets ticket, TabelaDePreco tabelaDePreco)
        {
            DataHoraValidacao = DateTime.Now;
            TempoDecorrido = DataHoraValidacao.Subtract(DataHoraEntrada);
            //TabelaDePreco tabelaDePreco = new TabelaDePreco();

                Validade = DateTime.Now.Add(tabelaDePreco.ValidoPor(ticket));
                Valor = tabelaDePreco.calculaPrecoTicket(TempoDecorrido);
                Validado = true;
       
        }
    }
}
