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
    public class TakimDetayVM : INotifyPropertyChanged
    {
        private string TAKIM_DETAY_URL = "http://fanalizapi-001-site1.atempurl.com/api/Takim/Detay?takim_id=";
        private TakimDetay _takimDetay { get; set; }

        private ObservableCollection<MenuItems> golMenuItems;
        private ObservableCollection<MenuItems> mainMenuItems;
        private ObservableCollection<MenuItems> auMenuItems;
        private Boolean layoutSon5MacVisibility;
        private Boolean layoutAUVisibility;
        private Boolean layoutGolllerVisibility;
        private Boolean gollerMenuVisibility;
        private Boolean aUMenuVisibility;


        // Menu Items
        public ObservableCollection<MenuItems> GolMenuItems
        {
            get
            {
                return golMenuItems;
            }
            set
            {
                golMenuItems = value;
            }
        }
        public ObservableCollection<MenuItems> MainMenuItems
        {
            get
            {
                return mainMenuItems;
            }
            set
            {
                mainMenuItems = value;
            }
        }
        public ObservableCollection<MenuItems> AUMenuItems
        {
            get
            {
                return auMenuItems;
            }
            set
            {
                auMenuItems = value;
            }
        }

        //Layout visibility 

        public Boolean LayoutSon5MacVisibility
        {
            get
            {
                return layoutSon5MacVisibility;
            }
            set
            {
                layoutSon5MacVisibility = value;
            }
        }
        public Boolean LayoutAUVisibility
        {
            get
            {
                return layoutAUVisibility;
            }
            set
            {
                layoutAUVisibility = value;
            }
        }
        public Boolean LayoutGollerVisibility
        {
            get
            {
                return layoutGolllerVisibility;
            }
            set
            {
                layoutGolllerVisibility = value;
            }
        }

        //Menu visibility

        public Boolean GollerMenuVisibility
        {
            get
            {
                return gollerMenuVisibility;
            }
            set
            {
                gollerMenuVisibility = value;
            }
        }
        public Boolean AUMenuVisibility
        {
            get
            {
                return aUMenuVisibility;
            }
            set
            {
                aUMenuVisibility = value;
            }
        }

        // Main Menu Buton Komutları

        public ICommand ClickSon5MacButton { get; }   // VisibilityForSon5Mac 

        public Command<string> ClickAUMenuButton { get; }   // VisibilityForAU

        public ICommand ClickGollerMenuButton { get; }  // VisibilityForGoller

        // Inner Menu Button Komutları

        public Command<string> ClickAUMenuItems { get; }  // VisibilityForAuContent

        public Command<string> ClickGollerMenuItems { get; } // VisibilityForGollerContent
 



        // en son burada kaldi yukaridakileri yazdik
        // Fonksiyonlar

        public void VisibilityForSon5Mac()
        {
            GollerMenuVisibility = false;
            AUMenuVisibility = false;
            LayoutAUVisibility = false;
            LayoutGollerVisibility = false;
            LayoutSon5MacVisibility = true;
        }
        public void VisibilityForAU()
        {
            GollerMenuVisibility = false;
            AUMenuVisibility = true;
            LayoutAUVisibility = false;
            LayoutGollerVisibility = false;
            LayoutSon5MacVisibility = false;
        }
        public void VisibilityForGoller()
        {
            GollerMenuVisibility = true;
            AUMenuVisibility = false;
            LayoutAUVisibility = false;
            LayoutGollerVisibility = false;
            LayoutSon5MacVisibility = false;
        }

        public void VisibilityForAuContent(String viewText)
        {
            LayoutAUVisibility = true;
            LayoutGollerVisibility = false;
            LayoutSon5MacVisibility = false;

            foreach(var item in AUMenuItems)
            {
                if (item.Ad.Equals(viewText))
                {
                    item.Visibility = true;
                    continue;
                }
                item.Visibility = false;
            }
        }

        public void VisibilityForGollerContent(String viewText)
        {
            LayoutGollerVisibility = true;
            LayoutAUVisibility = false;
            LayoutSon5MacVisibility = false;
            
            foreach(var item in GolMenuItems)
            {
                if (item.Ad.Equals(viewText))
                {
                    item.Visibility = true;
                    continue;
                }
                item.Visibility = false;
            }

        }

        public void testFunc(String gelen)
        {
            string asdas = gelen;
            asdas += asdas;
        }

        //Constructor

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
            ClickAUMenuButton = new Command<string>(testFunc);

            // mTakimDetay = TakimDetayAl();
            golMenuItems = new ObservableCollection<MenuItems>()
            {
                new MenuItems
                {
                    Ad="1.5 AU",
                    Visibility=false
                },
                new MenuItems
                {
                    Ad="2.5 AU",
                    Visibility=false
                },
                new MenuItems
                {
                    Ad="3.5 AU",
                    Visibility=false
                }

            };

            mainMenuItems = new ObservableCollection<MenuItems>()
            {
                new MenuItems
                {
                    Ad = "Son 5 Maç",
                    Visibility=true
                },
                new MenuItems
                {
                    Ad = "Alt/Ust",
                    Visibility=true
                },
                new MenuItems
                {
                    Ad = "Goller",
                    Visibility=true
                }
            };

            auMenuItems = new ObservableCollection<MenuItems>()
            {
                new MenuItems
                {
                    Ad="1.5 A/U",
                    Visibility=false
                },
                new MenuItems
                {
                    Ad="2.5 A/U",
                    Visibility=false
                },
                new MenuItems
                {
                    Ad="3.5 A/U",
                    Visibility=false
                }
            };

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


        public event PropertyChangedEventHandler PropertyChanged;


        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    }
}
