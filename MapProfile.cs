using AutoMapper;
using todolist.Requests;
using todolist.Models;

public class CustomProfile: Profile
{
    public CustomProfile()
    {
        CreateMap<SignUpRequest, User>();
        CreateMap<SignInRequest, User>();
        CreateMap<TodoItemRequest, TodoItem>();
    }
}