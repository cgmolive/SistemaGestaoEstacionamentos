using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeEstacionamentos
{
    public class CPF
    {
        public string Valor { get; }

        //Vou buscar um validador de CPF real na internet para implantar aqui, por enquanto fica com a validação genérica
        public CPF(string Valor)
        {
            if (Valor == null)
                throw new CampoNuloException();

            else
            {
               this.Valor = Valor;
            }
        }
    }
}
