using Microsoft.AspNetCore.SignalR;
using SemanticTodo.Server.Hubs;
using SemanticTodo.Server.Models;

namespace SemanticTodo.Server.Services
{
    /// <summary>
    /// Simple service for managing todos
    /// Please be aware that this is for demonstrational purposes only and does not follow any best practices
    /// </summary>
    public class TodoService
    {
        private List<Category> _categories = new List<Category>()
        {
            new Category()
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                Todo = new List<Todo>()
                {
                    new Todo()
                    {
                        Id = Guid.NewGuid(),
                        Title = "Test 1",
                        Done = true
                    },
                    new Todo()
                    {
                        Id= Guid.NewGuid(),
                        Title = "Test 2",
                        Done = false
                    }
                }
            }
        };

        public List<Category> GetCategories() => _categories;

        public void AddCategory(string name)
        {
            _categories.Add(new Category() { Id = Guid.NewGuid(), Name = name });
        }

        public void UpdateCategory(Guid id, string name)
        {
            var category = _categories.FirstOrDefault(x => x.Id == id);

            if (category == null)
            {
                throw new InvalidOperationException("Category not found");
            }

            category.Name = name;
        }

        public void RemoveCategory(Guid id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);

            if(category == null)
            {
                throw new InvalidOperationException("Category not found");
            }

            if(category.Todo.Where(t => !t.Done).Count() > 0)
            {
                throw new InvalidOperationException("Category cannot be deleted if it has any open todos");
            }

            _categories.Remove(category);
        }

        public void AddTodo(Guid categoryId, string title)
        {
            var category = _categories.FirstOrDefault(c => c.Id == categoryId);

            if (category == null)
            {
                throw new InvalidOperationException("Category not found");
            }

            category.Todo.Add(new Todo() { Title = title });
        }

        public void UpdateTodo(Guid id,  string title)
        {
            var todo = _categories.SelectMany(x => x.Todo).FirstOrDefault(x => x.Id == id);

            if(todo == null)
            {
                throw new InvalidOperationException("Todo not found");
            }

            todo.Title = title;
        }

        public void CheckTodo(Guid id, bool done)
        {
            var todo = _categories.SelectMany(x => x.Todo).FirstOrDefault(x => x.Id == id);

            if (todo == null)
            {
                throw new InvalidOperationException("Todo not found");
            }

            todo.Done = done;
        }

        public void DeleteTodo(Guid id)
        {
            var category = _categories.FirstOrDefault(c => c.Todo.Any(t => t.Id == id));

            if (category == null)
            {
                throw new InvalidOperationException("Category not found");
            }

            var todo = _categories.SelectMany(x => x.Todo).FirstOrDefault(x => x.Id == id);

            if (todo == null)
            {
                throw new InvalidOperationException("Todo not found");
            }

            category.Todo.Remove(todo);
        }
    }
}
