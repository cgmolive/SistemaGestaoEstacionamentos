using SistemaDeEstacionamentos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SistemaDeEstacionamentos
{
    public class Nome
    {
        public string  Dados { get; set; }

        public bool  validaNome(string Dados)
        {
            if (Dados == null)
               throw new CampoNuloException();

            else if (!Regex.IsMatch(Dados, (@"[^a-zA-Z]")))
            {
                return false;
            }
            return true;

        }
    }
}

