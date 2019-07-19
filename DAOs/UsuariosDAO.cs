using SistemaDeEstacionamentos.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeEstacionamentos
{
   public class UsuariosDAO
    {
 
        public void Gravar()
        {
            Usuarios u = new Usuarios("Cassius", "Rua fictícia","Jardim do sei lá das quantas","Complemento", 309, "123455678", "usuario", "senha"); 

            using (var repo = new SistemaEstacionamentosContext())
            {
                repo.Usuarios.Add(u);
                repo.SaveChanges();
            }
        }
        public void Recuperar()
        {
            using (var repo = new SistemaEstacionamentosContext())
            {
                IList<Usuarios> usuarios = repo.Usuarios.ToList();
            }
        }

        public void Excluir()
        {
            using (var repo = new SistemaEstacionamentosContext())
            {
                IList<Usuarios> pessoas = repo.Usuarios.ToList();
                foreach (var pessoa in pessoas)
                {
                    repo.Usuarios.Remove(pessoa);
                }
                repo.SaveChanges();
                
            }
        }

        public IList<Usuarios> Lista()
        {
            using (var repo = new SistemaEstacionamentosContext())
            {
                return repo.Usuarios.ToList();
            }
        } 

        public  void Editar(int Handler)
        {
            using (var repo = new SistemaEstacionamentosContext())
            {
                var usuarioParaAtualizar = repo.Usuarios.Find(Handler);
                //Definir campo a ser atualizado
                repo.Usuarios.Update(usuarioParaAtualizar);

                repo.SaveChanges();
            }
        }

    }
}
