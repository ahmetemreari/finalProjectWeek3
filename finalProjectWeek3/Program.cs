using System;

internal class Program
{
    private static void Main(string[] args)
    {
        // Ana döngü: Kullanıcıdan hangi programı çalıştırmak istediğini sorar
        while (true)
        {
            // Kullanıcıya program seçeneklerini göster
            Console.WriteLine("Hangi programı çalıştırmak istersiniz?");
            Console.WriteLine("1 - Rastgele Sayı Bulma Oyunu");
            Console.WriteLine("2 - Hesap Makinesi");
            Console.WriteLine("3 - Ortalama Hesaplama");
            Console.WriteLine("4 - Çıkış");
            Console.Write("Seçiminiz: ");

            // Kullanıcıdan seçim al ve geçerli bir sayı olup olmadığını kontrol et
            if (int.TryParse(Console.ReadLine(), out int secim))
            {
                // Kullanıcının seçimine göre ilgili fonksiyonu çağır
                switch (secim)
                {
                    // Kullanıcının seçimine göre ilgili fonksiyonu çağır
                    case 1:
                        RastgeleSayiBulmaOyunu();
                        break;
                    case 2:
                        HesapMakinesi();
                        break;
                    case 3:
                        OrtalamaHesaplama();
                        break;
                    case 4:
                        return; // Programdan çık
                    default:
                        Console.WriteLine("Hatalı seçim yaptınız. Lütfen tekrar deneyiniz.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Geçersiz giriş. Lütfen bir sayı giriniz.");
            }
        }
    }

    // Rastgele Sayı Bulma Oyunu fonksiyonu
    private static void RastgeleSayiBulmaOyunu()
    {
        Random random = new Random();// Rastgele sayı oluşturmak için Random sınıfını kullandım
        int rastgeleSayi = random.Next(1, 101); // 1 ile 100 arasında rastgele bir sayı oluştur
        int canSayisi = 5; // Kullanıcının 5 tahmin hakkı var

        // Kullanıcı tahmin yaparken döngü devam eder
        while (canSayisi > 0)
        {
            // Kullanıcıdan tahmin al
            Console.Write("Lütfen bir sayı tahmin ediniz: ");
            if (int.TryParse(Console.ReadLine(), out int tahmin))
            {
                // Kullanıcının tahmini doğru mu kontrol et
                if (tahmin == rastgeleSayi)
                // Kullanıcının tahmini doğruysa tebrik mesajı ver ve döngüden çık
                {
                    Console.WriteLine("Tebrikler! Sayıyı doğru tahmin ettiniz.");
                    return;
                }
                else if (tahmin < rastgeleSayi)
                // Kullanıcının tahmini yanlışsa büyük veya küçük olduğunu söyle
                {
                    Console.WriteLine("Daha büyük bir sayı giriniz.");
                }
                else
                {
                    Console.WriteLine("Daha küçük bir sayı giriniz.");
                }
                canSayisi--; // Tahmin hakkını azalt
                Console.WriteLine($"Kalan tahmin hakkınız: {canSayisi}");
            }
            else
            {
                Console.WriteLine("Geçersiz giriş. Lütfen bir sayı giriniz.");
            }
        }
        // Kullanıcı tahmin hakkını bitirdiğinde doğru sayıyı göster
        Console.WriteLine($"Üzgünüm! Tahmin hakkınız bitti. Doğru sayı: {rastgeleSayi}");
    }
    //her bir bölüm için fonksiyon oluşturuldu.
    // Hesap Makinesi fonksiyonu
    private static void HesapMakinesi()
    {
        while (true)
        {
            Console.Write("İlk sayıyı giriniz: ");
            // Kullanıcıdan alınan sayı geçerli değilse hata mesajı ver
            if (double.TryParse(Console.ReadLine(), out double sayi1))
            {
                Console.Write("İkinci sayıyı giriniz: ");
                if (double.TryParse(Console.ReadLine(), out double sayi2))
                {
                    // Kullanıcıdan alınan sayılar geçerliyse işlem seçimini yap
                    Console.Write("Yapmak istediğiniz işlemi seçiniz (+, -, *, /): ");
                    string? islem = Console.ReadLine();
                    // Kullanıcının seçtiği işlem geçerli değilse hata mesajı ver
                    if (string.IsNullOrEmpty(islem))
                    {
                        Console.WriteLine("Geçersiz işlem seçimi.");
                        continue;
                    }
                    double sonuc = 0;
                    bool gecerliIslem = true;

                    // Kullanıcının seçtiği işleme göre hesaplama yap
                    switch (islem)
                    // Kullanıcının seçtiği işleme göre hesaplama yap
                    
                    {
                        case "+":
                            // Toplama işlemi
                            sonuc = sayi1 + sayi2;
                            break;
                        case "-":
                            // Çıkarma işlemi
                            sonuc = sayi1 - sayi2;
                            break;
                        case "*":
                            // Çarpma işlemi
                            sonuc = sayi1 * sayi2;
                            break;
                        case "/":
                            // Bölme işlemi
                            if (sayi2 != 0)
                            {
                                sonuc = sayi1 / sayi2;
                            }
                            else
                            // Eğer kullanıcı sıfıra bölme işlemi yapmaya çalışırsa hata mesajı ver
                            {
                                Console.WriteLine("Hata: Sıfıra bölme hatası.");
                                gecerliIslem = false;
                            }
                            break;
                        default:
                            // Kullanıcının seçtiği işlem geçerli değilse hata mesajı ver
                            Console.WriteLine("Geçersiz işlem seçimi.");
                            gecerliIslem = false;
                            break;
                    }

                    // Geçerli bir işlem yapıldıysa sonucu göster
                    if (gecerliIslem)
                    {
                        Console.WriteLine($"Sonuç: {sonuc}");
                    }
                }
                else
                // Kullanıcıdan alınan sayı geçerli değilse hata mesajı ver
                {
                    Console.WriteLine("Geçersiz giriş. Lütfen bir sayı giriniz.");
                }
            }
            else
            {
                // Kullanıcıdan alınan sayı geçerli değilse hata mesajı ver
                Console.WriteLine("Geçersiz giriş. Lütfen bir sayı giriniz.");
            }
            break;
        }
    }

    // Ortalama Hesaplama fonksiyonu
    private static void OrtalamaHesaplama()
    {
        // Kullanıcıdan 3 adet not al
        double[] notlar = new double[3];
        for (int i = 0; i < 3; i++)
        // Döngü ile notları al ve geçerli olup olmadığını kontrol ettir.
        {
            while (true)
            {

                
                Console.Write($"{i + 1}. ders notunu giriniz: ");
                // Kullanıcıdan notları al ve geçerli olup olmadığını kontrol ettir.
                if (double.TryParse(Console.ReadLine(), out notlar[i]) && notlar[i] >= 0 && notlar[i] <= 100)
                {
                    break;
                }
                // Notlar 0-100 aralığında olmalıdır. Yoksa hata mesajı ver.
                else
                {
                    Console.WriteLine("Geçersiz not girdiniz. Notlar 0-100 aralığında olmalıdır.");
                }
            }
        }

        // Notların ortalamasını hesapla
        // Ortalama hesaplanırken notlar dizisindeki elemanları topla ve 3'e böl
        double ortalama = (notlar[0] + notlar[1] + notlar[2]) / 3;
        // Ortalamayı ekrana yazdır ve harf notunu belirle
        Console.WriteLine($"Ortalama: {ortalama}");

        // Ortalamaya göre harf notunu belirle
        string harfNotu = ortalama switch
        {
            >= 90 => "AA",
            >= 85 => "BA",
            >= 80 => "BB",
            >= 75 => "CB",
            >= 70 => "CC",
            >= 65 => "DC",
            >= 60 => "DD",
            >= 55 => "FD",
            _ => "FF"
        };

        Console.WriteLine($"Harf Notu: {harfNotu}");
    }
}
