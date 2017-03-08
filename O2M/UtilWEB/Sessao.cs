using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace O2M.UtilWEB
{
    public class Sessao
    {
        public static int SelecionarIDUsuarioLogado()
        {
            try
            {
                return Convert.ToInt16(FormsAuthentication.Decrypt(HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}