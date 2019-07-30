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

        public ActionResult Adicionar(string nome, int CEP, string cpf, string nomeDeUsuario, string senha)
        {

            Usuarios usuario = new Usuarios(new Nome(nome), new CPF(cpf), new Endereco(CEP), new CredenciaisDeAcesso(nomeDeUsuario, senha));
            UsuariosDAO dao = new UsuariosDAO();
            dao.Gravar(usuario);

        

            return View();
        }

        public ActionResult Form()
        {

            return View();
        }

    }

}