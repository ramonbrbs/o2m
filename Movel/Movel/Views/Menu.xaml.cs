using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private void Button_OnClicked(object sender, EventArgs e)
        {
            try
            {
                Util.Navigation.AddToNavigation(Navigation, new NovoLead());
            }
            catch (Exception exception)
            {
                Util.Error.FilterException(this,exception);
            }
        }
    }
}
