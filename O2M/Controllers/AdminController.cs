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
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListarLeads(Indicado.StatusLead? status)
        {
            try
            {
                IEnumerable<Indicado> leads;
                if (!status.HasValue)
                {
                    leads = new UOW().IndicadoRep.Get();
                }
                else
                {
                    leads = new UOW().IndicadoRep.Get(i=> i.Status == status.Value);
                }

                return View(leads);
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

        public ActionResult ListarParceiros(string busca, int pag =0)
        {
            try
            {
                List<Parceiro> parceiros;
                if (String.IsNullOrEmpty(busca))
                {
                    parceiros = new UOW().ParceiroRep.Get(page: pag).ToList();
                }
                else
                {
                    parceiros = new UOW().ParceiroRep.Get(p => p.Nome.ToUpper().Contains(busca.ToUpper()), page: pag).ToList();
                }
                return View(parceiros);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}