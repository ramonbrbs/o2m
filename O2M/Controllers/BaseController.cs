using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAO.Repositories;

namespace O2M.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            if (System.Web.HttpContext.Current.Request.IsAuthenticated)
            {
                var cod = Convert.ToInt32(System.Web.HttpContext.Current.User.Identity.Name);
                var user = new UOW().ParceiroRep.GetFirst(p => p.CodParceiro == cod);
                ViewBag.User = user;
            }
        }
    }
}