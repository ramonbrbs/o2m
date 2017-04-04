using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using DAO.Repositories;

namespace WS.Modules
{
    public class BasicAuthHttpModule : IHttpModule
    {
        private const string Realm = "WebAPI";

        public void Init(HttpApplication context)
        {
            // Register event handlers
            context.AuthenticateRequest += OnApplicationAuthenticateRequest;
            context.EndRequest += OnApplicationEndRequest;
        }

        private static void SetPrincipal(IPrincipal principal)
        {
            Thread.CurrentPrincipal = principal;
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }
        }

        private static bool AuthenticateUser(string credentials)
        {
            var encoding = Encoding.GetEncoding("iso-8859-1");
            //credentials = encoding.GetString(Convert.FromBase64String(credentials));




            /* REPLACE THIS WITH REAL AUTHENTICATION
            ----------------------------------------------*/
            var usuario = new UOW().ParceiroRep.GetFirst(p => p.Token == credentials);
            if (usuario == null)
            {
                return false;
            }

            var identity = new GenericIdentity(usuario.CodParceiro.ToString());
            SetPrincipal(new GenericPrincipal(identity, null));

            return true;
        }

        private static void OnApplicationAuthenticateRequest(object sender, EventArgs e)
        {
            var request = HttpContext.Current.Request;
            var authHeader = request.Headers["Auth"];
            if (authHeader != null)
            {
                AuthenticateUser(authHeader);
                //var authHeaderVal = AuthenticationHeaderValue.Parse(authHeader);

                // RFC 2617 sec 1.2, "scheme" name is case-insensitive
                //if (authHeaderVal.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase) && authHeaderVal.Parameter != null)
                //{

                //}
            }
        }

        // If the request was unauthorized, add the WWW-Authenticate header
        // to the response.
        private static void OnApplicationEndRequest(object sender, EventArgs e)
        {
            var response = HttpContext.Current.Response;
            if (response.StatusCode == 401)
            {
                //response.Headers.Add("WWW-Authenticate", string.Format("Basic realm=\"{0}\"", Realm));
            }
        }

        public void Dispose()
        {
        }
    }
}