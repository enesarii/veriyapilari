using System;

// Çift yönlü dairesel bağlı listenin düğüm yapısı
class Node // Her bir düğümü temsil eder
{
    public int Data; // Düğümün tuttuğu veri
    public Node Next; // Sonraki düğüme işaretçi
    public Node Prev; // Önceki düğüme işaretçi

    public Node(int data)
    {
        Data = data;
        Next = null; //başlangıçta bağlı değiller
        Prev = null;
    }
}

// Çift yönlü dairesel bağlı liste sınıfı
class ÇiftYönlüDaireselBağlıListe
{
    private Node head; // Listenin başlangıç düğümü
    //head değişmezse her zaman listenin ilk elemanını gösterir
    // Listeye yeni bir düğüm ekleyen metod
    public void Add(int data)
    {
        Node newNode = new Node(data); //yeni düğüm oluşturur 
        if (head == null) //eğer liste boşsa
        {
            head = newNode;
            head.Next = head; //aynı şeyi gösterir 
            head.Prev = head; //aynı şeyi gösterir 
        }
        else // boş değil yeni düğüm eklenmişse 
        {
            Node last = head.Prev;  //son düğümü bul
            last.Next = newNode; // newNode'ye bağla 
            newNode.Prev = last; // son düğüm artık yeni düğümü gösteriyor.
            newNode.Next = head; // yeni düğümün sonraki elemanı listeniin başı
            head.Prev = newNode; //head'ı güncelle
        }
    }

    // Belirtilen indisteki düğümü listeden silen metod
    public void DeleteAtIndex(int index)
    {
        if (head == null || index < 0) return; // Eğer liste boşsa veya geçersiz indeksse, işlemi sonlandır

        Node current = head; // current şuanki düğümü takip eder
        int count = 0; // count , mevcut düğümün indeksini tutması için

        // İstenen indekse kadar ilerle
        do //Dairesel listeyi döngüyle tarıyoruz.
        {
            if (count == index)  //silinecek düğüme ulaşmak için
            {
                if (current == head && current.Next == head)
                {
                    // Listede tek eleman varsa listeyi boşalt
                    head = null;
                }
                else if (current == head)
                {
                    // Eğer silinecek düğüm baş düğümse (head) ise 
                    Node last = head.Prev; // Son düğümü bul
                    head = head.Next; // Başlığı bir sonraki düğüme kaydır
                    head.Prev = last; // Yeni başın önceki düğümü güncelle
                    last.Next = head; // Son düğümün yeni başı işaret etmesini sağla // sayıyı sildikten sonraki düzen için gerekli kodlar
                }
                else
                {
                    // Orta veya son düğümse
                    current.Prev.Next = current.Next; // Önceki düğümün Next bağlantısı, şu anki düğümün sonrasına bağlanır.
                    current.Next.Prev = current.Prev; // Sonraki düğümün Prev bağlantısı, şu anki düğümün öncesine bağlanır.
                }
                return;
            }
            current = current.Next; //belirtilen indeksteki düğümü bulana kadar
            count++; // tarama yapılır
        } while (current != head); // Dairesel liste olduğu için başa dönene kadar devam et
    }

    // Listenin elemanlarını ekrana yazdıran metod
    public void Display()
    {
        if (head == null) // boş liste kontrolü 
        {
            Console.WriteLine("Liste boş!");
            return;
        }
        // Liste boş değilse, ilk elemandan başlamak üzere yazdırma işlemi yapılacak.
        Node temp = head; // elemanların sırasını takip etmek için
        int index = 0;
        do
        {
            Console.Write("[" + index + "] " + temp.Data + " <-> "); // Her bir elemanı [index] Data <-> şeklinde ekrana yazdırır.

            temp = temp.Next; //temp bir sonraki elemana yönlendirilir 
            index++; // bir sonraki eleman için index arttırılır.
        } while (temp != head); // başa döner
        Console.WriteLine("(Başa Dön)");
    }
}

// Programın çalışmasını sağlayan ana sınıf
class Program
{
    static void Main()
    {
        ÇiftYönlüDaireselBağlıListe list = new ÇiftYönlüDaireselBağlıListe();

        Console.Write("Kaç eleman eklemek istiyorsunuz? ");
        int n = int.Parse(Console.ReadLine()); // veri alıyoruz 

        for (int i = 0; i < n; i++) // kullanıcıdan belirtilen sayı kadar veri alıyoruz 
        {
            Console.Write("Eleman girin: ");
            int value = int.Parse(Console.ReadLine());
            list.Add(value); //elemanı listeye ekliyoruz 
        }

        Console.WriteLine("Başlangıç Listesi:"); //ekrana yazdırıyoruz 
        list.Display();

        Console.Write("Silmek istediğiniz elemanın indeksini girin: ");
        int deleteIndex = int.Parse(Console.ReadLine()); //silmek istediğimiz indeksi alıp siliyoruz

        list.DeleteAtIndex(deleteIndex); //siliiyor

        Console.WriteLine("Güncellenmiş Liste:"); // son liste
        list.Display();
    }
}

