using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using O2MLeads.Model;
using O2MLeads.Model.Constantes;
using O2MLeads.Util;
using O2MLeads.WS;
using OpenXamarin.WebRequest;
using Xamarin.Forms;

namespace O2MLeads.Views
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private  void BtnCadastrar_OnClicked(object sender, EventArgs e)
        {

            Util.Navigation.AddToNavigation(Navigation, new Cadastro());

        }

        private void BtnEntrar_OnClicked(object sender, EventArgs e)
        {
            var login = new LoginVM()
            {
                Email = TxtEmail.Text,
                Senha = TxtSenha.Text
            };
            Task.Run(async () =>
            {
                var result = await ParceiroWS.Login(login);
                if (result.Success)
                {
                    //TODO: Adicionar login
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        
                        Util.Navigation.AddToNavigation(Navigation, new Menu());
                        Navigation.RemovePage(this);
                        
                    });

                }
                else
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(async () =>
                    {
                        await DisplayAlert("Erro", "E-mail ou senha inválido", "OK");
                    });
                }
            });
        }
    }
}
