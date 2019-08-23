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
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CadastrarVaga(int estacionamentoId)
        {
            VagasDAO dao = new VagasDAO();
            EstacionamentosDAO Edao = new EstacionamentosDAO();
            var estacionamento = Edao.Recuperar(estacionamentoId);
            Vagas vaga = new Vagas();
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
    }
}