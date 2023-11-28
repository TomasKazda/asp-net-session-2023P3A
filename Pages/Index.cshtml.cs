using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SessionServiceToDo.Model;
using SessionServiceToDo.Services;

namespace SessionServiceToDo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ToDoService toDoService;
        public IEnumerable<ToDo> ToDoList { get; set; }

        public IndexModel(ToDoService toDoService)
        {
            this.toDoService = toDoService;
        }

        public void OnGetAdd()
        {
            ToDoList = toDoService.GetAll() ?? new List<ToDo>();
            toDoService.AddToDo("Abeceda");
        }

        public void OnGet() { 
            ToDoList = toDoService.GetAll() ?? new List<ToDo>();
        }
    }
}