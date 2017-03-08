using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAO.Repositories;
using Model.Entities;
using O2M.UtilWEB;

namespace O2M.Controllers
{
    public class LeadController : Controller
    {
        // GET: Lead
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Listar(Indicado.StatusLead? status)
        {
            try
            {
                var id = Sessao.SelecionarIDUsuarioLogado();
                IEnumerable<Indicado> leads;
                if (!status.HasValue)
                {
                    leads = new UOW().IndicadoRep.Get(i => i.CodParceiro == id);
                }
                else
                {
                    leads = new UOW().IndicadoRep.Get(i => i.CodParceiro == id && i.Status == status.Value);
                }
                
                return View(leads);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [Authorize]
        public ActionResult Cadastro(Indicado indicado)
        {
            if (ModelState.IsValid)
            {
                var uow = new UOW();
                indicado.Status = Indicado.StatusLead.Pendente;
                uow.IndicadoRep.Insert(indicado);
                uow.Save();
            }
            return View(indicado);
        }

        public ActionResult Visualizar(int id)
        {
            try
            {
                var indicado = new UOW().IndicadoRep.GetFirst(i => i.CodIndicado == id);
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

        public ActionResult InserirComissao(int id,decimal? comissao)
        {
            try
            {
                if (Request.HttpMethod == "POST")
                {
                    var uow = new UOW();
                    var indicado = uow.IndicadoRep.GetFirst(i => i.CodIndicado == id);
                    indicado.ValorLead = comissao.Value;
                    uow.IndicadoRep.Update(indicado);
                    uow.Save();
                }
                return View();
            }
            catch (Exception e)
            {
                
                throw;
            }
        }
    }
}