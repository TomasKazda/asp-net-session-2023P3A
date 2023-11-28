using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SessionServiceToDo.Model;
using SessionServiceToDo.Services;
using System.ComponentModel.DataAnnotations;

namespace SessionServiceToDo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ToDoService toDoService;
        public IEnumerable<ToDo> ToDoList { get; set; }

        [Required(ErrorMessage = "Je třeba vložit text úkolu...")]
        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }

        public IndexModel(ToDoService toDoService)
        {
            this.toDoService = toDoService;
            ToDoList = toDoService.GetAll() ?? new List<ToDo>();
        }

        public void OnGetAdd()
        {
            if (ModelState.IsValid)
            {
                ToDoList = toDoService.GetAll() ?? new List<ToDo>();
                toDoService.AddToDo(Name);
            }
        }

        public void OnGet() { 
            
        }
    }
}