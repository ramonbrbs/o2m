using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movel.DAO;
using Movel.Model.Constantes;
using Movel.Util;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ItemTappedEventArgs = Syncfusion.ListView.XForms.ItemTappedEventArgs;

namespace Movel.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : ContentPage
    {
        public class VMMenu
        {
            public ImageSource Image { get; set; }
            public String Title { get; set; }
            public Type Type { get; set; }
        }

        public Menu()
        {
            InitializeComponent();
            try
            {
                NavigationPage.SetHasNavigationBar(this, false);
                List<VMMenu> listaMenu = new List<VMMenu>();


                listaMenu.Add(new VMMenu() { Image = "form.jpg", Title = "Minhas Indicações", Type = typeof(Lista) });
                listaMenu.Add(new VMMenu() { Image = "adduser.jpg", Title = "Indicar Empresa", Type = typeof(NovoLead) });
                listaMenu.Add(new VMMenu() { Image = "questionbig.jpg", Title = "Como funciona", Type = typeof(ComoFunciona) });
                listView.ItemsSource = listaMenu;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            

            //GridIndicacoes.GestureRecognizers.Add(new TapGestureRecognizer()
            //{
            //    Command = new Command(() =>
            //    {
            //        Util.Animacao.FadeOutIn(GridIndicacoes);
            //        ListaClicked();
            //    })
            //});
            //GridIndicar.GestureRecognizers.Add(new TapGestureRecognizer()
            //{
            //    Command = new Command(() =>
            //    {
            //        Util.Animacao.FadeOutIn(GridIndicacoes);
            //        Indicar_OnClicked();
            //    })
            //});

            //GridComo.GestureRecognizers.Add(new TapGestureRecognizer()
            //{
            //    Command = new Command(() =>
            //    {
            //        Util.Animacao.FadeOutIn(GridIndicacoes);
            //        BtnComo_OnClicked();
            //    })
            //});



        }

        //protected override void OnSizeAllocated(double width, double height)
        //{
        //    base.OnSizeAllocated(width, height);
        //    var wd = (width / 2) - 25;
        //    GridMain.ColumnDefinitions[0].Width = wd ;
        //    GridMain.ColumnDefinitions[1].Width = wd;

        //    GridMain.RowDefinitions[0].Height = wd >= 120 ? wd : 120 ;
        //    GridMain.RowDefinitions[1].Height = wd >= 135 ? wd : 135; ; //wd >= 120 ? wd : 120;
        //}


        private void Indicar_OnClicked()
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

        private void BtnComo_OnClicked()
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

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = (VMMenu)e.ItemData;
            var instance = Activator.CreateInstance(item.Type);

            if (item.Title == "Minhas Indicações")
            {
                Util.Navigation.AddToNavigation(Session.Navigation.Navigation, new Lista());
            }else if (item.Title == "Indicar Empresa")
            {
                Util.Navigation.AddToNavigation(Session.Navigation.Navigation, new NovoLead());
            }
            else
            {
                Util.Navigation.AddToNavigation(Session.Navigation.Navigation, new ComoFunciona());
            }
            
            listView.SelectedItem = null;

        }
    }
    }

