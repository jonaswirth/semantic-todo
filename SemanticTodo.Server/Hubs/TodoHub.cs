using Microsoft.AspNetCore.SignalR;
using SemanticTodo.Server.Models;
using SemanticTodo.Server.Services;

namespace SemanticTodo.Server.Hubs
{
    public class TodoHub : Hub
    {
        public async Task UpdateTodos(string clientId, Category[] categories)
        {
            await Clients.Client(clientId).SendAsync("updateTodos", categories);
        }
    }
}
