using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAO.Repositories;
using Model.Entities;
using Model.WS;

namespace WS.Controllers
{
    [Authorize]
    public class LeadController : ApiController
    {
        [Route("Lead/Cadastro")]
        public WSResponse<object> Cadastrar(Indicado indicado)
        {
            var resp = new WSResponse<object>();
            try
            {
                if (ModelState.IsValid)
                {
                    var uow = new UOW();
                    indicado.Status = Indicado.StatusLead.Pendente;
                    indicado.CodParceiro = Convert.ToInt32(RequestContext.Principal.Identity.Name);
                    indicado.DataEnvio = DateTime.Now;
                    resp.Success = true;
                    uow.IndicadoRep.Insert(indicado);
                    uow.Save();
                }

                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        resp.Errors.Add(error.ErrorMessage);
                    }
                }
                return resp;
            }
            catch (Exception e)
            {
                return resp;
            }
            


        }

        public WSResponse<List<Indicado>>  Listar(Indicado.StatusLead? status, int page = 1)
        {
            var resp = new WSResponse<List<Indicado>>();
            var u = new UOW();
            if (status != null)
            {
                resp.Content = u.IndicadoRep.Get(page: page, orderBy: indicados => indicados.OrderBy(i => i.CodParceiro)).ToList();
            }
            else
            {
                resp.Content = u.IndicadoRep.Get(i => i.Status == status.Value, page: page,
                    orderBy: indicados => indicados.OrderBy(i => i.CodParceiro)).ToList();
            }
            return resp;


        }

        public WSResponse<object> Total(Indicado.StatusLead? status)
        {
            try
            {
                var resp = new WSResponse<object>();
                var u = new UOW();
                if (status != null)
                {
                    resp.Content = u.IndicadoRep.Count();
                }
                else
                {
                    resp.Content = u.IndicadoRep.Count(i => i.Status == status);
                }
                return resp;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


    }
}
