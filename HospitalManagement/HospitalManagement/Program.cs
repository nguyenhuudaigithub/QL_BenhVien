using Microsoft.EntityFrameworkCore;
using HospitalManagement.Data;
using HospitalManagement.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options 
    => options.AddDefaultPolicy(policy
        =>policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod())
    );

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IPhongKhamRepository, PhongKhamRepository>();
builder.Services.AddScoped<IDangKyKhamBenhRepository, DangKyKhamBenhRepository>();
builder.Services.AddScoped<IHoSoRepository, HoSoRepository>();
builder.Services.AddScoped<INgheNghiepRepository, NgheNghiepRepository>();
builder.Services.AddScoped<IDanTocRepository, DanTocRepository>();

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
