using HospitalManagement.Data;
using HospitalManagement.Helpers;
using HospitalManagement.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpClient();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();

builder.Services.AddCors(options
    => options.AddDefaultPolicy(policy
        => policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod())
    );

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddIdentityApiEndpoints<NguoiDung>().AddRoles<IdentityRole>().AddEntityFrameworkStores<DataContext>();
builder.Services.AddIdentityCore<NguoiDung>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.Password.RequireDigit = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 0;

    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings.
    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<DataContext>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireBacSi", policy => policy.RequireRole("BacSi"));
    options.AddPolicy("RequireDuocSi", policy => policy.RequireRole("DuocSi"));
    options.AddPolicy("RequireYTa", policy => policy.RequireRole("YTa"));
    options.AddPolicy("RequireBacSiOrYTa", policy => policy.RequireRole("BacSi", "YTa"));
});

builder.Services.AddScoped<IPhongKhamRepository, PhongKhamRepository>();
builder.Services.AddScoped<IDangKyKhamBenhRepository, DangKyKhamBenhRepository>();
builder.Services.AddScoped<IHoSoRepository, HoSoRepository>();
builder.Services.AddScoped<IQuocTichRepository, QuocTichRepository>();
builder.Services.AddScoped<INgheNghiepRepository, NgheNghiepRepository>();
builder.Services.AddScoped<IDanTocRepository, DanTocRepository>();
builder.Services.AddScoped<IDatLichRepository, DatLichRepository>();
builder.Services.AddScoped<IThuocRepository, ThuocRepository>();
builder.Services.AddScoped<INguoiDungRepository, NguoiDungRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        await SeedRoles.InitializeAsync(services);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapIdentityApi<NguoiDung>();

app.MapControllers();

app.Run();
