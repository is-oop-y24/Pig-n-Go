using System;

namespace Pig_n_Go.BLL.Tools
{
    public static class ThrowIfNullExtension
    {
        public static T ThrowIfNull<T>(this T obj)
        {
            if (obj is null)
                throw new ArgumentNullException(nameof(obj));

            return obj;
        }
    }
}
