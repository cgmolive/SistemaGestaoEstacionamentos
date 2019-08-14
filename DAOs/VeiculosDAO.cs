using SistemaDeEstacionamentos;
using SistemaDeEstacionamentos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaGestaoEstacionamentos.DAOs
{
    public class VeiculosDAO
    {
        public void Gravar(Veiculos veiculo)
        {


            using (var repo = new SistemaEstacionamentosContext())
            {
                repo.Veiculos.Add(veiculo);
                repo.SaveChanges();
            }
        }

        public void Excluir(int Handle)
        {
            using (var repo = new SistemaEstacionamentosContext())
            {
                var veiculoParaRemover = repo.Veiculos.Find(Handle);repo.Veiculos.Find(Handle);

                repo.Veiculos.Remove(veiculoParaRemover);
                repo.SaveChanges();           
            }
        }

        public IList<Veiculos> Lista()
        {
            using (var repo = new SistemaEstacionamentosContext())
            {
                return repo.Veiculos.ToList();
            }
        }

        public void Editar(int Handle)
        {
            using (var repo = new SistemaEstacionamentosContext())
            {
                var veiculoParaAtualizar = repo.Veiculos.FirstOrDefault(x => x.Handle == Handle );
                repo.Veiculos.Update(veiculoParaAtualizar);

                repo.SaveChanges();
            }
        }

    }
}