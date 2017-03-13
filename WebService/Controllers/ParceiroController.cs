using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Entities;

namespace WebService.Controllers
{
    public class ParceiroController : Controller
    {
        // GET: Parceiro
        public ActionResult Cadastro(Parceiro p)
        {
            if (!ModelState.IsValid)
            return View();
        }
    }
}