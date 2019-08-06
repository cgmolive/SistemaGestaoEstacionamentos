using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using SistemaDeEstacionamentos;

namespace SistemaGestaoEstacionamentosMVC.Controllers
{
    public class UsuariosController : Controller
    {
        public ActionResult Index()
        {

            UsuariosDAO dao = new UsuariosDAO();
            IList<Usuarios> usuarios = dao.Lista();
            ViewBag.Usuarios = usuarios;
            return View();
        }

        public ActionResult Adicionar(string nome, int CEP, string cpf, string nomeDeUsuario, string senha)
        {

            Usuarios usuario = new Usuarios(nome, CEP, cpf, nomeDeUsuario, senha);
            UsuariosDAO dao = new UsuariosDAO();
            dao.Gravar(usuario);


            return View();
        }

        public ActionResult Form()
        {

            return View();
        }

    }

}