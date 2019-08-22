using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using SistemaDeEstacionamentos;
using SistemaDeEstacionamentos.Model;
using SistemaGestaoEstacionamentos.DAOs;
using SistemaGestaoEstacionamentos.Filtros;

namespace SistemaGestaoEstacionamentosMVC.Controllers
{
    public class UsuariosController : Controller
    {

        [AutorizacaoFilter]
        public ActionResult Index()
        {
        
            UsuariosDAO dao = new UsuariosDAO();
            IList<Usuarios> usuarios = dao.Lista();
            ViewBag.Usuarios = usuarios;
            return View();
        }

        public ActionResult Adicionar(string nome, int CEP, string cpf, string nomeDeUsuario, string senha, string logradouro, string cidade, string estado)
        {

            Usuarios usuario = new Usuarios(nome, CEP, cpf, nomeDeUsuario, senha,logradouro, cidade, estado);
            UsuariosDAO dao = new UsuariosDAO();
            dao.Gravar(usuario);


            return View();
        }

        public ActionResult Form()
        {

            return View();
        }


        public ActionResult Delete(int Handle)
        {
            
            return View();
        }
    }

}