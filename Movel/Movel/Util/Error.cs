using System;
using OpenXamarin.WebRequest;
using Xamarin.Forms;

namespace Movel.Util
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
                        $"Erro ao contectar com o servidor remoto. \n {((WebRequestException) ex).Message}", "Ok");
                });

            }
            else
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    p.DisplayAlert($"Erro",
                        $"Erro inesperado durante execução \n  Caso persista, entre em contato com o suporte.", "Ok");
                });
            }
            
        }
    }
}
