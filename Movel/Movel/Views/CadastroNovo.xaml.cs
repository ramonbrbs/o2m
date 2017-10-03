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
	public partial class CadastroNovo : CarouselPage
    {
		public CadastroNovo ()
		{
			InitializeComponent ();
            try
            {
                Scroll.IsEnabled = false;
                Act.IsRunning = true;
                Act.IsVisible = true;
                Stack.Opacity = .7;
                foreach (var s in Stack.Children)
                {
                    s.IsEnabled = false;
                }
                Task.Run(() =>
                {
                    try
                    {

                        CarregarBancos();
                    }
                    catch (Exception exx)
                    {
                        DisplayAlert("Erro", exx.Message, "ok");
                    }


                });
            }
            catch (Exception e)
            {

                Util.Error.FilterException(this, e);
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
                    Stack.Opacity = 1;
                    foreach (var s in Stack.Children)
                    {
                        s.IsEnabled = true;
                    }
                });

            }
        }

        protected override void OnCurrentPageChanged()
        {

            this.Title =  this.CurrentPage.Title;
            base.OnCurrentPageChanged();
        }
        private async Task AnimateItem(Page uiElement, uint duration)
        {
            await Task.WhenAll(new Task[] {
                uiElement.ScaleTo(1.5, duration, Easing.CubicIn),
                uiElement.FadeTo(1, duration/2, Easing.CubicInOut).ContinueWith(
                    _ =>
                    {
                        // Queing on UI to workaround an issue with Forms 2.1
                        Device.BeginInvokeOnMainThread(() => {
                            uiElement.ScaleTo(1, duration, Easing.CubicOut);
                        });
                    })
            });
        }

        private async void Proximo_Clicked(object sender, EventArgs e)
        {
            this.CurrentPage = PageBancarios;
            await AnimateItem(PageBancarios, 500);
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            try
            {
                if (TxtPassword1.Text != TxtPassword2.Text)
                {
                    this.CurrentPage = PagePessoais;
                    DisplayAlert("", "Senha não confere", "OK");
                    return;
                }
                if (PckBanco.SelectedIndex == -1)
                {
                    this.CurrentPage = PagePessoais;
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

                foreach (var s in Stack2.Children)
                {
                    s.IsEnabled = false;
                }
                Act2.IsVisible = true;
                try
                {
                    var retorno = await ParceiroWS.Cadastro(p);
                    if (retorno.Success)
                    {

                        DisplayAlert("", "Cadastro realizado", "OK");


                        Navigation.PopToRootAsync();
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
                        foreach (var s in Stack2.Children)
                        {
                            s.IsEnabled = true;
                        }
                        Act2.IsVisible = false;
                    });

                }


            }
            catch (Exception exception)
            {
                Util.Error.FilterException(this, exception);
                this.CurrentPage = PagePessoais;
            }   
        }
    }
}