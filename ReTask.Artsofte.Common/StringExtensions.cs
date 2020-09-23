using System;

namespace ReTask.Artsofte.Common
{
    public static class StringExtensions
    {
        public static T GetEnumValue<T>(this string stringValue) where T : struct
        {
            var type = typeof(T);
            if (!type.IsEnum)
                throw new ArgumentException($"{stringValue} must be of Enum type", "enumerationValue");



            throw new NotImplementedException();
        }
    }
}
