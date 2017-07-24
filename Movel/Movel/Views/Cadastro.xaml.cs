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
            try
            {
                Scroll.IsEnabled = false;
                Act.IsRunning = true;
                Act.IsVisible = true;
                Task.Run(() =>
                {
                    try
                    {
                        CarregarBancos();
                    }
                    catch (Exception exx)
                    {
                        DisplayAlert("Erro", exx.Message,"ok");
                    }
                    
                    
                });
            }
            catch (Exception e)
            {
                
                Util.Error.FilterException(this,e);
            }
            
        }

        

        private List<Banco> bancos;
        private async void CarregarBancos()
        {
            try
            {
                var retorno = await ParceiroWS.Bancos();
                if (!retorno.Success)
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await DisplayAlert("Erro", "Erro de rede. Verifique sua conexão.", "Ok");
                    });
                    return;

                }
                bancos = retorno.Content;
                Device.BeginInvokeOnMainThread(() =>
                {
                    foreach (var b in bancos)
                    {
                        PckBanco.Items.Add(b.Nome);
                    }
                });

            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    Scroll.IsEnabled = true;
                    Act.IsRunning = false;
                    Act.IsVisible = false;
                });
                
            }
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
                if (PckBanco.SelectedIndex == -1)
                {
                    DisplayAlert("", "Selecione um banco.", "OK");
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
                    CodBanco = bancos.FirstOrDefault(b => b.Nome == PckBanco.Items[PckBanco.SelectedIndex]).CodBanco
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
