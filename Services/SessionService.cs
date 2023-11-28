using SessionServiceToDo.Helper;

namespace SessionServiceToDo.Services
{
    public class SessionService<T>
    {
        private ISession _session;

        public SessionService(IHttpContextAccessor hca) {
            _session = hca.HttpContext.Session;
        }

        public void SaveSession(string key, T value)
        {
            _session.SetData(key, value);
        }

        public T GetSession(string key) {
            T result = _session.GetData<T>(key);
            return result; //?? co když to T není class! ?? public static object? CreateInstance (Type type);
        }
    }
}
