using System;

namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
            Liste ogrenciler = new Liste();  // ögrenciler adında liste oluştur
            int numara;
            String ad, soyad, dersAdi;
            float vize, final;


            int secim = menu(); //seçim menümüz
            while (secim != 0)  //seçim döngümüz
            {
                switch (secim)
                {
                    case 1: //1. seçim için alınacak veriler
                        Console.Write("numara   : "); numara = int.Parse(Console.ReadLine());
                        Console.Write("İsim     : "); ad = Console.ReadLine();
                        Console.Write("Soyisim  : "); soyad = Console.ReadLine();
                        Console.Write("Ders Adı : "); dersAdi = Console.ReadLine();
                        Console.Write("Vize     : "); vize = float.Parse(Console.ReadLine());
                        Console.Write("Final    : "); final = float.Parse(Console.ReadLine());
                        ogrenciler.ekle(numara, ad, soyad, dersAdi, vize, final);
                        break;

                    case 2: //2. seçim için alınacak veriler
                        Console.Write("numara   : "); numara = int.Parse(Console.ReadLine());
                        ogrenciler.sil(numara);
                        break;
                    case 3: //3. seçim için yapılacak işlemler
                        Console.Clear();
                        ogrenciler.yazdir();
                        break;
                    case 4: //4. seçim için yapılacak işlemler
                        Console.Clear();
                        ogrenciler.enBasariliOgrenci();
                        break;

                    case 0: break; //döngüyü kır 


                    default:
                        Console.WriteLine("Hatalı seçim yaptınız !");
                        break;
                }
                secim = menu();

            }
            Console.WriteLine("Program kapatılıyor... ");
        }

        private static int menu()
        {
            int secim;
            Console.WriteLine("\n1- öğrenci ekle ");
            Console.WriteLine("2- öğrenci sil ");
            Console.WriteLine("3- öğrencileri yazdır ");
            Console.WriteLine("4- En başarılı öğrenciyi göster ");
            Console.WriteLine("0- Programı kapat ");
            Console.Write("Seçiminiz :  ");
            secim = int.Parse(Console.ReadLine());
            return secim;
        }
    }

    class Ogrenci   // Node 
    {
        // öğrenciden alınan değerler
        public int numara;
        public String ad, soyad, dersAdi;
        public float vize, final, ortalama;
        public string durum;

        public Ogrenci next;

        public Ogrenci(int n, string a, string s, string d, float v, float f)
        {
            this.numara = n;
            this.ad = a;
            this.soyad = s;
            this.dersAdi = d;
            this.vize = v;
            this.final = f;
            this.ortalama = this.vize * 40 / 100 + this.final * 60 / 100;
            this.durum = this.ortalama < 50 ? "Kaldı" : "Geçti";
            this.next = null;
        }
    }


    class Liste
    {
        Ogrenci head; //listenin başı 

        public Liste()
        {
            head = null;
        }


        public void ekle(int n, string a, string s, string d, float v, float f)
        {
            Ogrenci ogr = new Ogrenci(n, a, s, d, v, f);

            if (head == null) // listemiz boşsa 
            {
                head = ogr;
                Console.WriteLine(n + " numarali öğrenci listeye eklendi ");
            }
            else // listemiz boş değilse
            {
                ogr.next = head;
                head = ogr;
                Console.WriteLine(n + " numarali öğrenci eklendi");
            }
        }


        public void sil(int numara)
        {
            bool sonuc = false; //sonucumuz yanlışsa

            if (head == null) //listenin başı yoksa , boşsa
            {
                sonuc = true;
                Console.WriteLine("listede kayıtlı öğrenci yok ! ");
            }

            else if (head.next == null && head.numara == numara) // eğer listede sadece bir öğrenci varsa ve numara doğruysa
            {
                sonuc = true; //sonuç doğru
                head = null; // listenin başı yok 
                Console.WriteLine(numara + " numaralı öğrenci silindi, listede hiç öğrenci kalmadı ");
            }
            else if (head.next != null && head.numara == numara) //eğer listede birden fazla eleman varsa ve numara doğruysa
            {
                sonuc = true; //sonuç doğru
                head = head.next; //başının bir sonraki elemanına eşitler
                Console.WriteLine(numara + " numaralı öğrenci silindi, listede öğrenci var");
            }
            else // liste doluysa eğer
            {
                Ogrenci temp = head; //tempimiz listenin başı oldu
                Ogrenci temp2 = temp; //2. bir temp değeri oluşturduk


                while (temp.next != null) //listenin başından sonraki eleman null olmadığı sürece (listemiz birden fazla)
                {
                    if (numara == temp.numara) // aradığımız numara mevcutsa
                    {
                        sonuc = true; // ögrenci bulundu
                        temp2.next = temp.next; //temp2 nin sonrasını temp ' in sonrasına bağlıyoruz
                        Console.WriteLine(numara + " numaralı öğrenci silindi ");
                    }

                    temp2 = temp; // temp2'yi temp'e eşitliyoruz, böylece temp2 bir önceki elemana işaret ediyor (bir önceki elemanla bağlantı kesmemek için)
                    temp = temp.next; // temp'i bir sonraki elemana geçiyoruz kontrol etmek için

                }
                if (numara == temp.numara) // eğer son eleman aradığımız numaraya sahipse
                {
                    sonuc = true;
                    temp2.next = null; //temp2'nin next'ini null yapıyoruz(bu şekilde son elemanı siliyoruz)
                    Console.WriteLine(numara + " numaralı öğrenci silindi ");
                }


            }

            if (sonuc == false) // eğer öğrenci bulunmamışsa
            {
                Console.WriteLine(numara + " numaralı öğrenci kaydı yok ");
            }
        }


        public void yazdir()
        {
            if (head == null) // listenin başı yoksa
            {
                Console.WriteLine("Listede kayıtlı öğrenci yok !");
            }
            else
            {
                Ogrenci temp = head; //tempi listenin başı yapıyoruz

                Console.WriteLine("Numara\tAd\tSoyad\tDersAdi\tOrtalama\tDurum\n"); //tüm verileri yazdırıyoruz
                while (temp.next != null)
                {
                    Console.WriteLine(temp.numara + "\t" + temp.ad + "\t" + temp.soyad + "\t" + temp.dersAdi + "\t" + temp.ortalama + "\t" + temp.durum);
                    temp = temp.next;

                }
                Console.WriteLine(temp.numara + "\t" + temp.ad + "\t" + temp.soyad + "\t" + temp.dersAdi + "\t" + temp.ortalama + "\t" + temp.durum);

            }
        }


        public void enBasariliOgrenci() // başarılı öğrenci bulmamızı sağlayan metod
        {
            if (head == null)
            {
                Console.WriteLine("Listede kayıtlı öğrenci yok !");
            }
            else
            {
                Ogrenci temp = head; //tempimizi listenin başı yapıyoruz
                Ogrenci yuksekOgr = head; //yüksek öğrencimizi liste başı yapıyoruz
                float enYuksekOrtalama = head.ortalama; //listenin ortalama alıyoruz

                while (temp.next != null) // temp.next null olmadığı sürece döngü devam eder
                {
                    if (enYuksekOrtalama < temp.ortalama) // Eğer öğrencinin ortalaması daha yüksekse
                    {
                        enYuksekOrtalama = temp.ortalama; // En yüksek ortalamayı güncelliyoruz
                        yuksekOgr = temp; // En yüksek ortalamaya sahip öğrenciyi güncelliyoruz
                    }

                    temp = temp.next; // bir sonraki elemana geç

                }

                if (enYuksekOrtalama < temp.ortalama) // Eğer şu anki elemanın ortalaması, şu ana kadar bulunan en yüksek ortalamadan büyükse
                {
                    enYuksekOrtalama = temp.ortalama; // Şu anki elemanın ortalamasını en yüksek ortalama olarak güncelle
                    yuksekOgr = temp; // Şu anki elemanı, en yüksek ortalamaya sahip öğrenci olarak işaretle
                }



                Console.WriteLine("en yüksek ortalamalı öğrenci bilgileri : ");
                Console.WriteLine("Numara\tAd\tSoyad\tDersAdi\tOrtalama\tDurum\n");
                // bilgileri yazdır
                Console.WriteLine(yuksekOgr.numara + "\t" + yuksekOgr.ad + "\t" + yuksekOgr.soyad + "\t" + yuksekOgr.dersAdi + "\t" + yuksekOgr.ortalama + "\t" + yuksekOgr.durum);
            }
        }
    }
}
