using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaDeEstacionamentos;

namespace SistemaGestaoEstacionamentosMVC.Controllers
{
    public class UsuariosController : Controller
    {
        public IActionResult Index()
        {

            UsuariosDAO dao = new UsuariosDAO();
            IList<Usuarios> usuarios = dao.Lista();
            ViewBag.Usuarios = usuarios;
            return View();
        }

        public ActionResult Adicionar(Usuarios usuario)
        {
            UsuariosDAO usuarios = new UsuariosDAO();
            //usuarios.Gravar(usuario)
            return RedirectToAction("Index");
        }
    }
}