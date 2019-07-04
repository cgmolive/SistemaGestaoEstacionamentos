using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeEstacionamentos
{
   public class Program
    {
        static void Main(string[] args)
        {


            
        }

        private static void gravarUsandoEntity()
        {
            Usuarios u = new Usuarios("Cassius", "Rua fictícia","Jardim do sei lá das quantas","Complemento", 309, "123455678", "usuario", "senha"; 
            using (var usuarios = new UsuariosContext())
            {
                usuarios.Usuarios.Add(u);
                usuarios.SaveChanges();
            }
        }
    }
}
