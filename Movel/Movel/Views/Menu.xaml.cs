using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movel.DAO;
using Movel.Util;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Movel.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : ContentPage
    {
        
        public Menu()
        {
            InitializeComponent();
            NavigationPage.SetTitleIcon(this, "form.png");
            NavigationPage.SetHasNavigationBar(this,false);

            GridIndicacoes.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    Util.Animacao.FadeOutIn(GridIndicacoes);
                    ListaClicked();
                })
            });

            


        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            var wd = (width / 2) - 25;
            GridMain.ColumnDefinitions[0].Width = wd ;
            GridMain.ColumnDefinitions[1].Width = wd;

            GridMain.RowDefinitions[0].Height = wd;
            GridMain.RowDefinitions[1].Height = wd;
        }


        private void Button_OnClicked(object sender, EventArgs e)
        {
            try
            {
                
                Util.Navigation.AddToNavigation(Session.Navigation.Navigation, new NovoLead());
            }
            catch (Exception exception)
            {
                Util.Error.FilterException(this,exception);
            }
        }

        private void ListaClicked()
        {
            Util.Navigation.AddToNavigation(Session.Navigation.Navigation, new Lista());
        }

        private void BtnComo_OnClicked(object sender, EventArgs e)
        {
            try
            {
                Util.Navigation.AddToNavigation(Session.Navigation.Navigation, new ComoFunciona());
            }
            catch (Exception exception)
            {
                Util.Error.FilterException(this, exception);
            }
        }

        private void BtnSair_OnClicked(object sender, EventArgs e)
        {
            ConfigDAO.DeleteConfig();
            Application.Current.MainPage = new Login();
        }

        private void BtnMenu_OnClicked(object sender, EventArgs e)
        {
            Session.Master.IsPresented = true;
        }
    }
}
