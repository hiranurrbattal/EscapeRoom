using System;

namespace EscapeRoom.Exceptions
{
    // Temel Exception sınıfından miras alıyoruz (Inheritance şovu!)
    public class SecurityLockdownException : Exception
    {
        // Constructor (Yapıcı Metot) - Hatayı fırlatırken ekrana yazdıracağımız mesajı alıyor
        public SecurityLockdownException(string message) : base(message)
        {
        }
    }
}
