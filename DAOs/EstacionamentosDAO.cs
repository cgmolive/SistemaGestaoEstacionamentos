using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeEstacionamentos.Controller
{
    public class EstacionamentosDAO
    {
        public void Gravar(Estacionamento estacionamento)
        {

            using (var repo = new SistemaEstacionamentosContext())
            {
                repo.Estacionamentos.Add(estacionamento);
                repo.SaveChanges();
            }
        }

        public void Recuperar()
        {
            using (var repo = new SistemaEstacionamentosContext())
            {
                IList<Estacionamento> estacionamentos = repo.Estacionamentos.ToList();
            }
        }

        public void Excluir()
        {
            using (var repo = new SistemaEstacionamentosContext())
            {
                IList<Estacionamento> estacionamentos = repo.Estacionamentos.ToList();
                foreach (var estacionamento in estacionamentos)
                {
                    repo.Estacionamentos.Remove(estacionamento);
                }
                repo.SaveChanges();

            }
        }

        public void Editar(int Handler)
        {
            using (var repo = new SistemaEstacionamentosContext())
            {
                var EstacionamentoParaAtualizar = repo.Estacionamentos.Find(Handler);
                //Definir campo a ser atualizado
                repo.Estacionamentos.Update(EstacionamentoParaAtualizar);

                repo.SaveChanges();
            }
        }

        public IList<Estacionamento> Lista()
        {
            using (var repo = new SistemaEstacionamentosContext())
            {
                return repo.Estacionamentos.ToList();
            }
        }
    }
}
