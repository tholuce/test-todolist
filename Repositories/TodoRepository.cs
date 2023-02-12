using todolist.Models;

namespace todolist.Repositories;

public class TodoRepository : IRepository<TodoItem>
{
    public void Create(TodoItem entity)
    {
        using var context = new TodoContext();
        context.Todos.Add(entity);
        context.SaveChanges();
    }

    public void Delete(int id)
    {
        using var context = new TodoContext();
        var item = context.Todos.Where(el => el.Id == id).FirstOrDefault();
        if (item == null) 
        {
            return;
        }
        context.Todos.Remove(item);
        context.SaveChanges();
    }

    public void Update(TodoItem entity)
    {
        using var context = new TodoContext();
        context.Update(entity);
        context.SaveChanges();
    }

    public bool Exists(TodoItem? entity)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TodoItem> GetAll(int OwnerId)
    {
        using var context = new TodoContext();
        return context.Todos.Where(el => el.OwnerId == OwnerId).ToList();
    }

    public TodoItem? Get(Func<TodoItem, bool> func)
    {
        using var context = new TodoContext();
        return context.Todos.FirstOrDefault(func);
    }
}