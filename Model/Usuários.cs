using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeEstacionamentos
{
    public class Usuarios
    {
        public static int Seq = 0;
        private CPF cpf { get; set; }
        private Nome nome { get; set; }
        private Endereco endereco { get; set; }
        private CredenciaisDeAcesso credenciaisDeAcesso;
        private int Handler;

        public Usuarios (string nome, string Logradouro, string Bairro, string Complemento, int numero, string Valor, string usuario, string senha)
        {
            Seq++;
            this.cpf = new CPF(Valor);
            this.nome = new Nome(nome);
            this.endereco = new Endereco(Logradouro, Bairro, Complemento, numero);
            this.credenciaisDeAcesso = new CredenciaisDeAcesso(usuario, senha);
            this.Handler = Seq;
        }

        

        

    }
}
