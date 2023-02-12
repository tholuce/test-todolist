using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using FluentValidation;
using todolist.Repositories;
using todolist.Validators;
using todolist.Requests;
using todolist.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IValidator<SignInRequest>, SignInValidator>();
builder.Services.AddScoped<IValidator<SignUpRequest>, SignUpValidator>();
builder.Services.AddScoped<IRepository<User>, UserRepository>();
builder.Services.AddScoped<IRepository<TodoItem>, TodoRepository>();

var myAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
                      policy  =>
                      {
                          policy.AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});

builder.Services.AddAutoMapper(typeof(Program)); 
builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters{
            ValidateIssuer = true,    
            ValidateAudience = true,    
            ValidateLifetime = true,    
            ValidateIssuerSigningKey = true,    
            ValidIssuer = "Test.com",    
            ValidAudience = "Test.com",    
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authentication"))
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseCors(myAllowSpecificOrigins);
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");;

app.UseSwagger();
app.UseSwaggerUI(config => {
    config.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo API");
    config.RoutePrefix = string.Empty;
});

app.Run();
