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
    [AutorizacaoFilter]
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
        public ActionResult Index()
        {

                TicketDAO dao = new TicketDAO();
                IList<Tickets> tickets = dao.Lista();
                ViewBag.Tickets = tickets;
                return View();
                 
        }


        public ActionResult GerarTicket()
        {
            Usuarios user = (Usuarios)Session["usuarioLogado"];
            
            Tickets ticket = new Tickets();
            ticket.VeiculoId = user.carroPadraoId;
            TicketDAO dao = new TicketDAO();
            dao.GerarTicket(ticket);
            return View();
        }

        public ActionResult ValidarTicket(Tickets ticket)
        {
            if(ticket.Validado == false)
                {
                Usuarios user = (Usuarios)Session["usuarioLogado"];
                TicketDAO dao = new TicketDAO();
                var ticketABuscar = dao.BuscaTicketPorId(ticket.Handle);
                ticket.DataHoraEntrada = ticketABuscar.DataHoraEntrada;
                ticket.ValidaTicket(ticket);
                ticket.Validade = ticketABuscar.Validade;
                ticket.VeiculoId = user.carroPadraoId;
                dao.Valida(ticket);
                return View();
             }
            else
            {
                return RedirectToAction("TicketJaValidado", "Shared");
            }
          
        }


    }
}

   