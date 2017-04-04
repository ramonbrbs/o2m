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
    public partial class NovoLead : ContentPage
    {
        public NovoLead()
        {
            InitializeComponent();
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
                    //Operadora = PckOperadoras.Items[PckOperadoras.SelectedIndex],
                    QtdBandaLarga = Convert.ToInt32(QtdBandaLarga.Text),
                    QtdCentraltelefonica = Convert.ToInt32(QtdCentralTelefonica.Text),
                    QtdLinhasFixas = Convert.ToInt32(QtdLinhasFixas.Text),
                    QtdLinhasMoveis = Convert.ToInt32(QtdLinhasMoveis.Text),
                    QtdLinkDedicado = Convert.ToInt32(QtdLinkDedicado.Text),
                    Telefone1 = TxtTelefone1.Text,
                    Telefone2 = TxtTelefone2.Text
                };
                var p = ParceiroDAO.Get();
                var req = await LeadWS.Cadastro(lead, p);
                if (req.Success)
                {
                    DisplayAlert("", "Obrigado por indicar um cliente. Entraremos em contato em breve", "OK");
                    Util.Navigation.AddToNavigation(Navigation, new Menu());
                }
                else
                {
                    DisplayAlert("Erro", String.Join("\n", req.Errors), "OK");
                }
            }
            catch (Exception exception)
            {
                Util.Error.FilterException(this, exception);
            }
            
        }
    }
}
