using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NTP.Vize.Kitaplik.Ugulamasi
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string cevap = "";
                Console.WriteLine("Uygulama Çalıştı \nTarih/Saat: " + DateTime.Now);
                do
                {
                    Console.WriteLine("\n \n" + "Hangi İşlemi Yapmak İstiyorsunuz?\n" + "1.Kitapevine kitap eklemek \n2.Kitaplığı görüntülemek.");
                    Console.Write("\nİşlemini Yapmak İstediğiniz Fonksiyonun Rakamını Giriniz: ");
                    char secim = char.Parse(Console.ReadLine());

                    if (secim == '1')
                    {
                        Kitaplik.KitapEkleme();
                    }
                    else if (secim == '2')
                    {
                        Kitaplik.KitaplariGoruntule();
                    }
                    else
                    {
                        Console.WriteLine("İki Seçenekten Birini Seçiniz (1/2)");
                    }
                    Console.Write("\nBaşka İşlem Yapmak İstiyor Musunuz? (e/h)");
                    cevap = Console.ReadLine();
                } while (cevap == "e");
            }
            catch (Exception)
            {
                Console.WriteLine("Yanlış Değer Girdiniz, Tekrar Deneyiniz");
            }
        }
    }
}
