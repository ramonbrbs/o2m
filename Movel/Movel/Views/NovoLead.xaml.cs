using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movel.DAO;
using Movel.Model;
using Movel.Util;
using Movel.WS;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Movel.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NovoLead : ContentPage
    {
        public NovoLead()
        {
            InitializeComponent();
            PckOperadoras.Items.Add("CLARO");
            PckOperadoras.Items.Add("OI");
            PckOperadoras.Items.Add("TIM");
            PckOperadoras.Items.Add("VIVO");
        }

        private async void BtnCadastrar_OnClicked(object sender, EventArgs e)
        {
            try
            {
                var lead = new Indicado()
                {
                    Contato = TxtContato.Text,
                    Email = TxtEmail.Text,
                    Nome = TxtNome.Text,
                    QtdBandaLarga = Convert.ToInt32(QtdBandaLarga.Value),
                    QtdCentraltelefonica = Convert.ToInt32(QtdCentralTelefonica.Value),
                    QtdLinhasFixas = Convert.ToInt32(QtdLinhasFixas.Value),
                    QtdLinhasMoveis = Convert.ToInt32(QtdLinhasMoveis.Value),
                    QtdLinkDedicado = Convert.ToInt32(QtdLinkDedicado.Value),
                    Telefone1 = TxtTelefone1.Text,
                    Telefone2 = TxtTelefone2.Text
                };
                if (PckOperadoras.SelectedIndex >= 0)
                {
                    lead.Operadora = PckOperadoras.Items[PckOperadoras.SelectedIndex];
                }

                var p = ParceiroDAO.Get();
                BtnCadastrar.Text = "Aguarde...";
                Stck.IsEnabled = false;
                Stck.Opacity = 0.7;
                Task.Run(async () =>
                {
                    var req = await LeadWS.Cadastro(lead, p);
                    if (req.Success)
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            DisplayAlert("Sucesso", "Obrigado por indicar um cliente. Entraremos em contato em breve", "OK");
                            Session.Navigation.Navigation.PopToRootAsync();
                        });
                        
                    }
                    else
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            BtnCadastrar.Text = "Cadastrar";
                            Stck.IsEnabled = true;
                            Stck.Opacity = 1;
                            DisplayAlert("Erro", String.Join("\n", req.Errors), "OK");
                        });


                    }
                });
                
            }
            catch (Exception exception)
            {
                Util.Error.FilterException(this, exception);
            }
            
        }
    }
}
