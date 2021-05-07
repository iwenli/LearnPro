#if SQLiteVersion
using System;

namespace EFCore.Web.Core
{
    public static class Utility
    {
        public static string GetLastChars(Guid token)
        {
            return token.ToString()[^3..];
        }
    }
}
#else
namespace EFCore.Web.Core
{
    public static class Utility
    {
        public static string GetLastChars(byte[] token)
        {
            return token[7].ToString();
        }
    }
}
#endif