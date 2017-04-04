using System;
using System.Threading.Tasks;
using Movel.Model;
using Movel.Model.Constantes;

namespace Movel.WS
{
    public class ParceiroWS
    {
        public async static Task<WSResponse<Parceiro>> Login(LoginVM login)
        {
            try
            {
                var url = Constantes.EnderecoWS + "/Parceiro/Login";
                OpenXamarin.WebRequest.Request req = new OpenXamarin.WebRequest.Request(url);

                return await req.Post<WSResponse<Parceiro>>(login);
            }
            catch (Exception e)
            {
                throw;
            }
            
            //var result = await retorno.Content.ReadAsStringAsync();
            //return JsonConvert.DeserializeObject<string>(result);
        }
        public async static Task<WSResponse<object>> Cadastro(Parceiro parceiro)
        {
            try
            {
                var url = Constantes.EnderecoWS + "/Parceiro/Cadastro";
                OpenXamarin.WebRequest.Request req = new OpenXamarin.WebRequest.Request(url);

                return await req.Post<WSResponse<object>>(parceiro);
            }
            catch (Exception e)
            {
                throw;
            }
            //var result = await retorno.Content.ReadAsStringAsync();
            //return JsonConvert.DeserializeObject<string>(result);
        }
    }
}
