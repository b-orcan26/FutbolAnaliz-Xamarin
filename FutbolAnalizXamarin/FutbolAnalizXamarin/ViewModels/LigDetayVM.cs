using FutbolAnalizXamarin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Specialized;
using FutbolAnalizXamarin.Pages;

namespace FutbolAnalizXamarin.ViewModels
{
    class LigDetayVM : INotifyPropertyChanged 
    {
        private const String LIGLER_URL = "http://fanalizapi-001-site1.atempurl.com/api/Lig/LigListesi";
        private const String PUAN_DURUMU_URL = "http://fanalizapi-001-site1.atempurl.com/api/Lig/PuanDurumu?lig_id=";
        private const String LIG_ISTATISTIK_URL = "http://fanalizapi-001-site1.atempurl.com/api/Lig/LigDetay?lig_id=";
        private const String PUAN_DURUMU = "";
        private HttpClient client;
        private ObservableCollection<Lig> _ligler;
        private Lig _mySelectedLigItem;
        private ObservableCollection<PuanDurumuSatir> _puanDurumu;
        private static LigDetayVM _myLigDetayVM = new LigDetayVM();
        private Istatistik _istatistik;

        public Istatistik Istatistik
        {
            get
            {
                return _istatistik;
            }
            set
            {
                _istatistik = value;
            }
        }

        public static LigDetayVM myLigDetayVM
        {
            get
            {
                return _myLigDetayVM;
            }
        }


        public ObservableCollection<PuanDurumuSatir> PuanDurumu
        {
            get
            {
                
                
                return _puanDurumu;
            }
            set
            {
                _puanDurumu = value;
            }
        }

        public Lig MySelectedLigItem
        {
            get {
                return _mySelectedLigItem;
            }
            set
            {
                _mySelectedLigItem = value;
                PuanDurumuAl(PUAN_DURUMU_URL, MySelectedLigItem.lig_id);
                IstatistikAl(LIG_ISTATISTIK_URL, MySelectedLigItem.lig_id);
                NotifyPropertyChanged("MySelectedLigItem");
                
            }
        }
       
        public ObservableCollection<Lig> Ligler
        {
            get
            {
                return _ligler;
            }
            set
            {
                _ligler = value;
                NotifyPropertyChanged();
            }
        }

     

        private LigDetayVM()
        {
            client = new HttpClient();
            _puanDurumu = new ObservableCollection<PuanDurumuSatir>();           
            _mySelectedLigItem = new Lig();
            Ligler = LigleriAl(LIGLER_URL);
            
        }




        //Wep api requests
        //Senkron 
        public ObservableCollection<Lig> LigleriAl(string url)
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(url).Result;

                if (response != null)
                {
                    var responseContent = response.Content;
                    string responseString = responseContent.ReadAsStringAsync().Result;
                    var posts = JsonConvert.DeserializeObject<ObservableCollection<Lig>>(responseString);
                    return posts;
                }
                return null;
            }
        }

        //Asenkron
        private async void PuanDurumuAl(string url,int lig_id)
        {
            var response = await client.GetAsync(url+lig_id);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var posts = JsonConvert.DeserializeObject<ObservableCollection<PuanDurumuSatir>>(content);
                //PuanDurumu = new ObservableCollection<PuanDurumuSatir>(posts);
                PuanDurumu= new ObservableCollection<PuanDurumuSatir>(posts);
                NotifyPropertyChanged("PuanDurumu");
            }
            
        }

        private async void IstatistikAl(string url, int lig_id)
        {
            var response = await client.GetAsync(url+lig_id);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var posts = JsonConvert.DeserializeObject<Istatistik>(content);
                //PuanDurumu = new ObservableCollection<PuanDurumuSatir>(posts);
                Istatistik = posts;
                
            }

        }




        public event PropertyChangedEventHandler PropertyChanged;
       

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

       


    }
}
