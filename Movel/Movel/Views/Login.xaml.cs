using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movel.DAO;
using Movel.Model;
using Movel.WS;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Movel.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void BtnCadastrar_OnClicked(object sender, EventArgs e)
        {
            Util.Navigation.AddToNavigation(Navigation, new Cadastro());
            Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
            {
                
            });
                

        }

        private async void BtnEntrar_OnClicked(object sender, EventArgs e)
        {
            var login = new LoginVM()
            {
                Email = TxtEmail.Text,
                Senha = TxtSenha.Text
            };
            Scroll.IsEnabled = false;
            Act.IsVisible = true;
            
                try
                {
                    var result = await ParceiroWS.Login(login);
                    if (result.Success)
                    {
                        //TODO: Adicionar login
                        Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                        {
                            ConfigDAO.InsertConfig(new Config() {CodParceiro = result.Content.CodParceiro});
                            ParceiroDAO.InsertConfig(result.Content);
                            Application.Current.MainPage = new PagMenu();
                            //Util.Navigation.AddToNavigation(Navigation, new Menu());
                            //Navigation.RemovePage(this);

                        });

                    }
                    else
                    {
                        
                            DisplayAlert("Erro", "E-mail ou senha inválido", "OK");
                    }
                }
                catch (Exception exception)
                {
                    Util.Error.FilterException(this, exception);
                }
                finally
                {
                    Scroll.IsEnabled = true;
                    Act.IsVisible = false;
                }
                
            
        }
    }
}
