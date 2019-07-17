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
        private DateTime DataHora { get; }
        private DateTime HoraDeSaida { get; }
        private Boolean validado { get; }
        public Usuarios usuario;


        public Tickets()
        {
            //definir usuário dono do ticket através da sessão com que está logado
            ID++;
            Handle = ID;
            DataHora = DateTime.Now;
            validado = false;
        }

    }

   

}
