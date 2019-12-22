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
** Bu sınıf (Defans), kalıtım ile Futbolcu sınıfının özelliklerini
** almıştır. Aynı zamanda bir orta sahanın sahip olacağı özellikler de eklenerek;
** PasVer ve GolVurusu metodları içerisinde skor hesapları yapılmıştır.
** Son olarak, bu hesap sonuçlarının başarılı olup olmadığı tespit edilmiştir.
**********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutbolOyunu
{
    class Defans : Futbolcu
    {
        //Rastgele sayı üretimi için Random sınıfının objesi oluşturuldu.
        Random randDef = new Random();

        //Rastgele üretilecek sayının yer alacağı aralıklar
        private const int MIN_VALUE = 50;
        private const int MAX_VALUE = 90;

        //ORTASAHA SINIFINA AİT ÖZELLİKLER
        protected int PozisyonAlma { get; set; }
        protected int Kafa { get; set; }
        protected int Sicrama { get; set; }

        //Oluşturulacak takıma Defans oyuncusu eklenmesi için yazılan constructor
        public Defans(string adSoyad, int formaNo) 
            : base(adSoyad, formaNo)
        {
            PozisyonAlma = randDef.Next(MIN_VALUE, MAX_VALUE);  //PasVer metodu icin özelliğe rastgele sayı atanması
            //GolVurusu metodu için özelliklere rastgele sayı atanması
            Kafa = randDef.Next(MIN_VALUE, MAX_VALUE);
            Sicrama = randDef.Next(MIN_VALUE, MAX_VALUE);
        }

        //Kalıtımla Futbolcu sınıfından alınan özelliklere; Defans sınıfının aralıklarına göre,
        //rastgele değer atayan, no parameter constructor
        public Defans()
        {
            //Sadece PasVer metodu için kullanılacak özelliklere rastgele sayı atanması
            Pas = randDef.Next(MIN_VALUE, MAX_VALUE);
            Dayaniklik = randDef.Next(MIN_VALUE, MAX_VALUE);

            //Hem PasVer metodu hem de GolVurusu metodu için kullanılacak özelliklere rastgele sayı atanması
            Yetenek = randDef.Next(MIN_VALUE, MAX_VALUE);
            DogalForm = randDef.Next(MIN_VALUE, MAX_VALUE);
            Sans = randDef.Next(MIN_VALUE, MAX_VALUE);

            //Sadece GolVurusu metodu için kullanılacak özelliklere rastgele sayı atanması
            Sut = randDef.Next(MIN_VALUE, MAX_VALUE);
            Kararlik = randDef.Next(MIN_VALUE, MAX_VALUE);
        }

        //Futbolcu sınıfının PasVer metodu override (metot ezme) keyword'ü kullanılarak tekrar yazılmıştır.
        public override bool PasVer()
        {
            double PasSkor = 0.0;   //Doğru sonuç üretmesi için başlangıç değeri olarak 0 verildi.

            //Defans sınıfının PasVer metodu için verilen skor hesabı kullanıldı.
            PasSkor = Pas * 0.3 + Yetenek * 0.3 + Dayaniklik * 0.1 + DogalForm * 0.1 + 
                      PozisyonAlma * 0.1 + Sans * 0.2;

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

            //Defans sınıfının GolVurusu metodu için verilen skor hesabı kullanıldı.
            GolSkor = Yetenek * 0.3 + Sut * 0.2 + Kararlik * 0.1 + DogalForm * 0.1 + 
                      Kafa * 0.1 + Sicrama * 0.1 + Sans * 0.1;

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
