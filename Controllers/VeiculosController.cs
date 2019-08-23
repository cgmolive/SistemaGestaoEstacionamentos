using SistemaDeEstacionamentos;
using SistemaDeEstacionamentos.Model;
using SistemaGestaoEstacionamentos.DAOs;
using SistemaGestaoEstacionamentos.Filtros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaGestaoEstacionamentos.Controllers
{
    [AutorizacaoFilter]
    public class VeiculosController : Controller
    {
        // GET: Veiculo
        //[HttpGet]
        public ActionResult Index()
        {
            VeiculosDAO dao = new VeiculosDAO();
            Usuarios user = (Usuarios)Session["usuarioLogado"];
            IList<Veiculos> veiculos = dao.Lista();
            var veiculosUsuario = dao.Lista().Where(x => x.MotoristaId == user.Handle);
            return View(veiculosUsuario);
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



        public ActionResult Editar(int Handle)
        {
            VeiculosDAO dao = new VeiculosDAO();
            //Veiculos paraLocalizar = dao.Editar(Handle);
            //Mover para ViewBag
            //Retornar pra  View
            return View();
        }

        public ActionResult CadastrarVeiculo()
        {
            Usuarios user = (Usuarios)Session["usuarioLogado"];
            Veiculos veiculo = new Veiculos();
            return View(veiculo);
        }

        [HttpPost]
        public ActionResult CadastrarVeiculo(Veiculos veiculos)
        {
            Usuarios user = (Usuarios)Session["usuarioLogado"];
            VeiculosDAO dao = new VeiculosDAO();
            veiculos.MotoristaId = user.Handle;
            if (ModelState.IsValid)
            {
                dao.Gravar(veiculos);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Excluir(long Handle)

       {
            VeiculosDAO dao = new VeiculosDAO();
            Veiculos veiculo = dao.BuscaPorId(Handle);
            dao.Excluir(veiculo);
            return View();
        }


        //[HttpGet]
        //public ActionResult DefinirCarroPadrao(long Handle)
        //{
        //    VeiculosDAO dao = new VeiculosDAO();
        //    var veiculo = dao.BuscaPorId(Handle);
        //    return View("DefinirCarroPadrao",veiculo);
        //}

        [HttpGet]
        public ActionResult DefinirCarroPadrao (long Handle)
        {
            
            Usuarios user = (Usuarios)Session["usuarioLogado"];
            UsuariosDAO dao = new UsuariosDAO();
            VeiculosDAO Vdao = new VeiculosDAO();
            var veiculo = Vdao.BuscaPorId(Handle);
            user.carroPadraoId = veiculo.Handle;
            
            dao.Editar(user);
            return View();
        }


    }
}