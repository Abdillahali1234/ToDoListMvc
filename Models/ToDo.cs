namespace ToDoList.Models
{
    public class ToDo
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;
        public int UserId { get; set; }

        public User User { get; set; }


    }
}
