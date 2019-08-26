using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using SistemaDeEstacionamentos;
using SistemaDeEstacionamentos.Controller;

namespace SistemaGestaoEstacionamentos.Controllers
{
    public class EstacionamentosController : Controller
    {
        public ActionResult Index()
        {
            EstacionamentosDAO dao = new EstacionamentosDAO();
            IList<Estacionamento> Estacionamento = dao.Lista();
            ViewBag.Estacionamentos = Estacionamento;
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
        public ActionResult Adicionar()
        {

            Estacionamento estacionamento = new Estacionamento();

            


            return View(estacionamento);
        }
        [HttpPost]
        public ActionResult Adicionar(Estacionamento estacionamento)
        {
            EstacionamentosDAO dao = new EstacionamentosDAO();
            dao.Gravar(estacionamento);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int handle)
        {
            return View();
        }

        public ActionResult ListarVagas()
        {
            return View();
        }

        public ActionResult DefinirCarenciaDoEstacionamento(int estacionamentoID, int carencia)
        {
            EstacionamentosDAO dao = new EstacionamentosDAO();
            Estacionamento estacionamento = dao.Recuperar(estacionamentoID);
            estacionamento.MudarCarencia(carencia);
            dao.Editar(estacionamento);
            return View();
        }
        [HttpGet]
        public ActionResult ExibirTabelaDePreco(Estacionamento estacionamento)
        {
            EstacionamentosDAO dao = new EstacionamentosDAO();
            var tabela = dao.BuscarTabelaDePreco(estacionamento.Handle);
            ViewBag.Tabelas = tabela;
            return View();
        }
    }
}