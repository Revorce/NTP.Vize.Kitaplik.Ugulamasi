using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTP.Vize.Kitaplik.Ugulamasi
{
    public class Kitaplik
    {
        private static string kitapadi;
        private static string yazaradi;
        private static DateTime basimtarihi;
        private static string kitapturu;

        public static string Kitapadi { get => kitapadi; set => kitapadi = value; }
        public static string Yazaradi { get => yazaradi; set => yazaradi = value; }
        public static DateTime Basimtarihi { get => basimtarihi; set => basimtarihi = value; }
        public static string Kitapturu { get => kitapturu; set => kitapturu = value; }

        private static int kitapsayi;
        private static int tarih;


        public Kitaplik(string kitapadi, string yazaradi, DateTime basimtarihi, string kitapturu)
        {
            Kitapadi = kitapadi;
            Yazaradi = yazaradi;
            Basimtarihi = basimtarihi;
            Kitapturu = kitapturu;
        }


        public static void KitabiYazdir(Kitaplik[] kitapdizisi, int i)
        {
            FileStream fs = new FileStream("D:/kitapkayitlari.txt", FileMode.Append, FileAccess.Write, FileShare.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(kitapdizisi[i].KitapDizisi());
            fs.Flush();
            sw.Close();
            fs.Close();
        }


        public static void KitaplariGoruntule()
        {
            string line;
            StreamReader file = new StreamReader(@"D:/kitapkayitlari.txt");
            while ((line = file.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
            file.Close();
        }
        public static void KitapEkleme()
        {
            Console.Write("Kaç Kitap Eklemek İstiyorsunuz? ");
            kitapsayi = int.Parse(Console.ReadLine());
            Kitaplik[] kitapdizisi = new Kitaplik[kitapsayi];

            for (int i = 0; i < kitapsayi; i++)
            {
                Console.Write("Kitap Adını Giriniz: ");
                Kitapadi = Console.ReadLine();
                Console.Write("Kitap Yazarını Giriniz: ");
                Yazaradi = Console.ReadLine();
                Console.Write("Kitap Basım Yılını Giriniz: ");
                do
                {
                    tarih = int.Parse(Console.ReadLine());
                    if (tarih > 2020)
                    {
                        Console.Write("Basım yılı 2020'den büyük olamaz.\nTekrar Giriniz: ");
                    }
                } while (tarih > 2020);
                Basimtarihi = new DateTime(tarih, 1, 1);
                Console.Write("Kitap Türünü Giriniz: ");
                Kitapturu = Console.ReadLine();
                Kitaplik kitap = new Kitaplik(Kitapadi, Yazaradi, Basimtarihi, Kitapturu);
                kitapdizisi[i] = kitap;
                KitabiYazdir(kitapdizisi, i);
            }
        }
        public string KitapDizisi() => $"Kitap Adı:{Kitapadi} | Yazar Adı:{Yazaradi} | Basım Tarihi:{Basimtarihi.Year} | Kitap Türü:{Kitapturu}";
    }
}
