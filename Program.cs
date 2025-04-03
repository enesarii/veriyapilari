using System;
using System.Collections;
using System.Threading.Tasks.Dataflow;

public class HashTableIslemleri
{
    // HashTable'ı temsil ediyoruz
    private Hashtable tablo;  // HashTable veri yapısını tanımlıyoruz

    public HashTableIslemleri()
    {
        // Yeni bir HashTable oluşturuyoruz
        tablo = new Hashtable();  // HashTable nesnesi oluşturuluyor
    }

    // HashTable'a yeni veri eklemek için metot
    public void VeriEkle(int numara, string isim)
    {
        if (!tablo.ContainsKey(numara)) // Aynı numara daha önce eklenmemişse
        {
            tablo.Add(numara, isim); // Numara ve ismi ekliyoruz
            Console.WriteLine($"Başarıyla {isim} eklendi.");
        }
        else
        {
            Console.WriteLine("Bu numara zaten mevcut.");
        }
    }

    // HashTable'ın tüm içeriğini yazdırmak için metot
    public void TabloyuYazdir()
    {
        if (tablo.Count == 0) // Eğer tablo boşsa
        {
            Console.WriteLine("Tablo boş.");
            return;  // Tablo boşsa işlem bitiriliyor
        }

        Console.WriteLine("\nTablodaki Öğrenciler:");
        foreach (DictionaryEntry entry in tablo) // HashTable'ı döngü ile gezip verileri yazdırıyoruz
        {
            Console.WriteLine($"Numara: {entry.Key}, İsim: {entry.Value}");  // Her bir öğeyi yazdırıyoruz
        }
    }

    // Belirli bir numarayı aramak için metot
    public void KisiBul(int numara)
    {
        if (tablo.ContainsKey(numara))  // Eğer numara HashTable'da varsa
        {
            Console.WriteLine($"Numara {numara} - İsim: {tablo[numara]}");  // Numara ve ismi ekrana yazdırıyoruz
        }
        else
        {
            Console.WriteLine($"{numara} numaralı kişi bulunamadı.");
        }
    }

    // Belirli bir numarayı silmek için metot
    public void KisiSil(int numara)
    {
        if (tablo.ContainsKey(numara))  // Eğer numara HashTable'da varsa
        {
            tablo.Remove(numara);  // HashTable'dan numarayı sileriz
            Console.WriteLine($"{numara} numaralı kişi silindi.");
        }
        else
        {
            Console.WriteLine($"{numara} numaralı kişi bulunamadı.");
        }
    }

    // Tabloyu temizlemek için metot
    public void TabloyuTemizle()
    {
        tablo.Clear();  // HashTable'daki tüm verileri temizler
        Console.WriteLine("Tablo temizlendi.");
    }
}

public class Program
{
    public static void Main()
    {
        // HashTableIslemleri sınıfından nesne oluşturuyoruz
        HashTableIslemleri hashTable = new HashTableIslemleri(); // Veri işlemleri için nesne oluşturuluyor

        // Kullanıcıdan veri girişi alalım
        bool devamEt = true; // Ana döngü için flag (devam etmesi için true başlatıyoruz)
        while (devamEt)  // Menü döngüsü
        {
            Console.WriteLine("\nLütfen yapmak istediğiniz işlemi seçin:");  // Kullanıcıya seçenekler sunuluyor
            Console.WriteLine("1. Veri Ekle");
            Console.WriteLine("2. Tabloyu Yazdır");
            Console.WriteLine("3. Kişi Bul");
            Console.WriteLine("4. Kişi Sil");
            Console.WriteLine("5. Tabloyu Temizle");
            Console.WriteLine("6. Çıkış");

            int secim;  // Kullanıcının seçimini alıyoruz
            if (int.TryParse(Console.ReadLine(), out secim))  // Kullanıcıdan gelen input'u int türüne dönüştürüyoruz
            {
                switch (secim)  // Seçime göre işlem yapıyoruz
                {
                    case 1:  // Veri ekleme
                        Console.Write("Numara girin: ");  // Kullanıcıdan numara alıyoruz
                        int numara = Convert.ToInt32(Console.ReadLine());  // Numara inputu alınıyor

                        Console.Write("İsim girin: ");  // Kullanıcıdan isim alıyoruz
                        string isim = Console.ReadLine();  // İsim inputu alınıyor

                        hashTable.VeriEkle(numara, isim);  // HashTable'a veri ekleniyor
                        break;

                    case 2:  // Tabloyu yazdırma
                        hashTable.TabloyuYazdir();  // Tabloyu ekrana yazdırıyoruz
                        break;

                    case 3:  // Kişi arama
                        Console.Write("Aramak istediğiniz numarayı girin: ");  // Kullanıcıdan arama yapılacak numara alınıyor
                        int arananNumara = Convert.ToInt32(Console.ReadLine());  // Numara inputu alınıyor
                        hashTable.KisiBul(arananNumara);  // Kişiyi arıyoruz
                        break;

                    case 4:  // Kişi silme
                        Console.Write("Silmek istediğiniz numarayı girin: ");  // Kullanıcıdan silinecek numara alınıyor
                        int silinecekNumara = Convert.ToInt32(Console.ReadLine());  // Numara inputu alınıyor
                        hashTable.KisiSil(silinecekNumara);  // Kişiyi siliyoruz
                        break;

                    case 5:  // Tabloyu temizleme
                        hashTable.TabloyuTemizle();  // Tabloyu temizliyoruz
                        break;

                    case 6:  // Çıkış
                        devamEt = false;  // Döngüyü sonlandırıyoruz
                        break;

                    default:  // Geçersiz seçenek
                        Console.WriteLine("Geçersiz seçim! Lütfen tekrar deneyin.");
                        break;
                }
            }
            else  // Eğer geçersiz bir seçim yapıldıysa
            {
                Console.WriteLine("Geçersiz giriş! Lütfen geçerli bir seçenek girin.");
            }
        }

        Console.WriteLine("Program sonlandırıldı.");
    }
}

