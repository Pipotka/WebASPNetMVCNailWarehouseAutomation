using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace WebNailWarehouseAutomation.Helpers
{
    static class EnumHelper
    {
        public static string DisplayName(this Enum value)
        {
            Type enumType = value.GetType();
            var enumValue = Enum.GetName(enumType, value);
            MemberInfo member = enumType.GetMember(enumValue)[0];

            var attrs = member.GetCustomAttributes(typeof(DisplayAttribute), false);
            var outString = ((DisplayAttribute)attrs[0]).Name;

            if (((DisplayAttribute)attrs[0]).ResourceType != null)
            {
                outString = ((DisplayAttribute)attrs[0]).GetName();
            }

            return outString;
        }

        public static Array DisplayNames(Type type)
        {
            Type soursType = type;
            int dispalyNamesCount = 0;
            foreach (PropertyInfo property in soursType.GetProperties())
            {
                dispalyNamesCount++;
            }
            string [] dispalyNames = new string[dispalyNamesCount];
            int i = 0;
            foreach (PropertyInfo property in soursType.GetProperties())
            {
                foreach (DisplayAttribute attr in property.GetCustomAttributes(typeof(DisplayAttribute)))
                {
                    if (attr.GetName() is not null)
                    {
                        dispalyNames[i] = attr.GetName();
                        i++;
                    }
                }
            }
            return dispalyNames;
        }
    }
}
