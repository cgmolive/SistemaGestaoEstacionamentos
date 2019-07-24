using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeEstacionamentos
{
   public class UsuarioController
    {
        static void Main(string[] args)
        {


            
        }

        private static void gravarUsandoEntity()
        {
            Usuarios u = new Usuarios("Cassius", "Rua fictícia","Jardim do sei lá das quantas","Complemento", 309, "123455678", "usuario", "senha"); 

            using (var repo = new UsuariosContext())
            {
                repo.Usuarios.Add(u);
                repo.SaveChanges();
            }
        }
        private static void RecuperarUsandoEntity()
        {
            using (var repo = new UsuariosContext())
            {
                IList<Usuarios> usuarios = repo.Usuarios.ToList();
            }
        }

        private static void ExcluirUsuarios()
        {
            using (var repo = new UsuariosContext())
            {
                IList<Usuarios> pessoas = repo.Usuarios.ToList();
                foreach (var pessoa in pessoas)
                {
                    repo.Usuarios.Remove(pessoa);
                }
                repo.SaveChanges();
                
            }
        }

        private static void EditarUsuarios(long handler)
        {
            using (var repo = new UsuariosContext())
            {
                repo.Update(handler);
            }
            repo.SaveChanges();
        }

    }
}
