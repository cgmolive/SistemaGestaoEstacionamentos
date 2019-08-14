using SistemaDeEstacionamentos.Model;
using SistemaGestaoEstacionamentos.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaGestaoEstacionamentos.Controllers
{
    public class VeiculoController : Controller
    {
        // GET: Veiculo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Editar(int Handle)
        {
            VeiculosDAO dao = new VeiculosDAO();
            //Veiculos paraLocalizar = dao.Editar(Handle);
            //Mover para ViewBag
            //Retornar pra  View
            return View();
        }

        public ActionResult Adicionar(string placa, string tipoDoCarro)
        {
            Veiculos veiculo = new Veiculos(placa, tipoDoCarro);
            VeiculosDAO dao = new VeiculosDAO();
            dao.Gravar(veiculo);
            return View();
        }

        public ActionResult FinalizarEdicao()
        {
            return View();
        }

        public ActionResult Excluir(int Handle)
        {
            VeiculosDAO dao = new VeiculosDAO();
            return View();
        }
    }
}