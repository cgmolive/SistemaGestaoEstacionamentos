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

        public void Editar(Vagas vaga)
        {
            using (var repo = new SistemaEstacionamentosContext())
            {
                repo.Vagas.Update(vaga);
                repo.SaveChanges();
            }
        }

        public Vagas Buscar(int vagaId)
        {
            using (var repo = new SistemaEstacionamentosContext())
            {
                return repo.Vagas.FirstOrDefault(x => x.Handle == vagaId);
            }
            
        }

        public IList<Vagas> Lista()
        {
            using (var repo = new SistemaEstacionamentosContext())
            {
                return repo.Vagas.ToList();
            }
        }
    }
}