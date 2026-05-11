using EscapeRoom.Core;

namespace EscapeRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            // Oyun motorunu oluştur ve başlat!
            GameEngine engine = new GameEngine();
            engine.Start();
        }
    }
}
