using FutbolAnalizXamarin.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FutbolAnalizXamarin.Models
{
    public class TakimDetayVM
    {
        private string TAKIM_DETAY_URL = "http://fanalizapi-001-site1.atempurl.com/api/Takim/Detay?takim_id=";
        private TakimDetay _takimDetay { get; set; }

        public TakimDetay mTakimDetay
        {
            get
            {
                return _takimDetay;
            }
            set
            {
                _takimDetay = value;
            }
        }

        public TakimDetayVM()
        {
     
        }


        public async Task TakimDetayAlAsync(int takim_id)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(TAKIM_DETAY_URL + takim_id);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var posts = JsonConvert.DeserializeObject<TakimDetay>(content);
                //PuanDurumu = new ObservableCollection<PuanDurumuSatir>(posts);
                mTakimDetay = posts;
            }

        }




    }
}
