/*********************************************************************************
** SAKARYA ÜNİVERSİTESİ
** BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
** BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
** NESNEYE DAYALI PROGRAMLAMA DERSİ
** 2018-2019 BAHAR DÖNEMİ
**
** ÖDEV NUMARASI..........: 2
** ÖĞRENCİ ADI............: OĞUZHAN TOHUMCU
** ÖĞRENCİ NUMARASI.......: B181210397
** DERSİN ALINDIĞI GRUP...: 1-D
**
** AÇIKLAMA
** --------
** Futbolcu sınıfı kendisinden kalıtım alacak 3 sınıfın (Defans, OrtaSaha, Forvet)
** üst sınıfıdır ve içerisinde genel özellikler tanımlanmıştır.
** Bu sınıftan sadece Kaleci için nesne oluşturulabilir. Diğer oyuncuların
** nesneleri kendi ait oldukları sınıflarda yapılmıştır.
**********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutbolOyunu
{
    class Futbolcu
    {
        //Rastgele sayı üretimi icin Random sınıfının objesi oluşturuldu.
        Random randFut = new Random();
        //Rastgele üretilecek sayının yer alacağı aralıklar
        private const int MIN_VALUE = 50;
        private const int MAX_VALUE = 100;

        //FUTBOLCU SINIFINA AİT ÖZELLİKLER
        public string AdSoyad { get; set; }
        public int FormaNo { get; set; }
        public int Hiz { get; set; }
        public int Dayaniklik { get; set; }
        public int Pas { get; set; }
        public int Sut { get; set; }
        public int Yetenek { get; set; }
        public int Kararlik { get; set; }
        public int DogalForm { get; set; }
        public int Sans { get; set; }

        //No parameter constructor
        //Futbolcu sınıfından bir nesne oluşturulduğunda ilk olarak bu constructor çalışır.
        public Futbolcu()
        {
            //Sadece PasVer metodunda kullanılacak özelliklere rastgele sayı atanması
            Dayaniklik = randFut.Next(MIN_VALUE, MAX_VALUE);
            Pas = randFut.Next(MIN_VALUE, MAX_VALUE);

            //Hem PasVer hem de GolVurusu metotlarında kullanılacak özelliklere rastgele sayı atanması
            Yetenek = randFut.Next(MIN_VALUE, MAX_VALUE);
            DogalForm = randFut.Next(MIN_VALUE, MAX_VALUE);
            Sans = randFut.Next(MIN_VALUE, MAX_VALUE);

            //Sadece GolVurusu metodunda kullanılacak özelliklere rastgele sayı atanması
            Sut = randFut.Next(MIN_VALUE, MAX_VALUE);
            Kararlik = randFut.Next(MIN_VALUE, MAX_VALUE);
            Hiz = randFut.Next(MIN_VALUE, MAX_VALUE);
        }

        //Kaleci için gelen adSoyad ve formaNo bilgileri (deĞerleri) ilgili sınıf değişkenlerine atanır.
        //Futbolcu sınıfının diğer özellikleri, rastgele olarak (50-100 arasında) oluşturulur ve sınıf değişkenlerine atanır.
        public Futbolcu(string adSoyad, int formaNo)
        {
            AdSoyad = adSoyad;
            FormaNo = formaNo;
            //İlgili oyuncuya ait özellikler rastgele (min-max aralığında) belirlenir.
            Hiz = randFut.Next(MIN_VALUE, MAX_VALUE);
            Dayaniklik = randFut.Next(MIN_VALUE, MAX_VALUE);
            Pas = randFut.Next(MIN_VALUE, MAX_VALUE);
            Sut = randFut.Next(MIN_VALUE, MAX_VALUE);
            Yetenek = randFut.Next(MIN_VALUE, MAX_VALUE);
            Kararlik = randFut.Next(MIN_VALUE, MAX_VALUE);
            DogalForm = randFut.Next(MIN_VALUE, MAX_VALUE);
            Sans = randFut.Next(MIN_VALUE, MAX_VALUE);
        }

        //Futbolcu sınıfından türetilecek sınıflarda PasVer metodu tekrar yazılacağı için,
        //metodun başına "virtual" keyword'ü koyulmuştur. 
        public virtual bool PasVer()
        {
            double PasSkor = 0.0;   //Doğru sonuç üretmesi için başlangıç değeri olarak 0 verildi.

            //Futbolcu sınıfının PasVer metodu için verilen skor hesabı kullanıldı.
            PasSkor = Pas * 0.3 + Yetenek * 0.3 + Dayaniklik * 0.1 + DogalForm * 0.1 + 
                      Sans * 0.2;

            //PasSkor 60'tan büyük ise true olarak döndürülür.
            if (PasSkor > 60.0)
            {
                return true;
            }
            //Aksi taktirde false döndürülür.
            return false;
        }

        //Futbolcu sınıfından türetilecek sınıflarda GolVurusu metodu tekrar yazılacağı için,
        //metodun başına "virtual" keyword'ü koyulmuştur. 
        public virtual bool GolVurusu()
        {
            double GolSkor = 0.0;   //Doğru sonuç üretmesi için başlangıç değeri olarak 0 verildi.

            //Futbolcu sınıfının GolVurusu metodu için verilen skor hesabı kullanıldı.
            GolSkor = Yetenek * 0.3 + Sut * 0.2 + Kararlik * 0.1 + DogalForm * 0.1 + 
                      Hiz * 0.1 + Sans * 0.2;

            //GolSkor 70'ten büyük ise true olarak döndürülür.
            if (GolSkor > 70.0)
            {
                return true;
            }
            //Aksi taktirde false döndürülür.
            return false;
        }
    }
}
