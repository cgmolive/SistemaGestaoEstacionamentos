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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ValidarTicket(Tickets ticket)
        {
            ticket.validaTicket();
            return View();
        }
    }
}

   