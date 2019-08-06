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
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public int cep { get; set; }
        public string nomeDeUsuario { get; set; } 
        public string senha { get; set; }

        private IList<Veiculos> CarrosCadastrados;
        

        public Usuarios (string nome, int cep, string cpf, string nomeDeUsuario, string senha)
        {
            CPF validadorCPF = new CPF();
            Nome validadorNome = new Nome();
            Seq++;
           
            this.cep = cep;
            this.nomeDeUsuario = nomeDeUsuario;
            this.Handle = Seq;
            if(validadorCPF.IsCpf(cpf)== false)
            {
                throw new CampoInvalidoException();
            }
            else
            {
                this.Cpf = cpf;
            }

            if (validadorNome.validaNome(nome) == false){
                throw new CampoInvalidoException();
            }
            else
            {
                this.Nome = nome;
            }

        }


        public void CadastrarCarro(string Placa, string tipoDoCarro)
        {
            Veiculos carroNovo = new Veiculos(Placa, tipoDoCarro);
            CarrosCadastrados.Add(carroNovo);
        }
    }
}
