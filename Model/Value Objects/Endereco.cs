using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeEstacionamentos
{
    public class Endereco
    {
        private string Logradouro { get; set; }
        private string Bairro { get; set; }
        private string Complemento { get; set; }
        private int CEP { get; set; }
        private int numero;

        public Endereco(int cep)
        {
            this.CEP = cep;
            //Inserir codigo para inserir outros campos baseado no CEP
        }

        public Endereco(string Logradouro, string Bairro, string Complemento,  int numero)
        {
            if(Logradouro == null || Bairro == null || Complemento == null)
            {
                throw new CampoNuloException();
            }
            else
            {
                this.Logradouro = Logradouro;
                this.Bairro = Bairro;
                this.Complemento = Complemento;
                this.numero = numero;
            }
        }
    }
}
