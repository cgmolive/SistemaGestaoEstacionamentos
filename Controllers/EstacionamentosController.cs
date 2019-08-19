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

        public ActionResult Adicionar(string nome)
        {

            Estacionamento estacionamento = new Estacionamento(nome);
            EstacionamentosDAO dao = new EstacionamentosDAO();
            dao.Gravar(estacionamento);


            return View();
        }

        public ActionResult Editar(int handle)
        {
            return View();
        }

    }
}