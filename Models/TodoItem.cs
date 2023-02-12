using System.ComponentModel.DataAnnotations.Schema;

namespace todolist.Models;

public class TodoItem
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Text { get; set; }

    public bool isCompleted { get; set; }

    public User Owner { get; set; }

    public int OwnerId { get; set; }
}