using APISchool.Helpers;
using APISchool.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var service = builder.Services;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

service.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("MyDB")));

service.AddScoped<IKhoaService, KhoaService>();
service.AddScoped<ILopService, LopService>();
service.AddScoped<IMonService, MonService>();
service.AddScoped<IDiemService, DiemService>();
service.AddScoped<ISinhVienService, SinhVienService>();

var app = builder.Build();

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
