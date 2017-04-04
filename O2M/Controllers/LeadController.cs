using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;
using DAO.Repositories;
using Model.Entities;
using O2M.UtilWEB;

namespace O2M.Controllers
{
    [Authorize]
    public class LeadController : BaseController
    {
        // GET: Lead
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Listar(Indicado.StatusLead? status, int page = 1)
        {
            try
            {
                var id = Sessao.SelecionarIDUsuarioLogado();
                IEnumerable<Indicado> leads;
                var pagRN = new PaginacaoRN<Indicado>();
                Paginacao<Indicado> pag = new Paginacao<Indicado>();
                
                if (!status.HasValue)
                {
                    pag = pagRN.GetPaginacao(page, i => i.CodParceiro == id,
                        orderBy: indicados => indicados.OrderBy(i => i.CodIndicado), pageSize: 1);
                }
                else
                {
                    pag = pagRN.GetPaginacao(page, i => i.CodParceiro == id && i.Status == status.Value,
                        orderBy: indicados => indicados.OrderBy(i => i.CodIndicado));
                    
                }
                ViewBag.Pagination = pag;
                return View(pag.Result);
            }
            catch (Exception e)
            {
                throw;
            }
        }


        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        [Authorize]
        public ActionResult Cadastro(Indicado indicado)
        {
            var operadoras = new List<SelectListItem>();
            operadoras.Add(new SelectListItem() { Value = "Claro", Text = "Claro" });
            operadoras.Add(new SelectListItem() { Value = "Oi", Text = "Oi" });
            operadoras.Add(new SelectListItem() { Value = "Tim", Text = "Tim" });
            operadoras.Add(new SelectListItem() { Value = "Vivo", Text = "Vivo" });
            ViewBag.Operadoras = operadoras;
            if (Request.HttpMethod == "GET")
            {
                return View();
            }
            if (ModelState.IsValid)
            {
                var uow = new UOW();
                indicado.Status = Indicado.StatusLead.Pendente;
                indicado.CodParceiro = Convert.ToInt32(User.Identity.Name);
                indicado.DataEnvio = DateTime.Now;
                uow.IndicadoRep.Insert(indicado);
                
                
                uow.Save();
                return RedirectToAction("Visualizar","Lead", new { id=indicado.CodIndicado});
            }
            return View(indicado);
        }

        public ActionResult Visualizar(int id)
        {
            try
            {
                var codParceiro = Convert.ToInt32(User.Identity.Name);
                var indicado = new UOW().IndicadoRep.GetFirst(i => i.CodIndicado == id && i.CodParceiro == codParceiro,includeProperties:"Parceiro");
                if (indicado == null)
                {
                    return HttpNotFound();
                }
                return View(indicado);
            }
            catch (Exception e)
            {
                
                throw;
            }
        }

        public ActionResult Editar(Indicado indicado)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var uow = new UOW();
                    uow.IndicadoRep.Update(indicado);
                    uow.Save();
                }
                
                return View(indicado);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        
    }
}