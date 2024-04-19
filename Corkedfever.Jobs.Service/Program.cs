using Corkedfever.Jobs.Business;
using Corkedfever.Jobs.Data;
using Corkedfever.Common.Data;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<IJobService, JobService>();
builder.Services.AddSingleton<IJobRepository, JobRepository>();
builder.Services.AddDbContextFactory<CorkedFeverDataContext>(options =>
{
    if(builder.Environment.IsDevelopment())
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DevelopmentConnection"), b => b.MigrationsAssembly("Corkedfever.Jobs.Service"));
    }
    else
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("ContainerConnection"), b => b.MigrationsAssembly("Corkedfever.Jobs.Service"));
    }
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.MapControllers();

app.Run();
