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
                if (Regex.IsMatch(usuario, (@"[^a-zA-Z0-9]")))
                {
                    throw new CampoInvalidoException("Caracteres especiais não devem ser aceitos!");
                    
                }
                else
                {
                    this.usuario = usuario;
                    this.senha = senha;
                }

            }

        }
    }
}