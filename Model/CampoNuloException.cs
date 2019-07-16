using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeEstacionamentos
{
    public class CampoNuloException : Exception
    {
        
        public CampoNuloException()
        {

        }

        public CampoNuloException(string message)
            : base(message)
        {
            message = ("Erro! Nenhum dos campos pode ser nulo!");
        }

        public CampoNuloException(string message, Exception inner) 
            : base(message, inner)
        {
            
        }
    }
}
