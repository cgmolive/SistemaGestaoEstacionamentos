using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeEstacionamentos.Controller
{
    public class EstacionamentosDAO
    {
        private static void Gravar()
        {
            Estacionamento e = new Estacionamento();

            using (var repo = new SistemaEstacionamentosContext())
            {
                repo.Estacionamentos.Add(e);
                repo.SaveChanges();
            }
        }

        private static void Recuperar()
        {
            using (var repo = new SistemaEstacionamentosContext())
            {
                IList<Estacionamento> estacionamentos = repo.Estacionamentos.ToList();
            }
        }

        private static void Excluir()
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

        private static void Editar(int Handler)
        {
            using (var repo = new SistemaEstacionamentosContext())
            {
                var EstacionamentoParaAtualizar = repo.Estacionamentos.Find(Handler);
                //Definir campo a ser atualizado
                repo.Estacionamentos.Update(EstacionamentoParaAtualizar);

                repo.SaveChanges();
            }
        }
    }
}
