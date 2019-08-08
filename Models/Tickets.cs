using SistemaGestaoEstacionamentos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeEstacionamentos.Model
{
    public class Tickets
    {
        public static int ID;
        public Estacionamento Origem { get; }
        public int Handle { get; set; }
        private double Valor { get; set; }
        public DateTime DataHora { get; }
        public DateTime HoraDeSaida { get; }
        public DateTime HoraValidacao { get; set; }
        public Usuarios usuario;


        public Tickets()
        {
            //definir usuário dono do ticket através da sessão com que está logado
            ID++;
            Handle = ID;
            DataHora = DateTime.Now;

        }

        public string validaTicket(Tickets ticket)
        {
            TabelaDePreco tabelaDePreco = new TabelaDePreco();
            if (HoraValidacao == null)
            {
                HoraValidacao = DateTime.Now.AddMinutes(15);
                return ("Ticket válido até " + tabelaDePreco.validoPor(ticket));
            }
            else
            {
                return ("Ticket não validado! Por favor valide seu ticket.");
            }

        }
    }
}
