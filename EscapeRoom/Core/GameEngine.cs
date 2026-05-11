using System;
using System.Collections.Generic;
using EscapeRoom.Models;
using EscapeRoom.Exceptions;

namespace EscapeRoom.Core
{
    public class GameEngine
    {
        public void Start()
        {
            Console.Title = "Protokol: Karantina İhlali v1.0";

            // --- HİKAYE GİRİŞİ (YENİ EKLENEN KISIM) ---
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("=========================================================");
            Console.WriteLine("   [SİSTEM UYARISI]: KARANTİNA PROTOKOLÜ DEVREDE!        ");
            Console.WriteLine("=========================================================\n");
            Console.ResetColor();

            Console.WriteLine("Gece geç saatte projeyi yetiştirmeye çalışırken yanlışlıkla");
            Console.WriteLine("eski sistem odasında kilitli kaldın. Ana çelik kapı mühürlendi.");
            Console.WriteLine("İçeride oksijen seviyesi hızla düşüyor...\n");

            Console.WriteLine("Tek umudun, dışarıda olan ve elinde yıpranmış bir ");
            Console.WriteLine("'Sistem Yöneticisi El Kitabı' bulunan ekip arkadaşın.");
            Console.WriteLine("Onunla iletişim kurarak 4 güvenlik duvarını aşmalısın.\n");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Hayatta kalmak ve sistemleri açmak için hazırsan [ENTER] tuşuna bas...");
            Console.ResetColor();
            Console.ReadLine(); // Kullanıcının Enter'a basmasını bekler
            // -----------------------------------------

            // Tüm bulmacaları bir Listeye ekliyoruz
            List<InteractableItem> gameFlow = new List<InteractableItem>
            {
                new ValvePuzzle(),
                new CryptoLock(),
                new Labyrinth(),
                new MainDoor("Final Kapısı", "Sistemi çökertmeden çıkamazsınız.")
            };

            foreach (var step in gameFlow)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"=== GÖREV: {step.Name.ToUpper()} ===");
                Console.ResetColor();
                Console.WriteLine($"Açıklama: {step.Description}\n");

                while (step.IsLocked)
                {
                    try
                    {
                        step.Interact();
                    }
                    catch (SystemOverloadException ex)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Clear();
                        Console.WriteLine($"\n!!! {ex.Message} !!!");
                        Console.ResetColor();
                        Console.WriteLine("\n[SİSTEM ÇÖKTÜ] ACİL DURUM PANELİ AKTİF. Şifre: ROOT");
                    }
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nSonraki aşamaya geçmek için [ENTER] tuşuna basın...");
                Console.ResetColor();
                Console.ReadLine();
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("**************************************************");
            Console.WriteLine("* TEBRİKLER! TÜM PROTOKOLLER TAMAMLANDI.         *");
            Console.WriteLine("* KARANTİNA BÖLGESİNDEN ÇIKTINIZ.                *");
            Console.WriteLine("**************************************************");
            Console.ReadLine(); // Oyunun hemen kapanmaması için eklendi
        }
    }
}