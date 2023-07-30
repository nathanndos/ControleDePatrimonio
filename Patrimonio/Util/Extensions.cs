using System;

namespace Patrimonio.Util
{
    public static class Extensions
    {
        public static bool isEmpty(this Guid value) => value.Equals(Guid.Empty);
    }
}
