using System;
using System.Collections.Generic;
using System.Text;

namespace FutbolAnalizXamarin.Models
{
    class LigIstatistik
    {
        private const String LIG_ISTATISTIK_URL = "http://fanalizapi-001-site1.atempurl.com/api/Lig/LigDetay?lig_id=";

        public Takim EnCokGolAtanTakim { get; set; }


        public Takim EnAzGolYiyenTakim { get; set; }


        public Takim IcSahaBasariliTakim { get; set; }


        public Takim DisSahaBasariliTakim { get; set; }

        public int ToplamGol { get; set; }

        public double OrtalamaGol { get; set; }


        public LigIstatistik(int lig_id)
        {

        }

        //istek


    }
}
