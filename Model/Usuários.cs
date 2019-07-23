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
        private CPF cpf { get; set; }
        private Nome nome { get; set; }
        private Endereco endereco { get; set; }
        private CredenciaisDeAcesso credenciaisDeAcesso;

        private IList<Veiculos> CarrosCadastrados;
        

        public Usuarios (Nome nome,Endereco endereco, CPF cpf, CredenciaisDeAcesso credenciaisDeAcesso)
        {
            Seq++;
            this.cpf = cpf;
            this.nome = nome;
            this.endereco = endereco;
            this.credenciaisDeAcesso = credenciaisDeAcesso;
            this.Handle = Seq;
        }

        public void CadastrarCarro(string Placa, string tipoDoCarro)
        {
            Veiculos carroNovo = new Veiculos(Placa, tipoDoCarro);
            CarrosCadastrados.Add(carroNovo);
        }

        

    }
}
