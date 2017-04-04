using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenXamarin.WebRequest;
using Xamarin.Forms;

namespace O2MLeads.Util
{
    public class Error
    {
        public static void FilterException(Page p, Exception ex)
        {
            if (ex.GetType() == typeof(WebRequestException))
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    p.DisplayAlert($"Erro",
                    $"Erro ao contectar com o servidor remoto. \n {((WebRequestException)ex).Message}", "Ok");
                });
                
            }
            
        }
    }
}
