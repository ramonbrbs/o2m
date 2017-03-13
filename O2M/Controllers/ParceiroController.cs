using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DAO.Repositories;
using Model.Entities;

namespace O2M.Controllers
{
    public class ParceiroController : Controller
    {
        // GET: Parceiro
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cadastro(Parceiro p)
        {
            if (ModelState.IsValid)
            {
                var uow = new UOW();
                uow.ParceiroRep.Insert(p);
                uow.Save();
                return View();
            }
            return View();
        }

        public ActionResult Login(string login, string senha)
        {
            var uow = new UOW();
            var parceiro = uow.ParceiroRep.GetFirst(p => p.Email == login && p.Senha == senha && p.IsAdmin == false);
            if (parceiro != null)
            {
                FormsAuthentication.SetAuthCookie(parceiro.CodParceiro.ToString(), false);
            }
            return View();
        }

        public ActionResult Editar(Parceiro p)
        {
            if (ModelState.IsValid)
            {
                var uow = new UOW();
                uow.ParceiroRep.Update(p);
                return View();
            }
            return View();
        }
    }
}