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
    public class Estacionamento
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Handle { get; set; }
        public string Nome { get; set; }
        public List<Vagas> VagasDoEstacionamento { get; set; }
     

        public List<string> exibirVagasDisponiveis()
        { 
 
             List<string> vagasDisponiveis = new List<string>();
             return vagasDisponiveis;
        }
        public Estacionamento(string Nome)
        {
            Nome validadorDeNome = new Nome();
            if(validadorDeNome.validaNome(Nome) == false)
            {
                throw new CampoInvalidoException();
            }
            else
            {
                this.Nome = Nome;
            }
        }
    }
}

