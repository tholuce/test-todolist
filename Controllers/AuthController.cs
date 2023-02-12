using System;    
using System.IdentityModel.Tokens.Jwt;    
using System.Security.Claims;    
using System.Text;   
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;
using FluentValidation;
using todolist.Requests;
using todolist.Repositories;
using todolist.Models;

namespace todolist.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly ILogger<AuthController> _logger;
    private readonly IValidator<SignUpRequest> _signUpValidator;
    private readonly IValidator<SignInRequest> _signInValidator;
    private readonly IRepository<User> _userRepository;
    private readonly IMapper _mapper;

    public AuthController(ILogger<AuthController> logger, IValidator<SignUpRequest> signUpValidator, IValidator<SignInRequest> signInValidator, IRepository<User> userRepository, IMapper mapper)
    {
        _logger = logger;
        _signUpValidator = signUpValidator;
        _signInValidator = signInValidator;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    [HttpGet("me")]
    [Authorize]
    public IActionResult GetMe()
    {
        var user = GetCurrentUser();
        return Ok(user);
    }

    [HttpPost("login")]
    [AllowAnonymous]
    [Produces("application/json")]
    public IActionResult SignIn(SignInRequest signInRequest)
    {   
        var result = _signInValidator.Validate(signInRequest);
        if(!result.IsValid)
        {
            return new JsonResult(result.Errors.Select(el=> el.ErrorMessage));
        }

        User? user = _userRepository.Get(u => u.Email == signInRequest.Email && u.Password == signInRequest.Password);

        if (!_userRepository.Exists(user))
        {
            return Content("User not found");
        }

        string token = GenerateJSONWebToken(user);
        
        return Ok(new{token = token});
    }

    [HttpPost("register")]
    [Produces("application/json")]
    public IActionResult SignUp(SignUpRequest request)
    {
        var result = _signUpValidator.Validate(request);
        if(!result.IsValid)
        {
            return new JsonResult(result.Errors.Select(el=> el.ErrorMessage));
        }

        _userRepository.Create(_mapper.Map<User>(request));
        return Content("success");
    }

    private string GenerateJSONWebToken(User user)    
    {    
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authentication"));    
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);    
        
        var claims = new List<Claim> {    
            new Claim("idd", user.Id.ToString()), 
            new Claim("e-mail", user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())    
        };    
        
        var token = new JwtSecurityToken("Test.com",    
            "Test.com",    
            claims,    
            expires: DateTime.Now.AddMinutes(3600),    
            signingCredentials: credentials);    
        
        return new JwtSecurityTokenHandler().WriteToken(token);    
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
