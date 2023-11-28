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
            T result = default(T); //pro int = 0; pro string null, pro class = null ...
            var ses = session.GetString(key); //pokud je session prázdná, vrací null!
            if (ses != null) result = JsonSerializer.Deserialize<T>(ses);
            if (typeof(T).IsClass && result == null) result = (T)Activator.CreateInstance(typeof(T));
            return result;
        }
    }
}
