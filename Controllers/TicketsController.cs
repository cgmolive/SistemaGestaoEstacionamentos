﻿using SistemaDeEstacionamentos;
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
            Usuarios user = (Usuarios)Session["usuarioLogado"];
            TicketDAO dao = new TicketDAO();
            ticket.validaTicket();
            ticket.VeiculoId = user.carroPadraoId;
            dao.Valida(ticket);
            return View();
        }

        public ActionResult CadastrarCarro()
        {
            return View();
        }
    }
}

   