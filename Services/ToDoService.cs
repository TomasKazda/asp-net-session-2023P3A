using SessionServiceToDo.Model;

namespace SessionServiceToDo.Services
{
    public class ToDoService
    {
        private const string KEY = "234TGDB746";
        private readonly SessionService<List<ToDo>> sessionService;
        private List<ToDo> toDoList;

        public ToDoService(SessionService<List<ToDo>> sessionService) {
            this.sessionService = sessionService;
            toDoList = sessionService.GetSession(KEY) ?? new List<ToDo>();
        }

        public IEnumerable<ToDo> GetAll() {
            return toDoList.AsEnumerable() ?? new List<ToDo>();
        }

        public void AddToDo(string name) { 
            toDoList.Add(new ToDo() { Id = Guid.NewGuid(), Name = name });
        }
    }
}
