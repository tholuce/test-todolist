using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using FluentValidation;
using todolist.Repositories;
using todolist.Models;
using todolist.Requests;

namespace todolist.Controllers;

[ApiController]
[Authorize]
[Route("/api/[controller]")]
public class TodoController: ControllerBase
{

    private readonly IRepository<TodoItem> _todoRepository;

    private readonly IMapper _mapper;
    
    public TodoController(IRepository<TodoItem> todoRepository, IMapper mapper)
    {
        _todoRepository = todoRepository;
        _mapper = mapper;
    }
    
    [HttpGet]
    public IActionResult GetTodoItems()
    {
        return Ok(_todoRepository.GetAll(GetCurrentUser().Id));
    }

    [HttpPost]
    public IActionResult AddTodoItem(TodoItemRequest request)
    {
        TodoItem todoItem = _mapper.Map<TodoItem>(request);
        todoItem.OwnerId = GetCurrentUser().Id;
        _todoRepository.Create(todoItem);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTodoItem([FromRoute]int id)
    {
        _todoRepository.Delete(id);
        return Ok();
    }

    [HttpPatch("{id}")]
    public IActionResult CompleteTodoItem([FromRoute]int id)
    {
        var todoItem = _todoRepository.Get(t => t.Id == id);
        if(todoItem == null)
        {
            return Ok();
        }
        todoItem.isCompleted = true;
        _todoRepository.Update(todoItem);
        return Ok();
    }

    private User GetCurrentUser()
    {
        var currentUser = HttpContext.User;
        string email = currentUser.Claims.FirstOrDefault(el => el.Type == "e-mail")?.Value ?? string.Empty;
        string idd = currentUser.Claims.FirstOrDefault(el => el.Type == "idd")?.Value ?? string.Empty;
        return new User{
            Email = email,
            Id = Convert.ToInt32(idd)
        };
    }
}