using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAO.Repositories;
using Model.Entities;
using Model.WS;

namespace WS.Controllers
{
    public class ParceiroController : Controller
    {
        // GET: Parceiro
        public WSResponse Cadastro(Parceiro p)
        {
            var resp = new WSResponse();
            try
            {
                if (ModelState.IsValid)
                {
                    var u = new UOW();
                    u.ParceiroRep.Insert(p);
                    u.Save();
                    resp.Success = true;
                    return resp;
                }
                var e = ModelState.Values.SelectMany(v => v.Errors);
                foreach(var error in e)
                {
                    resp.Errors.Add(error.ErrorMessage);
                }
                return resp;
            }
            catch (Exception e)
            {
                resp.Success = false;
                return resp;
            }
            

        }
    }
}