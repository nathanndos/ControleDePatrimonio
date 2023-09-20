using System;
using System.Windows.Controls;

namespace Patrimonio.Util
{
    public static class Extensions
    {
        public static bool isEmpty(this Guid value) => value.Equals(Guid.Empty);
        public static bool isEmpty(this string value) => value?.Equals(string.Empty) ?? true;
        public static void setExceptionMessage(this Label value, Exception ex) => value.Content = ex.Message;
    }
}
