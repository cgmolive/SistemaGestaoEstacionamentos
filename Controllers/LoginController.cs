using SistemaDeEstacionamentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SistemaGestaoEstacionamentos.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult AutenticaLogin(string login, string senha)
        {
            UsuariosDAO loginDAO = new UsuariosDAO();
            Usuarios usuario = loginDAO.BuscaUsuario(login, senha);

            if (usuario != null)
            {
                Session["LogadoComoUsuario"] = usuario;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.error = "Login ou senha incorretos!";
                return RedirectToAction("Error", "Shared");
            }
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}