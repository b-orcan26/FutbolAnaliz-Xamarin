using System;
using System.Collections.Generic;
using System.Text;

namespace FutbolAnalizXamarin.Models
{
    class Istatistik
    {

        public Takim EnCokGolAtanTakim { get; set; }


        public Takim EnAzGolYiyenTakim { get; set; }


        public Takim IcSahaBasariliTakim { get; set; }


        public Takim DisSahaBasariliTakim { get; set; }

        public int ToplamGol { get; set; }

        public double OrtalamaGol { get; set; }

    }
}
