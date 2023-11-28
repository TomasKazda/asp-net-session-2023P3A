using SessionServiceToDo.Model;

namespace SessionServiceToDo.Services
{
    public class ToDoService
    {
        private const string KEY = "234TGDB746";
        private readonly SessionService sessionService;
        private List<ToDo> toDoList;

        public ToDoService(SessionService sessionService) {
            this.sessionService = sessionService;
            toDoList = sessionService.GetSession<List<ToDo>>(KEY);
        }

        public IEnumerable<ToDo> GetAll() {
            return toDoList.AsEnumerable();
        }

        public void AddToDo(string name) { 
            toDoList.Add(new ToDo() { Id = Guid.NewGuid(), Name = name });
            sessionService.SaveSession<List<ToDo>>(KEY, toDoList);
        }
    }
}
