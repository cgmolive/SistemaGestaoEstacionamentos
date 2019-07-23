using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaDeEstacionamentos;

namespace SistemaGestaoEstacionamentosMVC.Controllers
{
    public class UsuariosController : Controller
    {
        public IActionResult Index()
        {

            UsuariosDAO dao = new UsuariosDAO();
            IList<Usuarios> usuarios = dao.Lista();
            ViewBag.Usuarios = usuarios;
            return View();
        }

        public ActionResult Adicionar(String nome, string nomeDeUsuario, string senha, string cpf, int CEP)
        {
            UsuariosDAO usuarios = new UsuariosDAO();
            Usuarios usuario = new Usuarios(new Nome(nome), new Endereco(CEP), new CPF(cpf), new CredenciaisDeAcesso(nomeDeUsuario, senha));

        

            return View();
        }

        public ActionResult Form()
        {

            return View();
        }

    }

}