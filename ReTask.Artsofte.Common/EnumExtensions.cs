using ReTask.Artsofte.Common.Attributes;
using System;

namespace ReTask.Artsofte.Common
{
    public static class EnumExtensions
    {
        public static string GetStringValue<T>(this T enumValue) where T : struct
        {
            var type = typeof(T);
            if (!type.IsEnum)
                throw new ArgumentException($"{enumValue} must be of Enum type", "enumerationValue");

            var memberInfo = type.GetMember(enumValue.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] attrs = memberInfo[0].GetCustomAttributes(typeof(StringValueAttribute), false);

                if (attrs != null && attrs.Length > 0)
                    return ((StringValueAttribute)attrs[0]).Value;
            }
            return enumValue.ToString();
        }
    }
}
