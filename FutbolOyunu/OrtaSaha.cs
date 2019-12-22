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
** Bu sınıf (OrtaSaha), kalıtım ile Futbolcu sınıfının özelliklerini
** almıştır. Aynı zamanda bir orta sahanın sahip olacağı özellikler de eklenerek;
** PasVer ve GolVurusu metodları içerisinde skor hesapları yapılmıştır.
** Son olarak, bu hesap sonuçlarının başarılı olup olmadığı tespit edilmiştir.
**********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace FutbolOyunu
{
    class OrtaSaha : Futbolcu
    {
        //Rastgele sayı üretimi icin Random sınıfının objesi oluşturuldu.
        Random randOrt = new Random();
        //Rastgele üretilecek sayının yer alacağı aralıklar
        private const int MIN_VALUE = 60;
        private const int MAX_VALUE = 100;

        //ORTASAHA SINIFINA AİT ÖZELLİKLER
        protected int UzunTop { get; set; }
        protected int IlkDokunus { get; set; }
        protected int Uretkenlik { get; set; }
        protected int TopSurme { get; set; }
        protected int OzelYetenek { get; set; }

        //Adı ve forma numarası üst sınıftan alınan oyuncunun özellikleri için,
        //belirtilen aralıkta rastgele sayı üretir.
        public OrtaSaha(string adSoyad, int formaNo)
            : base(adSoyad, formaNo)
        {
            //PasVer metodu icin özelliklere rastgele sayı atanması
            UzunTop = randOrt.Next(MIN_VALUE, MAX_VALUE);
            TopSurme = randOrt.Next(MIN_VALUE, MAX_VALUE);

            //GolVurusu metodu için özelliğe rastgele sayi atanması
            IlkDokunus = randOrt.Next(MIN_VALUE, MAX_VALUE);

            Uretkenlik = randOrt.Next(MIN_VALUE, MAX_VALUE);

            //Iki metodun ortak kullandığı özelliğe rastgele sayı atanması
            OzelYetenek = randOrt.Next(MIN_VALUE, MAX_VALUE);   
        }

        //Kalıtımla Futbolcu sınıfından alınan ozelliklere; OrtaSaha sınıfının aralıklarına göre,
        //rastgele değer atayan constructor
        public OrtaSaha()
        {
            //Sadece PasVer metodu için kullanılacak özelliklere rastgele sayı atanması
            Pas = randOrt.Next(MIN_VALUE, MAX_VALUE);
            Dayaniklik = randOrt.Next(MIN_VALUE, MAX_VALUE);

            //Hem PasVer metodu hem de GolVurusu metodu için kullanılacak özelliklere rastgele sayı atanması
            Yetenek = randOrt.Next(MIN_VALUE, MAX_VALUE);
            DogalForm = randOrt.Next(MIN_VALUE, MAX_VALUE);
            Sans = randOrt.Next(MIN_VALUE, MAX_VALUE);

            //Sadece GolVurusu metodu için kullanılacak özelliklere rastgele sayı atanması
            Sut = randOrt.Next(MIN_VALUE, MAX_VALUE);
            Kararlik = randOrt.Next(MIN_VALUE, MAX_VALUE);
        }

        //Futbolcu sınıfının PasVer metodu override (metot ezme) keyword'ü kullanılarak tekrar yazılmıştır.
        public override bool PasVer()
        {
            double PasSkor = 0.0;   //Doğru sonuç üretmesi için başlangıç değeri olarak 0 verildi.

            //OrtaSaha sınıfının PasVer metodu için verilen skor hesabı kullanıldı.
            PasSkor = Pas * 0.3 + Yetenek * 0.2 + OzelYetenek * 0.2 + Dayaniklik * 0.1 + 
                      DogalForm * 0.1 + UzunTop * 0.1 + TopSurme * 0.1 + Sans * 0.1;

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

            //OrtaSaha sınıfının GolVurusu metodu için verilen skor hesabı kullanıldı.
            GolSkor = Yetenek * 0.3 + OzelYetenek * 0.2 + Sut * 0.2 + IlkDokunus * 0.1 +
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
