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
	public partial class NavbarMenu : ContentView
	{
		public NavbarMenu ()
		{
			InitializeComponent ();
		    
            BtnNav.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    Util.Animacao.FadeOutIn(BtnNav);
                    Session.Master.IsPresented = true;
                })
            });
        }
        
	}
}