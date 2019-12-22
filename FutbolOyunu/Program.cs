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
** Program sınıfı, yaptığımız Futbol Oyunu'nun çalıştırıldığı main sınıftır.
** Futbolcu türünden bir nesne oluşturulur ve bu nesne üzerinde işlem yapılır.
** Ödevdeki Örnek Çalışma Durumu'nda belirtildiği gibi bir çıktı elde edilir.
**********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FutbolOyunu
{
    class Program
    {
        //Üzerinde işlem yapılacak Futbolcu sınıfı nesnesi oluşturuldu.
        private static List<Futbolcu> takim = new List<Futbolcu>();
        //Forma nolarının alabileceği minimum ve maksimum değerleri
        private const int MIN_FORMA_NO = 1;
        private const int MAX_FORMA_NO = 11;
        //Oyuncunun kendi kendisine pas verememesi için tutulan integer dizinin boyutu ve ilk değeri
        private const int SIZE = 3;
        private const int FIRST = 0;

        static void Main(string[] args)
        {
            //Main'in daha sade görünmesi adına; tüm işlemler Test metodunda yapılmış
            //ve mainde sadece Test metodu çağrılmıştır.
            Test();
        }

        //İstenen ekran çıktısının üretilmesi için, genel programa ait kontrol ve testin yapıldığı metod
        private static void Test()
        {
            //Oyuncunun forma numarasının rastgele belirlenmesi için,
            //Random sınıf örneği (instance) oluşturuldu.
            Random RastgeleSayi = new Random();

            //Oyuncuların tek tek eklenmesi (4-4-2 dizilişi ile)
            takim.Add(new Futbolcu("Mert Günok", MIN_FORMA_NO)); 
            takim.Add(new Defans("Zeki Çelik", 2));
            takim.Add(new Defans("Ozan Kabak", 3));
            takim.Add(new Defans("Merih Demiral", 4));
            takim.Add(new Defans("Hasan Ali Kaldırım", 5));
            takim.Add(new OrtaSaha("Okay Yokuşlu", 6));
            takim.Add(new OrtaSaha("Emre Belözoğlu", 7));
            takim.Add(new OrtaSaha("Hakan Çalhanoğlu", 8));
            takim.Add(new OrtaSaha("Cengiz Ünder", 9));
            takim.Add(new Forvet("Burak Yılmaz", 10));
            takim.Add(new Forvet("Cenk Tosun", MAX_FORMA_NO));

            int FormaNo;                //oyuncunun forma numarası
            bool gololabilir = true;    //gol olmasını kontrol eden değişken
            
            //Oyuncu kendisine pas veremeyeceğinden, ard arda gelen forma numarasının
            //aynı olmaması için tutulan integer dizisi değişkeni
            int[] ayniOyuncuMu = new int[SIZE] { FIRST, FIRST, FIRST };
            int i;  //for döngüsü dışında da erişilebilmesi için döngü dışında tanımlandı.

            Console.WriteLine();
            Console.WriteLine("\t\t # FUTBOL OYUNUNA HOŞGELDİNİZ # ");
            Console.WriteLine("\t\t   --------------------------");
            Console.WriteLine();
            //3 kere pas verme işlemi yapılır.
            for (i = FIRST; i < SIZE; i++)
            {
                //Bir oyuncu kendisine pas verememesi için yazılan label kontrolü
                yenidenUret_1:
                //Hangi oyuncuya pas verileceğini rastgele belirler.
                FormaNo = RastgeleSayi.Next(MIN_FORMA_NO, MAX_FORMA_NO);
                //Döngu 1'den başladigi için 0. elemana rastgele üretilen forma no atandı. 
                ayniOyuncuMu[i] = FormaNo;   
                
                //İlk olarak rastgele seçilen oyuncu yazdırılır.
                if (i == FIRST)
                {
                    Console.Write(" Oyuncu seç   => ");
                    Console.WriteLine("Rastgele olarak {0} numaralı oyuncu seçildi.", FormaNo);
                    Console.WriteLine();
                }
                //PasVer metodu başarılı değilse, ekrana hata mesajı bastırılır.
                if (!takim[FormaNo].PasVer())
                {
                    gololabilir = false;
                    Console.WriteLine("{0} numaralı oyuncu ({1}) için PasVer metodu başarısız!!", FormaNo, takim[FormaNo].AdSoyad);
                    break;
                }
                //Başarılı ise oyuna başlar.
                else
                {
                    //2. rastgele oyuncudan sonra bir öncekiyle kontrol et.
                    if (i > FIRST)
                    {
                        //Eğer aynı forma numaralı oyuncu ise, forma numarası üretilen yere git ve yeniden üret.
                        if (ayniOyuncuMu[i-1] == ayniOyuncuMu[i])
                        {
                            goto yenidenUret_1;
                        }
                        //Aynı oyuncu değilse seçilen oyuncunun numarasını yazdır.
                        else
                        {
                            Console.WriteLine(" (Örnek: Rastgele olarak {0} nolu oyuncu seçildi)", ayniOyuncuMu[i]);
                            Console.WriteLine();
                        }
                    }
                    //Aşağıdaki gibi devam et ve PasVer işlemini bitir.
                    Console.Write(" Pas Ver      => ");
                    Console.WriteLine("{0} numaralı oyuncu için PasVer metodunu çağır PasVer başarılı.", FormaNo);
                    Console.Write(" Başka bir oyuncu seç..");
                }
            }

            //GolVurusu işlemine başla.
            if (gololabilir)
            {
                //Bir oyuncu gol atması için kendisine pas veremeyeceğinden dolayı yazılan label kontrolü
                yenidenUret_2:
                //Forma numarası üret.
                FormaNo = RastgeleSayi.Next(MIN_FORMA_NO, MAX_FORMA_NO);
                
                //GolVurusu başarılı ise, gol olduğunu belirterek, golü atan oyuncunun adını ve forma numarasını yazdır.
                if (takim[FormaNo].GolVurusu())
                {
                    //Golü atacak oyuncu ile ona son pası veren oyuncu aynı kişi olamaz.
                    if (FormaNo+1 != ayniOyuncuMu[i-1])
                    {
                        //Seçilen oyuncunun numarasını yazdır.
                        Console.WriteLine(" (Örnek: Rastgele olarak {0} nolu oyuncu seçildi)", FormaNo+1);
                        Console.WriteLine();

                        //Gol vuruşu yap ve golü atan oyuncu ile forma numarasını ekrana yazdır.
                        Console.Write(" Gol Vuruşu   => ");
                        Console.WriteLine("{0} nolu oyuncu icin GolVurusu Metodunu çalıştır.", FormaNo+1);
                        Console.WriteLine();
                        Console.WriteLine("\t\t==> GOLLLL {0} {1} <==", FormaNo+1, takim[FormaNo].AdSoyad);
                    }
                    //Aynı kişi ise üretilen yere git ve tekrar üret.
                    else
                    {
                        goto yenidenUret_2;
                    }
                }
                //Değilse hata mesajı ver.
                else
                {
                    Console.WriteLine("(Örnek: Rastgele olarak {0} nolu oyuncu seçildi)", FormaNo);
                    Console.WriteLine();
                    Console.WriteLine("    !! {0} numaralı oyuncu ({1}) için GolVurusu metodu başarısız !!", FormaNo, takim[FormaNo-1].AdSoyad);
                }
            }
            //Böylece oyunumuz sonlanmış oldu.

            Console.ReadKey();
        }
    }
}
