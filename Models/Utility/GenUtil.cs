
using System.Collections.Generic;
using System.Linq;

namespace Models
{
    public static class GenUtil
    {
        public static bool IsGreaterThanZero(this int i)
        {
            if(i <= 0)
            {
                return false;
            }
            return true;
        }

        public static bool AnyOrNotNull<T>(this IEnumerable<T> source)
        {
            if (source != null && source.Any())
                return true;
            else
                return false;
        }
    }
    public class ActionStatus
    {
        public int Status { get; set; }

        public string Message { get; set; }
    }

    public class Notify
    {
        public static void SendEMail()
        { }
    }

}
