﻿using Movel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movel.DAO;
using Movel.WS;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Movel.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Lista : TabbedPage
    {

        public class Item
        {
            public Indicado i { get; set; }
            public Command Command { get; set; }
        }
        public Lista()
        {

            
            InitializeComponent();
            try
            {
                this.Title = "Leads";
                Task.Run(() =>
                {
                    CarregarTodos();
                });
            }
            catch (Exception e)
            {
                Util.Error.FilterException(this,e);
            }
            
        }

        private async void CarregarTodos()
        {
            
            
            try
            {

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    ActTodos.IsVisible = true;
                    LstTodos.IsEnabled = false;
                });

                List<Item> itens = new List<Item>();
                var parceiro = ParceiroDAO.Get();
                var leads = await LeadWS.Listar(parceiro);
                if (leads.Success)
                {
                    foreach (var l in leads.Content)
                    {
                        itens.Add(new Item()
                        {
                            i = l,
                            Command = new Command((object cod) => Selecionar(l.CodIndicado))
                        });
                    }
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        LstTodos.ItemsSource = itens;
                    });
                    
                }
                else
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        DisplayAlert("Erro", String.Join("\n", leads.Errors), "OK");
                    });
                    
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    ActTodos.IsVisible = false;
                    LstTodos.IsEnabled = true;
                });
                
            }
            
        }

        private void Selecionar(int cod)
        {
            Util.Navigation.AddToNavigation(Navigation, new Visualizar(cod));
        }
    }
}
