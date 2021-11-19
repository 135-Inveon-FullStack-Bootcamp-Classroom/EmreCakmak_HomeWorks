
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Game
{
    class Tavuk:Hesapla
    {
       private int Tyumurta = 0;//Tavuk yumurta sayısı
        
        public int TYumurta//Tavuk için property
        {   get { return Tyumurta; }

            set { Tyumurta = value; }
        }
        public override int KasaHesap(int adet,int para)//abstract sınıftan kalıtım alınan metodun override edilmesi
        {
             Kasa = (adet * para);//satılan tavuk yumurtasının miktarı
            return Kasa;
        }

    }
}
