using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int saniye = 0;
        //sınıflardan nesne oluşturdum.
        Tavuk tavuk = new Tavuk();
        Ordek ordek = new Ordek();
        Inek ınek = new Inek();
        Keci keci = new Keci();
        //hayvan sesleri için nesne oluşturdum.
        SoundPlayer player = new SoundPlayer();
        private void Form1_Load(object sender, EventArgs e)
        {
            //her hayvan için oluşturduğum timerların başlangıç değerlerini ayarladım.
            GecenSure.Interval = 1000;
            GecenSure.Enabled = true;
            TavukSure.Interval = 1000;
            TavukSure.Enabled = true;
            InekSure.Interval = 1000;
            InekSure.Enabled = true;
            OrdekSure.Interval = 1000;
            OrdekSure.Enabled = true;
            KeciSure.Interval = 1000;
            KeciSure.Enabled = true;
            Kasa.Text = "0 TL";
        }



        private void GecenSure_Tick(object sender, EventArgs e)//geçen süreyi tutan timer
        {
            Sure.Text = Convert.ToString(saniye) + "SN";
            saniye++;
        }

        private void TavukYemVer_Click(object sender, EventArgs e)//tavuk yem verme butonu
        {

            if (TavukCan.Value != 0)//eğer progressbar değeri 0 dan farklıysa bar'ı tekrar 100 yapıyorum
            {
                TavukCan.Value = 100;
            }
        }

        private void TavukSure_Tick(object sender, EventArgs e)//tavuk için süre tutan timer
        {

            if (TavukCan.Value != 0)//eğer progressbar değeri 0 dan farklıysa tavuğun can barını 2 azaltıyorum.
            {
                TavukCan.Value -= 2;
                if (saniye != 0)//genel saniyenin 0 dan farklı olmasında aşağıdaki if'e geçiyorum.
                {
                    if (saniye % 3 == 0)//saniye 3'ün katı olduğunda tavuk yumurtasını 1 arttırıyorum.tavuk labeline yazdırıyorum.
                    {
                        tavuk.TYumurta++;
                        TavukAdet.Text = Convert.ToString(tavuk.TYumurta) + " ADET";
                    }
                }

            }
            else//tavuk ölünce labele öldü yazdırıyorum.
            {
                player.SoundLocation = @"C:\Users\emre\Desktop\inveon-bootcamp\5-c#-oop-formApp\OOP-Game\OOP-Game\Resources\tavuk.wav";//ses dosyasının yolu
                player.Play();//sesi oynatıyorum.
                TavukDurum.Text = "ÖLDÜ";
                TavukSure.Enabled = false;
            }
        }

        private void InekYemVer_Click(object sender, EventArgs e)//inek yem verme butonu
        {
            if (InekCan.Value != 0)//eğer progressbar değeri 0 dan farklıysa bar'ı tekrar 100 yapıyorum
            {
                InekCan.Value = 100;
            }
        }

        private void InekSure_Tick(object sender, EventArgs e)//inek için süre tutan timer
        {
            if (InekCan.Value != 4)//eğer progressbar değeri 4 dan farklıysa ineğin can barını 8 azaltıyorum.
            {
                InekCan.Value -= 8;
                if (saniye != 0)//genel saniyenin 0 dan farklı olmasında aşağıdaki if'e geçiyorum.
                {
                    if (saniye % 8 == 0)//saniye 8'in katı olduğunda inek sütünü 1 arttırıyorum.inek labeline yazdırıyorum.
                    {
                        ınek.ISutu++;
                        InekKg.Text = Convert.ToString(ınek.ISutu) + " KG";
                    }
                }
            }
            else//inek ölünce labele öldü yazdırıyorum.
            {
                InekCan.Value = 0;
                player.SoundLocation = @"C:\Users\emre\Desktop\inveon-bootcamp\5-c#-oop-formApp\OOP-Game\OOP-Game\Resources\inek.wav";//ses dosyasının yolu
                player.Play();//sesi oynatıyorum.
                InekDurum.Text = "ÖLDÜ";
                InekSure.Enabled = false;
            }
        }

        private void OrdekYemVer_Click(object sender, EventArgs e)//ördek yem verme butonu
        {
            if (OrdekCan.Value != 0)//eğer progressbar değeri 0 dan farklıysa bar'ı tekrar 100 yapıyorum
            {
                OrdekCan.Value = 100;

            }
        }

        private void OrdekSure_Tick(object sender, EventArgs e)//ördek için süre tutan timer
        {
            if (OrdekCan.Value != 1)//eğer progressbar değeri 1 den farklıysa ördeğin can barını 3 azaltıyorum.
            {
                OrdekCan.Value -= 3;
                if (saniye != 0)//genel saniyenin 0 dan farklı olmasında aşağıdaki if'e geçiyorum.
                {
                    if (saniye % 5 == 0)//saniye 5'in katı olduğunda ördek yumurtasını 1 arttırıyorum.ördek labeline yazdırıyorum.
                    {
                        ordek.O_Yumurta++;
                        OrdekAdet.Text = Convert.ToString(ordek.O_Yumurta) + " ADET";
                    }
                }
            }
            else//ördek ölünce labele öldü yazdırıyorum.
            {
                OrdekCan.Value = 0;
                player.SoundLocation = @"C:\Users\emre\Desktop\inveon-bootcamp\5-c#-oop-formApp\OOP-Game\OOP-Game\Resources\ordek.wav";//ses dosyasının yolu
                player.Play();//sesi oynatıyorum.
                OrdekDurum.Text = "ÖLDÜ";
                OrdekSure.Enabled = false;
            }
        }

        private void KeciYemVer_Click(object sender, EventArgs e)//keçi yem verme butonu
        {
            if (KeciCan.Value != 0)//eğer progressbar değeri 0 dan farklıysa bar'ı tekrar 100 yapıyorum
            {
                KeciCan.Value = 100;
            }
        }

        private void KeciSure_Tick(object sender, EventArgs e)//keçi için süre tutan timer
        {
            if (KeciCan.Value != 4)//eğer progressbar değeri 4 den farklıysa keçinin can barını 6 azaltıyorum.
            {
                KeciCan.Value -= 6;
                if (saniye != 0)//genel saniyenin 0 dan farklı olmasında aşağıdaki if'e geçiyorum.
                {
                    if (saniye % 7 == 0)//saniye 7'nin katı olduğunda keçi sütünü 1 arttırıyorum.keçi labeline yazdırıyorum.
                    {
                        keci.KSutu++;
                        KeciKg.Text = Convert.ToString(keci.KSutu) + " KG";
                    }
                }
            }
            else//ördek ölünce labele öldü yazdırıyorum.
            {
                KeciCan.Value = 0;
                player.SoundLocation = @"C:\Users\emre\Desktop\inveon-bootcamp\5-c#-oop-formApp\OOP-Game\OOP-Game\Resources\keci.wav";//ses dosyasının yolu
                player.Play();//sesi oynatıyorum.
                KeciDurum.Text = "ÖLDÜ";
                KeciSure.Enabled = false;
            }
        }

        private void TavukYSat_Click(object sender, EventArgs e)//tavuk yumurtası satma butonu
        {
            int kont = tavuk.KasaHesap(tavuk.TYumurta, tavuk.TYumurtaPara);//fonksiyondan gelen tavuk ücretini değişkende tutuyorum.
            string kontrol = Kasa.Text.Substring(0, Kasa.Text.IndexOf(' '));//kasa labelinde yazan ifadeyi boşluğa kadar yani ilk kelimeyi alıyorum.
            Kasa.Text = (Int32.Parse(kontrol) + kont).ToString();//aldığım kelime ile tavuk ücreti değişkenini toplayıp string değişkene atıyorum.
            tavuk.TYumurta = 0;//yumurta satıldığı için adeti sıfırlıyorum.
            TavukAdet.Text = 0 + "ADET";
            Kasa.Text = Kasa.Text + " TL";

        }

        private void OrdekYSat_Click(object sender, EventArgs e)//ördek yumurtası satma butonu
        {

            int konta = ordek.KasaHesap(ordek.O_Yumurta, ordek.OYumurtaPara);//fonksiyondan gelen ördek ücretini değişkende tutuyorum.
            string kontrola = Kasa.Text.Substring(0, Kasa.Text.IndexOf(' '));//kasa labelinde yazan ifadeyi boşluğa kadar yani ilk kelimeyi alıyorum.
            Kasa.Text = (Int32.Parse(kontrola) + konta).ToString();//aldığım kelime ile ördek ücreti değişkenini toplayıp string değişkene atıyorum.
            ordek.O_Yumurta = 0;//yumurta satıldığı için adeti sıfırlıyorum.
            OrdekAdet.Text = 0 + "ADET";
            Kasa.Text = Kasa.Text + " TL";

        }

        private void InekSSat_Click(object sender, EventArgs e)//inek sütü satma butonu
        {
            int kontb = ınek.KasaHesap(ınek.ISutu, ınek.ISutuPara);//fonksiyondan gelen inek ücretini değişkende tutuyorum.
            string kontrolb = Kasa.Text.Substring(0, Kasa.Text.IndexOf(' '));//kasa labelinde yazan ifadeyi boşluğa kadar yani ilk kelimeyi alıyorum.
            Kasa.Text = (Int32.Parse(kontrolb) + kontb).ToString();//aldığım kelime ile inek ücreti değişkenini toplayıp string değişkene atıyorum.
            ınek.ISutu = 0;//süt satıldığı için adeti sıfırlıyorum.
            InekKg.Text = 0 + "KG";
            Kasa.Text = Kasa.Text + " TL";
        }

        private void KeciSSat_Click(object sender, EventArgs e)//keçi sütü satma butonu
        {
            int kontc = keci.KasaHesap(keci.KSutu, keci.KSutuPara);//fonksiyondan gelen keçi ücretini değişkende tutuyorum.
            string kontrolc = Kasa.Text.Substring(0, Kasa.Text.IndexOf(' '));//kasa labelinde yazan ifadeyi boşluğa kadar yani ilk kelimeyi alıyorum.
            Kasa.Text = (Int32.Parse(kontrolc) + kontc).ToString();//aldığım kelime ile keçi ücreti değişkenini toplayıp string değişkene atıyorum.
            keci.KSutu = 0;//süt satıldığı için adeti sıfırlıyorum.
            KeciKg.Text = 0 + "KG";
            Kasa.Text = Kasa.Text + " TL";
        }
    }
}
