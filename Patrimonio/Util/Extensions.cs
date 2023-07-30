using System;
using System.Windows.Controls;

namespace Patrimonio.Util
{
    public static class Extensions
    {
        public static bool isEmpty(this Guid value) => value.Equals(Guid.Empty);

        public static void setExceptionMessage(this Label value, Exception ex) => value.Content = ex.Message;
    }
}
