using SistemaDeEstacionamentos.Controller;
using SistemaDeEstacionamentos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeEstacionamentos
{
    public class UsuariosDAO
    {

        public void Gravar(Usuarios usuario)
        {


            using (var repo = new SistemaEstacionamentosContext())
            {
                CPF validadorCPF = new CPF();
                Nome validadorNome = new Nome();
                if (validadorCPF.IsCpf(usuario.Cpf) == true && validadorNome.validaNome(usuario.Nome) == true)
                {
                    repo.Usuarios.Add(usuario);
                    repo.SaveChanges();
                }
                else
                {
                    throw new CampoInvalidoException();
                }

            }
        }

        public void Excluir(int Handle)
        {
            using (var repo = new SistemaEstacionamentosContext())
            {
                var usuarioParaRemover = repo.Usuarios.Find(Handle);
                repo.Usuarios.Remove(usuarioParaRemover);
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

        public void Editar(Usuarios usuario)
        {
            using (var repo = new SistemaEstacionamentosContext())
            {

                repo.Usuarios.Update(usuario);

                repo.SaveChanges();
            }
        }


        public Usuarios BuscaUsuario(string login, string senha)
        {
            using (var repo = new SistemaEstacionamentosContext())
            {
                return repo.Usuarios.FirstOrDefault(x => x.nomeDeUsuario == login && x.senha == senha);
            }

        }

        public Usuarios BuscarAdministrador(string login, string senha)
        {
            using (var repo = new SistemaEstacionamentosContext())
            {
                return repo.Usuarios.FirstOrDefault(x => x.nomeDeUsuario == login && x.senha == senha && x.Adm == true);
            }

        }

    }
}

 
