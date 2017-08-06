using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movel.Util;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Movel.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagMenu : MasterDetailPage
    {
        public PagMenu()
        {
            Session.Navigation = new NavigationPage(new Menu());
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
            
            Detail = Session.Navigation;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as PagMenuMenuItem;
            if (item.Id == 3)
            {
                Application.Current.MainPage = new Login();
                
                return;
                            }
            if (item == null)
                return;

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;
            Session.Navigation = new NavigationPage(page);
            Detail = Session.Navigation;
            //MasterPage.ListView.SelectedItem = null;
            IsPresented = false;

        }
    }

}
