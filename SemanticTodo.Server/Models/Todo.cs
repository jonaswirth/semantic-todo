﻿namespace SemanticTodo.Server.Models
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool Done { get; set; }
    }
}
