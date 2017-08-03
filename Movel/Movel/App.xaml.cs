using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Movel.DAO;
using Movel.Util;
using Movel.Views;
using Xamarin.Forms;

namespace Movel
{
    public partial class App : Application
    {
        public App()
        {
            try
            {

                if (ConfigDAO.Get() != null)
                {
                    MainPage = new PagMenu();
                }
                else
                {
                    Session.Navigation = new NavigationPage(new Views.Login()
                    {
                        Title = "Indique Aí",
                        BackgroundColor = Color.White,


                    });
                    MainPage = Session.Navigation;
                }
                


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
