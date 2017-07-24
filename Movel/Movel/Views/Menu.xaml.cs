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
            
        }

        protected override void OnAppearing()
        {
            //Task.Run(() =>
            //{
            //    while (Application.Current.MainPage.Width < 0)
            //    {
                    
            //    }
            //    Device.BeginInvokeOnMainThread(() =>
            //    {
            //        var size = new Size()
            //        {
            //            Width = Application.Current.MainPage.Width * 0.15,
            //            Height = Application.Current.MainPage.Height * 0.3
            //    };
            //        Stck.Margin = new Thickness(size.Width, size.Height, size.Width, 0);                    
            //    });
            //});

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

        private void ListaClicked(object sender, EventArgs e)
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
    }
}
