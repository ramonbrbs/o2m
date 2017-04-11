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

        public async static Task<WSResponse<List<Indicado>>> Listar(Parceiro p, int? status = null, int pag = 0)
        {
            try
            {
                var url = Constantes.EnderecoWS + "/Lead/Listar";
                OpenXamarin.WebRequest.Request req = new OpenXamarin.WebRequest.Request(url, new Dictionary<string, string>() { { "Auth", p.Token } });

                return await req.Get<WSResponse<List<Indicado>>>();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async static Task<WSResponse<Indicado>> Visualizar(int cod, Parceiro p)
        {
            try
            {
                var url = Constantes.EnderecoWS + "/Lead/Info";
                OpenXamarin.WebRequest.Request req = new OpenXamarin.WebRequest.Request(url, new Dictionary<string, string>() { { "Auth", p.Token } });
                var parametors = new Dictionary<string, string>();
                parametors.Add("codIndicado", cod.ToString());
                return await req.Get<WSResponse<Indicado>>(parametors);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
