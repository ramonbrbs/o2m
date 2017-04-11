using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movel.DAO;
using Movel.Model;
using Movel.WS;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Movel.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Visualizar : ContentPage
    {
        public Visualizar(int cod)
        {
            InitializeComponent();
            try
            {
                Task.Run(async () =>
                {
                    CarregarLead(cod);
                });
            }
            catch (Exception e)
            {
                Util.Error.FilterException(this,e);
            }
            
        }

        public async void CarregarLead(int cod)
        {
            try
            {
                var parceiro = ParceiroDAO.Get();
                Device.BeginInvokeOnMainThread(() =>
                {
                    Act.IsVisible = true;
                    Scroll.IsEnabled = false;
                });
                var result = await LeadWS.Visualizar(cod, parceiro);

                if (!result.Success)
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(async () =>
                    {
                        await DisplayAlert("Erro", "Erro ao retornar informaçoes do indicado", "OK");
                    });
                    return;
                }

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    var lead = result.Content;
                    this.Title = lead.Nome;
                    if (lead.Status != Indicado.StatusLead.Pendente)
                    {
                        //COLOCAR VALOR DO LEAD
                    }
                    TxtEmail.Text = lead.Email;
                    TxtContato.Text = lead.Contato;
                    TxtStatus.Text = lead.Status.ToString();
                    TxtTelefone1.Text = lead.Telefone1;
                    TxtTelefone2.Text = lead.Telefone2;
                    TxtOperadora.Text = lead.Operadora;
                    if (lead.Status != Indicado.StatusLead.Pendente)
                    {
                        StckComissao.IsVisible = true;
                    }

                    if (lead.QtdBandaLarga != null && lead.QtdBandaLarga > 0)
                    {
                        StckBandaLarga.IsVisible = true;
                        TxtBandaLarga.Text = lead.QtdBandaLarga.ToString();
                    }

                    if (lead.QtdCentraltelefonica != null && lead.QtdCentraltelefonica > 0)
                    {
                        StckCentral.IsVisible = true;
                        TxtCentral.Text = lead.QtdCentraltelefonica.ToString();
                    }

                    if (lead.QtdLinkDedicado != null && lead.QtdLinkDedicado > 0)
                    {
                        StckDedicado.IsVisible = true;
                        TxtDedicado.Text = lead.QtdLinkDedicado.ToString();
                    }

                    if (lead.QtdLinhasFixas != null && lead.QtdLinhasFixas > 0)
                    {
                        StckLinhasFixas.IsVisible = true;
                        TxtLinhasFixas.Text = lead.QtdLinhasFixas.ToString();
                    }
                    if (lead.QtdLinhasMoveis != null && lead.QtdLinhasMoveis > 0)
                    {
                        StckLinhasMoveis.IsVisible = true;
                        TxtLinhasMoveis.Text = lead.QtdLinhasMoveis.ToString();
                    }
                        
                    Act.IsVisible = false;
                    Scroll.IsEnabled = true;
                });
            }
            catch (Exception e)
            {
                
                throw;
            }
            
            
        }
    }
}
