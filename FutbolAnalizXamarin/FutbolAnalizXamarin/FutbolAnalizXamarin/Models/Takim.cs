using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace FutbolAnalizXamarin.Models
{
    public class Takim : INotifyPropertyChanged
    {

        private int tk_id;
        private string tk_ad;
        private byte[] tk_logo;

        public int takim_id {
            get
            {
                return tk_id;
            }
            set
            {
                tk_id = value;
                NotifyPropertyChanged();
            }
        }

        public string takim_ad {
            get
            {
                return tk_ad;
            }
            set
            {
                tk_ad = value;
                NotifyPropertyChanged();
            }
            }


        public byte[] takim_logo {
            get
            {
                return tk_logo;
            }
            set
            {
                tk_logo = value;
                NotifyPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;


        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
