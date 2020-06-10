using FutbolAnalizXamarin.Models;
using FutbolAnalizXamarin.Pages;
using FutbolAnalizXamarin.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.Toast;
using System.Threading;

namespace FutbolAnalizXamarin
{
    

    public partial class MainPage : ContentPage
    {
        
        private string content;

        public MainPage()
        {
            
            InitializeComponent();            
            LigDetayVM vm = LigDetayVM.myLigDetayVM;
            BindingContext = vm;
            
        }

        private void Click_Lig_istatistik(object sender, EventArgs e)
        {
            //int count = PuanDurumuView.View.Records.Count();
            Navigation.PushAsync(new LigIstatistikPage());

        }



        private async void Click_Takim_istatistik(object sender, EventArgs e)
        {
            
            PuanDurumuView.IsEnabled = false;
            PuanDurumuSatir pd = (PuanDurumuSatir)PuanDurumuView.SelectedItem;
            int tk_id = pd.takim_id;
            TakimDetayVM myVM = new TakimDetayVM();
            await myVM.TakimDetayAlAsync(tk_id);
            
            TakimIstatistikPage page = new TakimIstatistikPage();
            page.BindingContext = myVM;
            Navigation.PushAsync(page);
            PuanDurumuView.IsEnabled = true;
           

        }

       
      

    }
}
