using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeEstacionamentos
{
    public class Estacionamento
    {
        public static int ID;
        public int Handle;
        public List<Vagas> VagasDoEstacionamento { get; set; }
     

        public List<string> exibirVagasDisponiveis()
        { 
 
             List<string> vagasDisponiveis = new List<string>();
             return vagasDisponiveis;
        }
        public Estacionamento()
        {
            ID++;
            Handle = ID;
        }
    }
}

