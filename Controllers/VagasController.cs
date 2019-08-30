using SistemaDeEstacionamentos;
using SistemaDeEstacionamentos.Controller;
using SistemaGestaoEstacionamentos.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaGestaoEstacionamentos.Controllers
{
    public class VagasController : Controller
    {
        // GET: Vagas

        public ActionResult Index(int Handle)
        {
            VagasDAO dao = new VagasDAO();
            ViewBag.Vagas = dao.Lista().Where(x => x.EstacionamentoId == Handle);
            ViewBag.EstacionamentoId = Handle;
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


        [HttpGet]
        public ActionResult CadastrarVaga(int Handle)
        {
            Vagas vaga = new Vagas();
            vaga.EstacionamentoId = Handle;
            return View(vaga);
        }
        [HttpPost]
        public ActionResult CadastrarVaga(Vagas vaga)
        {
            VagasDAO dao = new VagasDAO();
            EstacionamentosDAO Edao = new EstacionamentosDAO();
            dao.Gravar(vaga);
            return View();
        }

        public ActionResult EditarVaga(int vagaId)
        {
            VagasDAO dao = new VagasDAO();
            var vaga = dao.Buscar(vagaId);
            dao.Editar(vaga);
            return View();
        }

        public ActionResult ExcluirVaga(int Handle)
        {
            VagasDAO dao = new VagasDAO();
            var vaga = dao.Buscar(Handle);
            dao.Excluir(vaga);
            return View();
        }
    }
}