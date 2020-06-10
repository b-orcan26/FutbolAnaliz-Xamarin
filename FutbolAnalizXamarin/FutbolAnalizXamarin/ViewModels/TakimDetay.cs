using FutbolAnalizXamarin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;

namespace FutbolAnalizXamarin.ViewModels
{
    public class TakimDetay
    {


        private ObservableCollection<DataPoint> _ucBucuk;
        private ObservableCollection<DataPoint> _ikiBucuk;
        private ObservableCollection<DataPoint> _birBucuk;

        private ObservableCollection<Son5MacSatir> _son5MacListesi;
        private IcDisPerformansSatir _icSahaPerformansi;
        private IcDisPerformansSatir _disSahaPerformansi;

        private ObservableCollection<DataPoint> _attigiSeries;
        private ObservableCollection<DataPoint> _yedigiSeries;
        private ObservableCollection<DataPoint> _maclarindakiToplamGol;
        private ObservableCollection<DataPoint> _maclarindakiAttigiIyGol;
        private ObservableCollection<DataPoint> _maclarindakiYedigiIyGol;

        private Takim _myTakim;

        public ObservableCollection<DataPoint> UcBucuk
        {
            get
            {
                return _ucBucuk;
            }
            set
            {
                _ucBucuk = value;

            }
        }
        public ObservableCollection<DataPoint> IkiBucuk
        {
            get
            {
                return _ikiBucuk;

            }
            set
            {
                _ikiBucuk = value;

            }
        }
        public ObservableCollection<DataPoint> BirBucuk
        {
            get
            {
                return _birBucuk;
            }
            set
            {
                _birBucuk = value;

            }
        }


        public ObservableCollection<Son5MacSatir> Son5MacListesi
        {
            get
            {
                return _son5MacListesi;
            }
            set
            {
                _son5MacListesi = value;

            }
        }
        public IcDisPerformansSatir IcSahaPerformansi
        {
            get
            {
                return _icSahaPerformansi;
            }
            set
            {
                _icSahaPerformansi = value;
            }
        }
        public IcDisPerformansSatir DisSahaPerformansi
        {
            get
            {
                return _disSahaPerformansi;
            }
            set
            {
                _disSahaPerformansi = value;
            }
        }


        public ObservableCollection<DataPoint> AttigiSeries
        {
            get
            {
                return _attigiSeries;
            }
            set
            {
                _attigiSeries = value;
            }
        }
        public ObservableCollection<DataPoint> YedigiSeries
        {
            get
            {
                return _yedigiSeries;
            }
            set
            {
                _yedigiSeries = value;
            }
        }
        public ObservableCollection<DataPoint> MaclarindakiToplamGol
        {
            get
            {
                return _maclarindakiToplamGol;
            }
            set
            {
                _maclarindakiToplamGol = value;
            }
        }
        public ObservableCollection<DataPoint> MaclarindakiAttigiIyGol
        {
            get
            {
                return _maclarindakiAttigiIyGol;
            }
            set
            {
                _maclarindakiAttigiIyGol = value;
            }
        }
        public ObservableCollection<DataPoint> MaclarindakiYedigiIyGol
        {
            get
            {
                return _maclarindakiYedigiIyGol;
            }
            set
            {
                _maclarindakiYedigiIyGol = value;
            }
        }
        public Takim MyTakim
        {
            get
            {
                return _myTakim;
            }
            set
            {
                _myTakim = value;

            }
        }




    }
}
