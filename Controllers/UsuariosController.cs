using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using SistemaDeEstacionamentos;
using SistemaDeEstacionamentos.Model;
using SistemaGestaoEstacionamentos.DAOs;
using SistemaGestaoEstacionamentos.Filtros;

namespace SistemaGestaoEstacionamentosMVC.Controllers
{
    public class UsuariosController : Controller
    {

        [AutorizacaoFilter]
        public ActionResult Index()
        {
        
            UsuariosDAO dao = new UsuariosDAO();
            IList<Usuarios> usuarios = dao.Lista();
            ViewBag.Usuarios = usuarios;
            return View();
        }


        [HttpPost]
        public ActionResult Adicionar(Usuarios usuario)
        {
            UsuariosDAO dao = new UsuariosDAO();
            dao.Gravar(usuario);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Form()
        {
            Usuarios usuario = new Usuarios();
            return View(usuario);
        }


        public ActionResult Delete(int Handle)
        {
            
            return View();
        }
    }

}