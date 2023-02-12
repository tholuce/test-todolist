using Microsoft.EntityFrameworkCore;

namespace todolist.Models;

public class TodoContext: DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to postgres with connection string from app settings
        options.UseNpgsql("Host=localhost; Database=tododb; Username=postgres; Password=fifa10");
    }

    public DbSet<User> Users { get; set; }
    public DbSet<TodoItem> Todos{ get; set; }
}