using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeEstacionamentos
{
    public class Vagas
    {
        private static int ID;
        public int Handle { get; set; }
        public string TipoDaVaga { get; set; }
        public string LocalDaVaga { get; set; }

        public Vagas(string TipoDaVaga, string LocalDaVaga)
        {
            ID++;
            Handle = ID;
            this.TipoDaVaga = TipoDaVaga;
            this.LocalDaVaga = LocalDaVaga;
        }
    }
}
