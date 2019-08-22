using SistemaDeEstacionamentos.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeEstacionamentos
{
    public class Usuarios
    {

        public string Cpf { get; set; }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Handle { get; set; }
        public string Nome { get; set; }
        public int Cep { get; set; }
        public string nomeDeUsuario { get; set; } 
        public string senha { get; set; }
        public ICollection<Veiculos> Carros { get; set; }
        public long carroPadraoId { get; set; }
        public string Logradouro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }


        public Usuarios (string nome, int cep, string cpf, string nomeDeUsuario, string senha, string logradouro, string cidade, string estado)
        {
            CPF validadorCPF = new CPF();
            Nome validadorNome = new Nome();
           
            Cep = cep;
            this.nomeDeUsuario = nomeDeUsuario;
            this.senha = senha;
            if(validadorCPF.IsCpf(cpf)== false)
            {
                throw new CampoInvalidoException();
            }
            else
            {
                Cpf = cpf;
            }

            if (validadorNome.validaNome(nome) == false){
                throw new CampoInvalidoException();
            }
            else
            {
                Nome = nome;
            }
            Logradouro = logradouro;
            Cidade = cidade;
            Estado = estado;

        }
        public Usuarios()
        {

        }


        public void CadastrarCarro(string Placa, string tipoDoCarro)
        {
            Veiculos carroNovo = new Veiculos(Placa, tipoDoCarro);
            Carros.Add(carroNovo);
            if(carroPadraoId == 0)
            {
                carroPadraoId = carroNovo.Handle;
            }
        }
    }
}
