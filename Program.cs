using System;

public class AğaçNode
{
    // Ağaç düğümünü temsil eder.
    // Bir düğümde, veri ve sol ve sağ düğüm vardır.
    public int Veri; // Düğümdeki veri
    public AğaçNode Sol; // Sol alt düğüm
    public AğaçNode Sağ; // Sağ alt düğüm

    // Düğümün constructor'ı
    public AğaçNode(int veri)
    {
        Veri = veri; // Düğümdeki veriyi ayarlıyoruz
        Sol = null;  // Sol alt ağacın başlangıçta boş olduğunu belirliyoruz
        Sağ = null;  // Sağ alt ağacın başlangıçta boş olduğunu belirliyoruz
    }
}

public class Ağaç
{
    public AğaçNode Kök; // Ağaç yapısının başlangıç düğümü (root)

    // Ağaç constructor'ı
    public Ağaç()
    {
        Kök = null; // Ağacın başlangıçta boş olduğunu belirliyoruz
    }

    // Ağaca yeni bir düğüm eklemek için yöntem
    public void Ekle(int veri)
    {
        Kök = EkleRec(Kök, veri); // Veriyi ağaca eklemek için rekürsif fonksiyon (Binary Search Tree) çağrılır
    }

    // Ağaca yeni bir düğüm eklerken rekürsif (recursive) yöntem
    private AğaçNode EkleRec(AğaçNode kök, int veri)
    {
        if (kök == null) // Eğer ağacın kökü boşsa, yeni bir düğüm ekleriz
        {
            kök = new AğaçNode(veri); // Yeni düğüm oluşturuluyor
            return kök; // Yeni düğüm geri döndürülüyor
        }

        // Eğer eklenen veri küçükse, sol alt ağaca git
        if (veri < kök.Veri)
        {
            kök.Sol = EkleRec(kök.Sol, veri); // Sol alt ağaca veri ekleriz
        }
        // Eğer eklenen veri büyükse, sağ alt ağaca git
        else if (veri > kök.Veri)
        {
            kök.Sağ = EkleRec(kök.Sağ, veri); // Sağ alt ağaca veri ekleriz
        }

        return kök; // Kökü geri döndürerek ağacın yapısını koruruz
    }

    // Pre-order (Önce kök, sonra sol, sonra sağ) gezintisi
    public void PreOrder()
    {
        PreOrderRec(Kök); // Pre-order gezintisini başlatıyoruz
    }

    // Rekürsif Pre-order gezintisi (önce kökü yazar sonra sol sonra sağ)
    private void PreOrderRec(AğaçNode node)
    {
        if (node != null) // Eğer düğüm boş değilse
        {
            Console.Write(node.Veri + " "); // Önce kök (düğüm) yazdırılır
            PreOrderRec(node.Sol); // Sol alt ağaca geçilir
            PreOrderRec(node.Sağ); // Sağ alt ağaca geçilir
        }
    }

    // In-order (Sol, kök, sağ) gezintisi
    public void InOrder()
    {
        InOrderRec(Kök); // In-order gezintisini başlatıyoruz (önce sol tarafı yazar,sonra kök sonra sağ taraf)
    }

    // Rekürsif In-order gezintisi (ortada kök) 
    private void InOrderRec(AğaçNode node)
    {
        if (node != null) // Eğer düğüm boş değilse
        {
            InOrderRec(node.Sol); // Sol alt ağaca geçilir
            Console.Write(node.Veri + " "); // Kök (düğüm) yazdırılır
            InOrderRec(node.Sağ); // Sağ alt ağaca geçilir
        }
    }

    // Post-order (Sol, sağ, kök) gezintisi
    public void PostOrder() // önce en sol , sağ ve en son kök
    {
        PostOrderRec(Kök); // Post-order gezintisini başlatıyoruz
    }

    // Rekürsif Post-order gezintisi (köke en son uğra)
    private void PostOrderRec(AğaçNode node)
    {
        if (node != null) // Eğer düğüm boş değilse
        {
            PostOrderRec(node.Sol); // Sol alt ağaca geçilir
            PostOrderRec(node.Sağ); // Sağ alt ağaca geçilir
            Console.Write(node.Veri + " "); // Son olarak kök (düğüm) yazdırılır
        }
    }
}

public class Program
{
    public static void Main()
    {
        Ağaç ağaç = new Ağaç(); // Yeni bir Ağaç nesnesi oluşturuyoruz

        Console.WriteLine("Ağaçta kaç eleman olmasını istersiniz?"); // Kullanıcıdan ağaç için eleman sayısı isteniyor
        int elemanSayisi;
        while (!int.TryParse(Console.ReadLine(), out elemanSayisi) || elemanSayisi <= 0) // Geçerli bir sayı alınması sağlanıyor
        {
            Console.WriteLine("Lütfen geçerli bir pozitif sayı girin."); // Hatalı giriş olursa kullanıcıyı uyarıyoruz
        }

        // Kullanıcıdan her bir elemanı alıp ağaca ekliyoruz
        for (int i = 0; i < elemanSayisi; i++)
        {
            Console.WriteLine($"{i + 1}. elemanı girin:"); // Kullanıcıya eleman girme isteği
            int eleman;
            while (!int.TryParse(Console.ReadLine(), out eleman)) // Kullanıcıdan geçerli bir sayı alıyoruz
            {
                Console.WriteLine("Lütfen geçerli bir sayı girin."); // Hatalı girişte kullanıcıya uyarı
            }
            ağaç.Ekle(eleman); // Kullanıcının girdiği elemanı ağaca ekliyoruz
        }

        // Pre-order gezintisini başlatıyoruz
        Console.WriteLine("\nPre-order gezintisi:");
        ağaç.PreOrder(); // Pre-order gezintisi yapılır
        Console.WriteLine(); // Satır sonu ekliyoruz

        // In-order gezintisini başlatıyoruz
        Console.WriteLine("In-order gezintisi:");
        ağaç.InOrder(); // In-order gezintisi yapılır
        Console.WriteLine(); // Satır sonu ekliyoruz

        // Post-order gezintisini başlatıyoruz
        Console.WriteLine("Post-order gezintisi:");
        ağaç.PostOrder(); // Post-order gezintisi yapılır
        Console.WriteLine(); // Satır sonu ekliyoruz
    }
}

