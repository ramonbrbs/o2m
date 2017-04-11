using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movel.Model;
using Movel.WS;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Movel.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cadastro : ContentPage
    {
        public String teste;
        public Cadastro()
        {
            InitializeComponent();

            //TODO: Colocar listagem de banco
        }

        private async void BtnCadastrar_OnClicked(object sender, EventArgs e)
        {
            try
            {
                if (TxtPassword1.Text != TxtPassword2.Text)
                {
                    DisplayAlert("", "Senha não confere", "OK");
                    return;
                }
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
                


                    try
                    {
                        var retorno = await ParceiroWS.Cadastro(p);
                        if (retorno.Success)
                        {
                            
                            DisplayAlert("", "Cadastro realizado", "OK");
                            

                            Util.Navigation.AddToNavigation(Navigation, new Login());
                            Navigation.RemovePage(this);
                        }
                        else
                        {
                            
                                DisplayAlert("Erro", String.Join("\n", retorno.Errors), "Ok");
                            
                                
                            

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


            }
            catch (Exception exception)
            {
                Util.Error.FilterException(this, exception);
            }

        }
    }
}
