using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using O2MLeads.Model;
using O2MLeads.WS;
using Xamarin.Forms;

namespace O2MLeads.Views
{
    public partial class Cadastro : ContentPage
    {
        public String teste;
        public Cadastro()
        {
            InitializeComponent();
           
            //TODO: Colocar listagem de banco
        }

        private void BtnCadastrar_OnClicked(object sender, EventArgs e)
        {
            try
            {
                var p = new Parceiro()
                {
                    Agencia = TxtAgencia.Text,
                    Conta = TxtConta.Text,
                    Documento = TxtCpf.Text,
                    Email = TxtEmail.Text,
                    Nome = TxtName.Text,
                    Senha = TxtPassword1.Text,
                    CodBanco = 1
                };
                Scroll.IsEnabled = false;
                Act.IsRunning = true;
                Act.IsVisible = true;
                Task.Run(async () =>
                {


                    try
                    {
                        var retorno = await ParceiroWS.Cadastro(p);
                        if (retorno.Success)
                        {
                            Xamarin.Forms.Device.BeginInvokeOnMainThread(async () =>
                            {
                                await DisplayAlert("", "Cadastro realizado", "OK");
                            });

                            Util.Navigation.AddToNavigation(Navigation, new Login());
                        }
                        else
                        {
                            Xamarin.Forms.Device.BeginInvokeOnMainThread(async () =>
                            {
                                await DisplayAlert("Erro", String.Join("\n", retorno.Errors), "Ok");
                                Util.Navigation.AddToNavigation(Navigation, new Login());
                            });

                        }
                    }
                    catch (Exception exception)
                    {
                        Util.Error.FilterException(this, exception);
                    }
                    finally
                    {
                        Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                        {
                            Scroll.IsEnabled = true;
                            Act.IsVisible = false;
                        });
                        
                    }


                });
            }
            catch (Exception exception)
            {
                Util.Error.FilterException(this,exception);
            }
            
        }
    }
}
