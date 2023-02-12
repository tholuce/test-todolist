using todolist.Models;

namespace todolist.Repositories;

public class UserRepository : IRepository<User>
{
    public void Create(User entity)
    {
        using var context = new TodoContext();
        context.Users.Add(entity);
        context.SaveChanges();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(User entity)
    {
        throw new NotImplementedException();
    }

    public bool Exists(User? entity)
    {
        if(entity == null) 
        {
            return false;
        }
        using var context = new TodoContext();
        return context.Users.Any(u => u.Email == entity.Email && u.Password == entity.Password);
    }

    public IEnumerable<User> GetAll(int id)
    {
        throw new NotImplementedException();
    }

    public User? Get(Func<User, bool> func)
    {
        using var context = new TodoContext();
        return context.Users.FirstOrDefault(func);
    }
}