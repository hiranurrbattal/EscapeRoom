using System;

namespace EscapeRoom.Models
{
    // --- BULMACA 1: SOĞUTMA VALFLERİ ---
    public class ValvePuzzle : InteractableItem
    {
        private readonly int _target = 120;

        public ValvePuzzle() : base("Soğutma Valfleri", "KRİTİK: Basınç dengelenmeli. Manuel giriş bekleniyor...", true)
        {
        }

        public override void Interact()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\n[SİSTEM DURUMU] Toplam Basınç: {_target} PSI olmalı.");
            Console.ResetColor();

            try
            {
                Console.Write("Alfa Valfi: ");
                int a = int.Parse(Console.ReadLine());
                Console.Write("Beta Valfi: ");
                int b = int.Parse(Console.ReadLine());
                Console.Write("Gama Valfi: ");
                int g = int.Parse(Console.ReadLine());

                if (a == b * 2 && g == (a - b) && (a + b + g) == _target)
                {
                    IsLocked = false;
                    Console.WriteLine(">> DURUM: Basınç dengelendi. Enerji aktarılıyor.");
                }
                else
                {
                    Console.WriteLine(">> HATA: Basınç değerleri uyumsuz! Valfler kilitlendi.");
                }
            }
            catch
            {
                Console.WriteLine(">> GEÇERSİZ VERİ: Sadece sayısal değer girin.");
            }
        }
    }

    // --- BULMACA 2: KRİPTO TERMİNALİ ---
    public class CryptoLock : InteractableItem
    {
        public CryptoLock() : base("Kripto Terminali", "VERİ HATASI: Kod çözücü (Decoder) gerekiyor...", true)
        {
        }

        public override void Interact()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n[BİLİNMEYEN DİZİ] 'F - L - Ş'");
            Console.ResetColor();

            Console.Write("Deşifre Girişi: ");
            if (Console.ReadLine().ToUpper() == "ÇİP")
            {
                IsLocked = false;
                Console.WriteLine(">> DURUM: Veri yolu açıldı.");
            }
            else
            {
                Console.WriteLine(">> ERİŞİM REDDEDİLDİ: Algoritma hatası.");
            }
        }
    }

    // --- BULMACA 3: KÖR LABİRENT ---
    public class Labyrinth : InteractableItem
    {
        private string _path = "KUZEY,DOĞU,KUZEY";

        public Labyrinth() : base("Karanlık Koridor", "UYARI: Görünmez lazerler aktif. Güvenli rota girilmeli.", true)
        {
        }

        public override void Interact()
        {
            Console.WriteLine("\n[NAVİGASYON] Rota dizisini girin (YÖN,YÖN,YÖN):");
            string input = Console.ReadLine().ToUpper();
            if (input == _path)
            {
                IsLocked = false;
                Console.WriteLine(">> DURUM: Güvenli bölgeye ulaşıldı.");
            }
            else
            {
                Console.WriteLine(">> ALARM: Lazerler tetiklendi! Koridor mühürlendi.");
            }
        }
    }
}