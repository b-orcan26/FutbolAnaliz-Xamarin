using FutbolAnalizXamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FutbolAnalizXamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LigIstatistikPage : ContentPage
    {
        public LigIstatistikPage(String lig_adi)
        {
            InitializeComponent();
            BindingContext = LigDetayVM.myLigDetayVM;
            this.Title = lig_adi;
        }
    }
}