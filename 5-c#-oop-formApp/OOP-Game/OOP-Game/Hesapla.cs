
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Game
{
    abstract class Hesapla
    {
        abstract public int KasaHesap(int adet,int fiyat);//ürünlerin hesaplanmasısını sağlayan fonksiyon
        //ürün fiyatları
        public int TYumurtaPara = 1;
        public int OYumurtaPara = 3;
        public int ISutuPara = 5;
        public int KSutuPara = 8;
        //başlangıç kasa değeri
        public int Kasa = 0;
        
    }
}
