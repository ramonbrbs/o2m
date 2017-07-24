using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DAO.Repositories;
using Model.Entities;
using O2M.Models.Parceiro;

namespace O2M.Controllers
{
    public class ParceiroController : BaseController
    {
        // GET: Parceiro
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cadastro(Parceiro p)
        {
            var bancos = new UOW().BancoRep.Get(pagesize:999, orderBy: q => q.OrderBy(a => a.CodBanco)).Select(b => new SelectListItem() { Value = b.CodBanco.ToString(), Text = b.Nome }).ToList();

            ViewBag.bancos = bancos;
            if (ModelState.IsValid)
            {
                var uow = new UOW();
                p.Token = Util.Crypto.ConvertSHA1(DateTime.Now.ToString());
                uow.ParceiroRep.Insert(p);
                uow.Save();
                return RedirectToAction("Login");
            }
            return View();
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Login(string login, string senha)
        {
            if (Request.HttpMethod == "GET")
            {
                return View();
            }
            var uow = new UOW();
            senha = Util.Crypto.ConvertSHA1(senha);
            var parceiro = uow.ParceiroRep.GetFirst(p => p.Email == login && p.Senha == senha, orderBy: o => o.OrderBy( u => u.CodParceiro));
            if (parceiro != null)
            {
                FormsAuthentication.SetAuthCookie(parceiro.CodParceiro.ToString(), false);
                if (parceiro.IsAdmin)
                {
                    return RedirectToAction("ListarLeads", "Admin");
                }
                return RedirectToAction("Index","Home");
            }
            return View();
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Editar(Parceiro p = null)
        {
            var codParceiro = Convert.ToInt32(User.Identity.Name);
            var bancos = new UOW().BancoRep.Get(pagesize: 999, orderBy: q => q.OrderBy(a => a.CodBanco)).Select(b => new SelectListItem() { Value = b.CodBanco.ToString(), Text = b.Nome }).ToList();
            ViewBag.bancos = bancos;
            var parceiro = new UOW().ParceiroRep.GetFirst(pa => pa.CodParceiro == codParceiro);
            if (Request.HttpMethod == "POST")
            {
                if (ModelState.IsValid)
                {
                    p.Nome = parceiro.Nome;
                    p.CodParceiro = parceiro.CodParceiro;
                    p.Documento = parceiro.Documento;
                    p.Email = parceiro.Email;
                    var uow = new UOW();
                    if (String.IsNullOrEmpty(p.Senha))
                    {
                        p.setSenhaSemMod(parceiro.Senha);
                    }
                    uow.ParceiroRep.Update(p);
                    return View();
                }
            }
            
            return View(parceiro);
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult AlterarSenha(AlterarSenhaVM model)
        {
            try
            {
                var codParceiro = Convert.ToInt32(User.Identity.Name);
                if (Request.HttpMethod == "POST")
                {
                    if (ModelState.IsValid)
                    {
                        if (model.SenhaNova != model.SenhaNova2)
                        {
                            ModelState.AddModelError("SenhaNova", "Senhas não conferem");
                            return View();
                        }
                        else
                        {
                            var uow = new UOW();
                            var senha = Util.Crypto.ConvertSHA1(model.SenhaNova);
                            if (uow.ParceiroRep.GetFirst(p => p.CodParceiro == codParceiro && p.Senha == senha) == null)
                            {
                                ModelState.AddModelError("Senha", "Senha atual incorreta.");
                            }
                            else
                            {
                                var parceiro = uow.ParceiroRep.GetFirst(p => p.CodParceiro == codParceiro);
                                parceiro.Senha = model.SenhaNova;
                                uow.ParceiroRep.Update(parceiro);
                                uow.Save();
                                return RedirectToAction("Index", "Home");
                            }
                        }
                    }
                }
                return View();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}