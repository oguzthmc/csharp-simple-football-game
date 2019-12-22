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
** Bu sınıf (Forvet), kalıtım ile Futbolcu sınıfının özelliklerini
** almıştır. Aynı zamanda bir forvetin sahip olacağı özellikler de eklenerek;
** PasVer ve GolVurusu methodları içerisinde skor hesapları yapılmıştır.
** Son olarak, bu hesap sonuçlarının başarılı olup olmadığı tespit edilmiştir.
**********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutbolOyunu
{
    class Forvet : Futbolcu
    {
        //Rastgele sayı üretimi icin Random sınıfının objesi oluşturuldu.
        Random randFor = new Random();
        //Rastgele üretilecek sayının yer alacağı aralıklar
        private const int MIN_VALUE = 70;
        private const int MAX_VALUE = 100;

        //FORVET SINIFINA AİT ÖZELLİKLER
        protected int Bitiricilik { get; set; }
        protected int IlkDokunus { get; set; }
        protected int Kafa { get; set; }
        protected int OzelYetenek { get; set; }
        protected int SogukKanlilik { get; set; }

        //Oyuncunun adı ve numarası Futbolcu sınıfından kalıtım ile alınır.
        public Forvet(string adSoyad, int formaNo) 
            : base(adSoyad, formaNo)
        {
            //Sadece GolVurusu metodunda kullanılacak özelliklere rastgele değer atanması
            Bitiricilik = randFor.Next(MIN_VALUE, MAX_VALUE);
            IlkDokunus = randFor.Next(MIN_VALUE, MAX_VALUE);
            Kafa = randFor.Next(MIN_VALUE, MAX_VALUE);
            SogukKanlilik = randFor.Next(MIN_VALUE, MAX_VALUE);
            //Hem PasVer hem de GolVurusu metotlarında kullanılacak özelliğe rastgele değer atanması
            OzelYetenek = randFor.Next(MIN_VALUE, MAX_VALUE);
        }

        //No parameter constructor
        public Forvet()
        {
            //Sadece PasVer metodunda kullanılacak özelliklere rastgele deger atanması
            Pas = randFor.Next(MIN_VALUE, MAX_VALUE);
            Dayaniklik = randFor.Next(MIN_VALUE, MAX_VALUE);

            ////Hem PasVer hem de GolVurusu metotlarında kullanılacak özelliğe rastgele değer atanması
            Yetenek = randFor.Next(MIN_VALUE, MAX_VALUE);
            DogalForm = randFor.Next(MIN_VALUE, MAX_VALUE);
            Sans = randFor.Next(MIN_VALUE, MAX_VALUE);

            //Sadece GolVurusu metodunda kullanılacak özelliklere rastgele değer atanması
            Sut = randFor.Next(MIN_VALUE, MAX_VALUE);
            Kararlik = randFor.Next(MIN_VALUE, MAX_VALUE);
        }

        //Futbolcu sınıfının PasVer metodu override (metot ezme) keyword'ü kullanılarak tekrar yazılmıştır.
        public override bool PasVer()
        {
            double PasSkor = 0.0;   //Doğru sonuç üretmesi için başlangıç değeri olarak 0 verildi.

            //Forvet sınıfının PasVer metodu için verilen skor hesabı kullanıldı.
            PasSkor = Pas * 0.3 + Yetenek * 0.2 + OzelYetenek * 0.2 + Dayaniklik * 0.1 + 
                      DogalForm * 0.1 + Sans * 0.1;

            //PasSkor 60'tan büyük ise true olarak döndürülür.
            if (PasSkor > 60.0)
            {
                return true;
            }
            //Aksi taktirde false döndürülür.
            return false;
        }

        //Futbolcu sınıfının GolVurusu metodu override (metot ezme) keyword'ü kullanılarak tekrar yazılmıştır.
        public override bool GolVurusu()
        {
            double GolSkor = 0.0;   //Doğru sonuç üretmesi için başlangıç değeri olarak 0 verildi.

            //Forvet sınıfının GolVurusu metodu için verilen skor hesabı kullanıldı.
            GolSkor = Yetenek * 0.2 + OzelYetenek * 0.2 + Sut * 0.1 + Kafa * 0.1 +
                      IlkDokunus * 0.1 + Bitiricilik * 0.1 + SogukKanlilik * 0.1 +
                      Kararlik * 0.1 + DogalForm * 0.1 + Sans * 0.1;

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
