using System.ComponentModel.DataAnnotations.Schema;

namespace todolist.Models;

public class User 
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Email { get; set; }

    public string Password { get; set; }

    public IEnumerable<TodoItem> Items { get; set; }
}