using SistemaDeEstacionamentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaGestaoEstacionamentos.DAOs
{
    public class VagasDAO
    {
        public void Gravar(Vagas vaga)
        {

            using (var repo = new SistemaEstacionamentosContext())
            {
                repo.Vagas.Add(vaga);
                repo.SaveChanges();
            }
        }

        public void Excluir(Vagas vaga)
        {
            using (var repo = new SistemaEstacionamentosContext())
            {
                
                repo.Vagas.Remove(vaga);
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