using System;
using System.Windows.Controls;

namespace Patrimonio.Util
{
    public static class Extensions
    {
        public static bool isEmpty(this Guid value) => value.Equals(Guid.Empty);
        public static bool isEmpty(this string value) => value?.Equals(string.Empty) ?? true;
        public static bool isNotEmpty(this string value) => !value.isEmpty();
        public static bool isApagado(this int value) => value.Equals(-1);
        public static bool isNotApagado(this int value) => !value.isApagado();
        public static string getString(this TextBox value) => value.Text?.Trim() ?? string.Empty;
        public static void setExceptionMessage(this Label value, Exception ex) => value.Content = ex.Message;
        public static void resetContet(this Label value) => value.Content = string.Empty;
    }
}
