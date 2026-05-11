using System;

namespace EscapeRoom.Exceptions
{
    public class SystemOverloadException : Exception
    {
        public SystemOverloadException(string message) : base(message)
        {
        }
    }
}