using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeEstacionamentos
{
    public class Vagas
    {
        public string TipoDaVaga { get; set; }
        public string LocalDaVaga { get; set; }

        public Vagas(string TipoDaVaga, string LocalDaVaga)
        {
            this.TipoDaVaga = TipoDaVaga;
            this.LocalDaVaga = LocalDaVaga;
        }
    }
}
