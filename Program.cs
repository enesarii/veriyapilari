using System;
using System.Collections.Generic; // Stack kullanabilmek için gerekli kütüphane

public class Program
{
    public static void Main()
    {
        // Stack (Yığın) yapısını tanımlıyoruz. 
        // Stack, Last In First Out (LIFO) prensibine göre çalışır. Yani son eklenen ilk çıkar.
        Stack<int> yigin = new Stack<int>();

        // Kullanıcıya kaç eleman eklemek istediğini soruyoruz.
        Console.WriteLine("Kaç eleman eklemek istersiniz?");
        int elemanSayisi;

        // Kullanıcıdan geçerli bir sayı almayı sağlıyoruz
        while (!int.TryParse(Console.ReadLine(), out elemanSayisi) || elemanSayisi <= 0)
        {
            Console.WriteLine("Lütfen geçerli bir pozitif sayı girin.");
        }

        // Kullanıcıdan elemanları alıp yığına ekliyoruz
        for (int i = 0; i < elemanSayisi; i++)
        {
            Console.WriteLine($"Yığına eklemek istediğiniz {i + 1}. elemanı girin:");
            int eleman;

            // Kullanıcıdan geçerli bir sayı alıyoruz
            while (!int.TryParse(Console.ReadLine(), out eleman))
            {
                Console.WriteLine("Lütfen geçerli bir sayı girin.");
            }

            yigin.Push(eleman); // Yığına elemanı ekliyoruz
        }

        // Stack'in şu anki durumunu ekrana yazdırıyoruz.
        Console.WriteLine("\nYığındaki elemanlar (ters sırayla):");
        // Stack içerisindeki elemanları ters sırayla yazdırıyoruz
        foreach (int eleman in yigin)
        {
            Console.WriteLine(eleman); // Yığındaki her elemanı yazdırıyoruz
        }

        // Yığın yapısında eleman çıkarmak için Pop metodu kullanılır.
        // Pop metodu, yığından en son eklenen elemanı çıkarır.
        if (yigin.Count > 0)
        {
            Console.WriteLine("\nYığından çıkarılan eleman: " + yigin.Pop());
        }
        else
        {
            Console.WriteLine("\nYığın boş, çıkarılacak eleman yok.");
        }

        // Yığındaki elemanları tekrar yazdırıyoruz.
        Console.WriteLine("\nPop işleminden sonra yığındaki elemanlar:");
        // Yığındaki her elemanı ters sırayla yazdırmak için ToArray() kullanıyoruz
        foreach (int eleman in yigin.ToArray())
        {
            Console.WriteLine(eleman); // Yığındaki her elemanı yazdırıyoruz
        }

        // Peek metodu, yığındaki en üstteki elemanı çıkarılmadan görüntülememizi sağlar.
        if (yigin.Count > 0)
        {
            Console.WriteLine("\nYığının en üst elemanı (Peek): " + yigin.Peek());
        }
        else
        {
            Console.WriteLine("\nYığın boş, en üst eleman yok.");
        }

        // Yığının boş olup olmadığını kontrol ediyoruz.
        Console.WriteLine("\nYığın boş mu? " + (yigin.Count == 0));

        // Yığının son durumu yazdırılıyor
        Console.WriteLine("\nYığının son durumu:");
        foreach (int eleman in yigin.ToArray())
        {
            Console.WriteLine(eleman); // Yığındaki her elemanı yazdırıyoruz
        }

        // Programın kapanmasını engellemek için bir tuşa basmayı bekliyoruz
        Console.WriteLine("\nProgramı kapatmak için bir tuşa basın...");
        Console.ReadLine(); // Program kapanmadan önce duraklatma
    }
}
