using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeEstacionamentos.Model
{
    public class CampoInvalidoException : Exception
    {
        public CampoInvalidoException()
        {
        }

        public CampoInvalidoException(string message) : base(message)
        {
            message = ("Erro! O campo é inválido!");
        }

        public CampoInvalidoException(string message, Exception innerException) : base(message, innerException)
        {

        }

    }
}
