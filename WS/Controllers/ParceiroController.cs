using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using DAO.Migrations;
using DAO.Repositories;
using Model.Entities;
using Model.WS;

namespace WS.Controllers
{
    public class ParceiroController : ApiController
    {
        [Route("Parceiro/Cadastro")]
        public WSResponse<object> Cadastro(Parceiro p)
        {
            var resp = new WSResponse<object>();
            try
            {
                if (ModelState.IsValid)
                {

                    p.Token = Util.Crypto.ConvertSHA1(DateTime.Now.ToString());
                
                    var u = new UOW();
                    if (u.ParceiroRep.GetFirst(pa => pa.Email == p.Email) != null)
                    {
                        ModelState.AddModelError("Email","E-mail já cadastrado");
                    }
                
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

        [HttpGet]
        [Route("Parceiro/Bancos")]
        public WSResponse<List<Banco>> Bancos()
        {
            var resp = new WSResponse<List<Banco>>();
            try
            {
                resp.Content = new UOW().BancoRep.Get(orderBy:bancos => bancos.OrderBy(b => b.Nome)).ToList();
                resp.Success = true;
                return resp;
            }
            catch (Exception e)
            {
                return resp;
            }
        }

        [Route("Parceiro/Login")]
        public WSResponse<Parceiro> Login(LoginVM login)
        {
            var resp = new WSResponse<Parceiro>();
            try
            {
                
                var uow = new UOW();
                login.Senha = Util.Crypto.ConvertSHA1(login.Senha);
                var parceiro = uow.ParceiroRep.GetFirst( p => p.Email == login.Email && p.Senha == login.Senha);
                if (parceiro != null)
                {
                    resp.Content = parceiro;
                    resp.Success = true;
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