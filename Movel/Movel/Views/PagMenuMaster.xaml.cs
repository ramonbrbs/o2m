using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Movel.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagMenuMaster : ContentPage
    {
        public ListView ListView => ListViewMenuItems;

        public PagMenuMaster()
        {
            InitializeComponent();
            BindingContext = new PagMenuMasterViewModel();
        }



        class PagMenuMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<PagMenuMenuItem> MenuItems { get; }
            public PagMenuMasterViewModel()
            {
                MenuItems = new ObservableCollection<PagMenuMenuItem>(new[]
                {
                    new PagMenuMenuItem { Id = 0, Title = "Minhas Indicações", TargetType = typeof(Lista)},
                    new PagMenuMenuItem { Id = 1, Title = "Indicar Empresa", TargetType = typeof(NovoLead) },
                    new PagMenuMenuItem { Id = 2, Title = "Como Funciona", TargetType = typeof(ComoFunciona) },
                    new PagMenuMenuItem { Id = 3, Title = "Sair" },
                });
            }
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        }
    }
}
