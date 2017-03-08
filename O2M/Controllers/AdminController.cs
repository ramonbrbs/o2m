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
                throw;
            }
        }
    }
}