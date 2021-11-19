
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Game
{
    class Ordek:Hesapla
    {
        private int Oyumurta = 0;//Tavuk yumurta sayısı

        public int O_Yumurta//Ordek için property
        {
            get { return Oyumurta; }

            set { Oyumurta = value; }
        }
        public override int KasaHesap(int adet, int para)//abstract sınıftan kalıtım alınan metodun override edilmesi
        {
            Kasa = (adet * para);//satılan ördek yumurtasının miktarı
            return Kasa;
        }
    }
}
