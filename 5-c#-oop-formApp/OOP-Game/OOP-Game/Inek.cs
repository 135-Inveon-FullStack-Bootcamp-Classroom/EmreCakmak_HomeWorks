
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Game
{
    class Inek:Hesapla
    {
        private int Isutu = 0;//inek sütü miktarı

        public int ISutu//Inek için property
        {
            get { return Isutu; }

            set { Isutu = value; }
        }
        public override int KasaHesap(int adet, int para)//abstract sınıftan kalıtım alınan metodun override edilmesi
        {
            Kasa = (adet * para);//satılan inek sütünden gelen miktar
            return Kasa;
        }
    }
}
