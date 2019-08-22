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

        public Estacionamento Recuperar(int Handle)
        {
            using (var repo = new SistemaEstacionamentosContext())
            {
               return repo.Estacionamentos.FirstOrDefault(x => x.Handle == Handle); ;
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

        public void Editar(Estacionamento estacionamento)
        {
            using (var repo = new SistemaEstacionamentosContext())
            {
                repo.Estacionamentos.Update(estacionamento);
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
