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
        public ActionResult Index()
        {
            VeiculosDAO dao = new VeiculosDAO();
            IList<Veiculos> veiculos = dao.Lista();
            return View(veiculos);
        }

        public ActionResult Editar(int Handle)
        {
            VeiculosDAO dao = new VeiculosDAO();
            //Veiculos paraLocalizar = dao.Editar(Handle);
            //Mover para ViewBag
            //Retornar pra  View
            return View();
        }

        public ActionResult CadastrarVeiculo(string placa, string tipoDoCarro)
        {

            Usuarios user = (Usuarios)Session["usuarioLogado"];
            Veiculos veiculo = new Veiculos(placa, tipoDoCarro);
            VeiculosDAO dao = new VeiculosDAO();
            veiculo.MotoristaId = user.Handle;
            dao.Gravar(veiculo);
            return View();
        }
        [HttpGet]
        public ActionResult Excluir(long Handle)

       {
            VeiculosDAO dao = new VeiculosDAO();
            Veiculos veiculo = dao.BuscaPorId(Handle);
            return View(veiculo);
        }

        [HttpPost]
        public ActionResult Excluir(Veiculos veiculo)
        {
            VeiculosDAO dao = new VeiculosDAO();
            dao.Excluir(veiculo);
            return RedirectToAction("Index", "Veiculos");
           
        }
    

        public ActionResult DefinirCarroAtivo()
        {
            Usuarios user = (Usuarios)Session["usuarioLogado"];
            //user.carroPadraoId = IdDoCarroClicado;
            return View();
        }

    }
}