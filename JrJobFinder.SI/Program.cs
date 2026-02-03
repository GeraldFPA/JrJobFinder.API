using JrJobFinder.BL;
using JrJobFinder.DA;
using JrJobFinder.Models;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IJobOfferBL, JobOfferBL>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

//Recordar borrar esta sección una vez se haya probado la aplicación

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if (!context.JobOffers.Any())
    {
        context.JobOffers.Add(new JobOffer
        {
            Title = "Junior Software Developer",
            Company = "Tech Corp",
            technologies = "C#, .NET, SQL",
            experienceLevel = "Junior",
            Location = "Costa Rica",
            IsRemote = true,
            source = "LinkedIn",
            sourceUrl = "https://example.com/job",
            PostedDate = DateTime.UtcNow
        });

        context.SaveChanges();
    }
}//////////

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
