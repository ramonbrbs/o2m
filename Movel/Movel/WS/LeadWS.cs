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
    }
}
