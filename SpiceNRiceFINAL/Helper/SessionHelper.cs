using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;

namespace SpiceNRice.Helper
{
    public static class SessionHelper
    {
        public static void SetObjectasJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value=session.GetString(key);
            return value == null ? default : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
