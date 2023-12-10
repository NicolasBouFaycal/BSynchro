using BSynchro.API.Middlewares;
using BSynchro.Application.Abstraction;
using BSynchro.Application.Account.Command;
using BSynchro.Application.Customer.Query;
using BSynchro.Application.CustomModels;
using BSynchro.Application.Services;
using BSynchro.Persistence;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddTransient<IRequestHandler<OpenAccountCommand, string>, OpenAccountHandler>();
builder.Services.AddTransient<IRequestHandler<UserInfoQuery, UserInfoResponse>, UserInfoHandler>();
builder.Services.AddTransient<IAccountsHelper, AccountsService>();
builder.Services.AddTransient<ITransactionsHelper, TransactionsService>();
builder.Services.AddTransient<ICustomerHelper, CustomerService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<CheckRequestMiddleWare>();

app.UseAuthorization();
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));
app.MapControllers();

app.Run();
