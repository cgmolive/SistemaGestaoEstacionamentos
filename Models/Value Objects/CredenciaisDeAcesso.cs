using SistemaDeEstacionamentos.Model;
using System.Text.RegularExpressions;

namespace SistemaDeEstacionamentos
{
    public class CredenciaisDeAcesso
    {
        private string usuario;
        private string senha;

        public CredenciaisDeAcesso(string usuario, string senha)
        {
            if  (usuario == null || senha == null)
            {
                throw new CampoNuloException();
            }
            else
            {
                    this.usuario = usuario;
                    this.senha = senha;
            }

        }
    }
}
