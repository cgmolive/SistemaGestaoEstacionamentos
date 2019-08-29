using SistemaDeEstacionamentos;
using SistemaDeEstacionamentos.Controller;
using SistemaDeEstacionamentos.Model;
using SistemaGestaoEstacionamentos.Filtros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaGestaoEstacionamentos.Controllers
{

    public class TicketsController : Controller
    {
        // GET: Tickets

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
        [AutorizacaoFilter]
        public ActionResult Index()
        {
            var user = (Usuarios)Session["UsuarioLogado"];
                TicketDAO dao = new TicketDAO();

            if (dao.Lista().Where(x => x.VeiculoId == user.carroPadraoId) == null)

            {


                return RedirectToAction("SemTicket", "Tickets");
            }
            else
            {
                var tickets = dao.Lista().Where(x => x.VeiculoId == user.carroPadraoId);


            ViewBag.Tickets = tickets;
                return View();
            }
        }
        [HttpGet]
        public ActionResult GerarTicket()
        {
            Usuarios user = (Usuarios)Session["usuarioLogado"];
            if (user.carroPadraoId == 0)
            {
                return RedirectToAction("SemCarroPadrao","Veiculos");
            }
            EstacionamentosDAO dao = new EstacionamentosDAO();
            var lista = dao.Lista();
            ViewBag.Estacionamentos = lista;
            return View();
        }
        [HttpPost]
        [AutorizacaoFilter]
        public ActionResult GerarTicket(Tickets ticket)
        {
            Usuarios user = (Usuarios)Session["usuarioLogado"];
            
            ticket.VeiculoId = user.carroPadraoId;
            TicketDAO dao = new TicketDAO();
            dao.GerarTicket(ticket);
            return RedirectToAction("Index");
        }
        [AutorizacaoFilter]
        public ActionResult ValidarTicket(Tickets ticket)
        {
            TicketDAO dao = new TicketDAO();
            var ticketABuscar = dao.BuscaTicketPorId(ticket.Handle);
            if (ticketABuscar.Validado == false)
                {
                Usuarios user = (Usuarios)Session["usuarioLogado"];
  
               
                EstacionamentosDAO estacionamentosDAO = new EstacionamentosDAO();
                var tabelaDePreco = estacionamentosDAO.BuscarTabelaDePreco(ticketABuscar.EstacionamentoId);

                ticket.DataHoraEntrada = ticketABuscar.DataHoraEntrada;
 
                ticket.ValidaTicket(ticket, tabelaDePreco);
                ticket.Validade = ticketABuscar.Validade;
                ticket.VeiculoId = user.carroPadraoId;
                ticket.EstacionamentoId = ticketABuscar.EstacionamentoId;
                dao.Valida(ticket);
                return View();
             }
            else
            {
                return RedirectToAction("TicketJaValidado");
            }
          
        }
        [AutorizacaoAdmin]
        public ActionResult ListarTodos()
        {
            TicketDAO dao = new TicketDAO();
            var tickets = dao.Lista();
            ViewBag.Tickets = tickets;
            return View();
        }
        [HttpGet]
        public ActionResult SemTicket()
        {
            return View();
        }
        public ActionResult TicketJaValidado()
        {
            return View();
        }
    }
}

   