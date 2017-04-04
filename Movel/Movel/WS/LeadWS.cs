using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movel.Model;
using Movel.Model.Constantes;

namespace Movel.WS
{
    public class LeadWS
    {
        public async static Task<WSResponse<object>> Cadastro(Indicado i, Parceiro p)
        {
            try
            {
                var url = Constantes.EnderecoWS + "/Lead/Cadastro";
                OpenXamarin.WebRequest.Request req = new OpenXamarin.WebRequest.Request(url, new Dictionary<string, string>(){{"Auth", p.Token}});

                return await req.Post<WSResponse<object>>(i);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async static Task<WSResponse<object>> Listar(Parceiro p, int status, int pag = 0)
        {
            try
            {
                var url = Constantes.EnderecoWS + "/Lead/Listar";
                OpenXamarin.WebRequest.Request req = new OpenXamarin.WebRequest.Request(url, new Dictionary<string, string>() { { "Auth", p.Token } });

                return await req.Get<WSResponse<object>>(new Dictionary<string, string>(){{"status", status.ToString()}, {"page",pag.ToString()}});
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
