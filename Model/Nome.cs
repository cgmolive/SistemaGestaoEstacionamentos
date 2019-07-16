using SistemaDeEstacionamentos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeEstacionamentos
{
    public class Nome
    {
        public string  Dados { get; set; }

        public Nome(string Dados)
        {
            if (Dados == null)
                throw new CampoInvalidoException();
          
            else
            {
                this.Dados = Dados;
            }
        }
    }
}
