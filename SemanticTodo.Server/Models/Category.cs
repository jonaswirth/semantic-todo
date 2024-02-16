namespace SemanticTodo.Server.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Todo> Todo { get; set; } = new List<Todo> { };
    }
}
