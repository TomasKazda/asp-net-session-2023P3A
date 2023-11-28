namespace SessionServiceToDo.Model
{
    public class ToDo
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ËndDate { get; set; }
        public bool Success { get; set; }
    }
}
