using System;
using System.Collections.Generic;
using System.Text;

namespace FutbolAnalizXamarin.Models
{
    class Lig
    {
        public int lig_id { get; set; }
        public String lig_ad { get; set; }

        public byte[] lig_logo { get; set; }

        public String lig_ulke { get; set; }
    }
}
