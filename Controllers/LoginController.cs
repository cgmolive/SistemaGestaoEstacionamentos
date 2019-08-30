using SistemaDeEstacionamentos;
using SistemaGestaoEstacionamentos.Filtros;
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

        protected override void OnException(ExceptionContext filterContext)
        {
            Exception exception = filterContext.Exception;
            //Logging the Exception
            filterContext.ExceptionHandled = true;


            var Result = this.View("Error", new HandleErrorInfo(exception,
                filterContext.RouteData.Values["controller"].ToString(),
                filterContext.RouteData.Values["action"].ToString()));

            filterContext.Result = Result;

        }


        public ActionResult AutenticaLogin(string login, string senha)
        {
            UsuariosDAO dao = new UsuariosDAO();
            Usuarios usuario = dao.BuscaUsuario(login, senha);
            Usuarios admin = dao.BuscarAdministrador(login, senha);

            

            if (admin != null)
            {
                Session["AdminLogado"] = admin;
                return RedirectToAction("MenuDoAdministrador", "Home");
            }
            else if (usuario != null)
            {
                Session["UsuarioLogado"] = usuario;
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