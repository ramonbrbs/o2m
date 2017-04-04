using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Movel
{
    public partial class App : Application
    {
        public App()
        {
            try
            {

                MainPage = new NavigationPage(new Views.Login()
                {
                    Title = "Open Mobile Varejo",
                    BackgroundColor = Color.White,


                });
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
