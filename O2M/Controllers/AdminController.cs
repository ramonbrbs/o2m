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
    [Authorize(Roles = "ADMIN")]
    public class AdminController : BaseController
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListarLeads(Indicado.StatusLead? status, int page = 0)
        {
            try
            {
                ViewBag.Status = status;
                var id = Sessao.SelecionarIDUsuarioLogado();
                IEnumerable<Indicado> leads;
                var pagRN = new PaginacaoRN<Indicado>();
                Paginacao<Indicado> pag = new Paginacao<Indicado>();
                if (!status.HasValue)
                {
                    pag = pagRN.GetPaginacao(page,
                        orderBy: indicados => indicados.OrderBy(i => i.CodIndicado), include: "Parceiro");
                }
                else
                {
                    pag = pagRN.GetPaginacao(page, i => i.Status == status.Value,
                        orderBy: indicados => indicados.OrderBy(i => i.CodIndicado), include: "Parceiro");

                }
                ViewBag.Pagination = pag;


                

                return View(pag.Result);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ActionResult ListarLeadsParceiro(int id, Indicado.StatusLead? status)
        {
            try
            {
                IEnumerable<Indicado> leads;
                if (!status.HasValue)
                {
                    leads = new UOW().IndicadoRep.Get(i => i.CodParceiro == id);
                }
                else
                {
                    leads = new UOW().IndicadoRep.Get(i => i.CodParceiro==id && i.Status == status.Value);
                }

                return View(leads);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        public ActionResult ListarParceiros(string busca, int page =1)
        {
            try
            {
                List<Parceiro> parceiros;
                var pagRN = new PaginacaoRN<Parceiro>();
                Paginacao<Parceiro> pag = new Paginacao<Parceiro>();
                
                var uow = new UOW();
                
                if (String.IsNullOrEmpty(busca))
                {
                    
                    pag = pagRN.GetPaginacao(page,
                        orderBy: indicados => indicados.OrderBy(i => i.CodParceiro), pageSize: 1);
                    
                }
                else
                {
                    pag = pagRN.GetPaginacao(page, filter: p => p.Nome.ToUpper().Contains(busca.ToUpper()),
                        orderBy: indicados => indicados.OrderBy(i => i.CodParceiro), pageSize: 1);
                    //parceiros = new UOW().ParceiroRep.Get(p => p.Nome.ToUpper().Contains(busca.ToUpper()), page: page, orderBy: q => q.OrderBy(p => p.CodParceiro)).ToList();
                }
                return View(pag.Result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public ActionResult VisualizarParceiro(int id)
        {
            try
            {
                var uow = new UOW();
                var parceiro = uow.ParceiroRep.GetFirst(p => p.CodParceiro == id, includeProperties: "Indicados,Banco");
                return View(parceiro);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public ActionResult NegarComissao(int id)
        {
            try
            {
                var uow = new UOW();
                var indicado = uow.IndicadoRep.GetFirst(i => i.CodIndicado == id);
                indicado.Status = Indicado.StatusLead.Negado;
                uow.Save();
                return RedirectToAction("Visualizar", "Lead", new {id = id});
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public ActionResult InserirComissao(int id, decimal? ValorLead)
        {
            try
            {
                var uow = new UOW();
                var indicado = uow.IndicadoRep.GetFirst(i => i.CodIndicado == id);
                if (Request.HttpMethod == "POST")
                {
                    
                    indicado.ValorLead = ValorLead.Value;
                    indicado.Status = Indicado.StatusLead.Executado;
                    uow.IndicadoRep.Update(indicado);
                    uow.Save();
                    return RedirectToAction("Visualizar","Lead", new {id = indicado.CodIndicado});
                }
                return View(indicado);
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}