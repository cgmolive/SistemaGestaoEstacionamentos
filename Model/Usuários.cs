using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeEstacionamentos
{
    public class Usuarios
    {
        static int sequencial = 1;
        private CPF cpf { get; private set; }
        private Nome nome { get; private set; }
        private Endereco endereco { get; private set; }
        private CredenciaisDeAcesso credenciaisDeAcesso;
        private long handler;

        public Usuarios (string nome, string Logradouro, string Bairro, string Complemento, int numero, string Valor, string usuario, string senha)
        {
            sequencial++;
            this.handler += sequencial;
            this.cpf = new CPF(Valor);
            this.nome = new Nome(nome);
            this.endereco = new Endereco(Logradouro, Bairro, Complemento, numero);
            this.credenciaisDeAcesso = new CredenciaisDeAcesso(usuario, senha);

        }

        

        

    }
}
