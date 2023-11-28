using SessionServiceToDo.Helper;

namespace SessionServiceToDo.Services
{
    public class SessionService
    {
        private ISession _session;

        public SessionService(IHttpContextAccessor hca) {
            _session = hca.HttpContext.Session;
        }

        public void SaveSession<T>(string key, T value)
        {
            _session.SetData(key, value);
        }

        public T GetSession<T>(string key) {
            T result = _session.GetData<T>(key);
            return result;
        }
    }
}
