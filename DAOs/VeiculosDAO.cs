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
                if(veiculo.Placa != null)
                {
                    repo.Veiculos.Add(veiculo);
                    repo.SaveChanges();
                }
                else
                {
                    throw new CampoNuloException();
                }
            }
        }

        public void Excluir(Veiculos veiculo)
        {
            using (var repo = new SistemaEstacionamentosContext())
            {
                veiculo.Ativo = false;
                repo.Veiculos.Update(veiculo);
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

        public void Editar(Veiculos veiculoParaAtualizar)
        {
            using (var repo = new SistemaEstacionamentosContext())
            {
                repo.Veiculos.Update(veiculoParaAtualizar);
                repo.SaveChanges();
            }
        }
        public Veiculos BuscaPorId(long Handle)
        {
            using (var repo = new SistemaEstacionamentosContext())
                return repo.Veiculos.FirstOrDefault(x => x.Handle == Handle);
        }


    }
}