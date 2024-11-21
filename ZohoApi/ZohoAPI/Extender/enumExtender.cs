using System.Reflection;
using System.Runtime.Serialization;

namespace ZohoApi.ZohoAPI.Extender
{
    public static class enumExtender
    {
        public static string? ToEnumMember(this Enum value) => value.GetType().GetField(value.ToString())?.GetCustomAttribute<EnumMemberAttribute>(false)?.Value;
    }
}
