
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Game
{
    class Keci:Hesapla
    {
        private int Ksutu = 0;//keçi sütü miktarı

        public int KSutu//keçi için property
        {
            get { return Ksutu; }

            set { Ksutu = value; }
        }
        public override int KasaHesap(int adet, int para)//abstract sınıftan kalıtım alınan metodun override edilmesi
        {
            Kasa = (adet * para);//satılan keçi sütünden gelen miktar
            return Kasa;
        }
    }
}
