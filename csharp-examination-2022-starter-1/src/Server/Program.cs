using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Persistence;
using Services.Members;
using Shared.Members;

var builder = WebApplication.CreateBuilder(args);

// Swagger | OAS 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.CustomSchemaIds(x => $"{x.DeclaringType?.Name}.{x.Name}");
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Examination API", Version = "v1" });
});

// Database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlDatabase"));
    options.EnableDetailedErrors();
    options.EnableSensitiveDataLogging();
});

// Services
builder.Services.AddScoped<IMemberService, MemberService>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// TODO: Vraag 6 Create, validator service toevoegen
// builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<MemberRequest.Create.Validator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseWebAssemblyDebugging();
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");


using (var scope = app.Services.CreateScope())
{ // Require a DbContext from the service provider and seed the database.
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.EnsureDeleted();
    dbContext.Database.EnsureCreated();
    Seeder seeder = new(dbContext);
    seeder.Seed();
}

app.Run();