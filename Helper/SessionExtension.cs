using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Text.Json;

namespace SessionServiceToDo.Helper
{
    public static class SessionExtension
    {
        public static void SetData<T>(this ISession session, string key, T value)
        {
            var serialized = JsonSerializer.Serialize<T>(value);
            session.SetString(key, serialized);
        }

        public static T GetData<T>(this ISession session, string key)
        {
            //session.Keys.FirstOrDefault(key) == default ? default : 
            var ses = session.GetString(key);
            return ses == null ? default : JsonSerializer.Deserialize<T>(ses);
        }
    }
}
