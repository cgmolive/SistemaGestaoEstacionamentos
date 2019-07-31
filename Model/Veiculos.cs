using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeEstacionamentos.Model
{
    public class Veiculos
    {
        private static int ID;

        public int Handle { get; set; }

        public string Placa { get; set; }
        public string TipoDoCarro { get; set; }

        public Veiculos(string placa, string tipoDoCarro)
        {
            ID++;
            Handle = ID;
            this.Placa = placa;
            this.TipoDoCarro = tipoDoCarro;
        }
    }
}
