using SistemaDeEstacionamentos.Model;
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
        public int Handle { get; set; }
        private CPF Cpf { get; set; }
        private Nome Nome { get; set; }
        private Endereco Endereco { get; set; }
        private CredenciaisDeAcesso CredenciaisDeAcesso { get; set; } 

        private IList<Veiculos> CarrosCadastrados;
        

        public Usuarios (string nome, int cep, string cpf, string nomeDeUsuario, string senha)
        {
            Seq++;
            this.Nome = new Nome(nome);
            this.Endereco = new Endereco(cep);
            this.CredenciaisDeAcesso = new CredenciaisDeAcesso(nomeDeUsuario, senha);
            this.Cpf = new CPF(cpf);
            this.Handle = Seq;
        }


        public void CadastrarCarro(string Placa, string tipoDoCarro)
        {
            Veiculos carroNovo = new Veiculos(Placa, tipoDoCarro);
            CarrosCadastrados.Add(carroNovo);
        }
    }
}
