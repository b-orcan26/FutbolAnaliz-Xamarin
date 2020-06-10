using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace FutbolAnalizXamarin.Models
{
    public class MenuItems : INotifyPropertyChanged
    {
        private String ad;
        private Boolean visibility;

        public String Ad
        {
            get
            {
                return ad;
            }
            set
            {
                ad = value;
                NotifyPropertyChanged();
            }
        }
        public Boolean Visibility
        {
            get
            {
                return visibility;
            }
            set
            {
                visibility = value;
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
