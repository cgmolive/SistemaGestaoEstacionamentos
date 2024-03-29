﻿using System;
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


        protected override void OnException(ExceptionContext filterContext)
        {
            Exception exception = filterContext.Exception;
            filterContext.ExceptionHandled = true;


            var Result = this.View("Error", new HandleErrorInfo(exception,
                filterContext.RouteData.Values["controller"].ToString(),
                filterContext.RouteData.Values["action"].ToString()));

            filterContext.Result = Result;

        }


        [AutorizacaoAdmin]
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
                return RedirectToAction("Login", "Login");
        }



        

        public ActionResult Form()
        {
            Usuarios usuario = new Usuarios();
            return View(usuario);
        }

        [AutorizacaoAdmin]
        public ActionResult Delete(int Handle)
        {
          
                UsuariosDAO dao = new UsuariosDAO();
                var usuario = dao.RecuperarUsuario(Handle);
                dao.Excluir(usuario);
                return View();
        }

        
        [AutorizacaoAdmin]
        [HttpGet]
        public ActionResult EditarLoginAdmin()
        {
            Usuarios administrador = (Usuarios)Session["AdminLogado"];
            return View(administrador);
        }
        [AutorizacaoAdmin]
        [HttpPost]
        public ActionResult EditarLoginAdmin(Usuarios administrador)
        {
            UsuariosDAO dao = new UsuariosDAO();
            dao.Editar(administrador);
            return RedirectToAction("MenuDoAdministrador", "Home");
        }

        [AutorizacaoFilter]
            public ActionResult MeuPerfil()
        {
            Usuarios usuario = (Usuarios)Session["UsuarioLogado"];
            ViewBag.Usuarios = usuario;
            return View();
        }

        [AutorizacaoFilter]
        [HttpGet]
        public ActionResult EditarUsuario()
        {
            Usuarios usuario = (Usuarios)Session["UsuarioLogado"];
            return View(usuario);
        }
        [AutorizacaoFilter]
        [HttpPost]
        public ActionResult EditarUsuario(Usuarios usuario)
        {
            UsuariosDAO dao = new UsuariosDAO();
            dao.Editar(usuario);
            return RedirectToAction("Index", "Tickets");
        }
    }

}