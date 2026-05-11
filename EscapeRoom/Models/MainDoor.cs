using EscapeRoom.Exceptions; // Yazdığımız özel hataları kullanabilmek için ekliyoruz
using System;
using System.Xml.Linq;

namespace EscapeRoom.Models
{
    // InteractableItem sınıfından miras alıyoruz
    public class MainDoor : InteractableItem
    {
        private int _failedAttempts = 0;

        public MainDoor(string name, string description) : base(name, description, true)
        {
        }

        // Çok biçimlilik: Interact metodunu Ana Kapı'ya özel eziyoruz (Override)
        public override void Interact()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n[{Name.ToUpper()}] Sistem Manuel Doğrulama İstiyor.");
            Console.ResetColor();

            Console.Write("Geçersiz Kılma (Override) Şifresi: ");
            string input = Console.ReadLine().ToUpper();

            // Şifre ROOT değilse hata sayacını artır
            if (input != "ROOT")
            {
                _failedAttempts++;
                if (_failedAttempts >= 3)
                {
                    // İŞTE ŞOV KISMI: 3. hatada kendi Exception'ımızı fırlatıyoruz!
                    throw new SystemOverloadException("KRİTİK HATA: SİSTEM AŞIRI YÜKLENDİ! GÜVENLİK PROTOKOLÜ ÇÖKTÜ!");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Yanlış Şifre! Kalan Hak: {3 - _failedAttempts}");
                    Console.ResetColor();
                }
            }
            else
            {
                IsLocked = false; // Şifre doğruysa kilidi aç
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nERİŞİM ONAYLANDI: Ağır çelik kapı mekanizması açılıyor...");
                Console.ResetColor();
            }
        }
    }
}