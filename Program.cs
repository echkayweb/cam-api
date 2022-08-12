global using cam_api.Models;
using cam_api.Data;
using cam_api.Services.AssetService;
using cam_api.Services.AssignedAssetService;
using cam_api.Services.EmployeeService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<IAssetService, AssetService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IAssignedAssetService, AssignedAssetService>();
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
    {
        builder.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader();
    }));
// builder.Services.AddCors(options =>
// {
//     options.AddDefaultPolicy(
//                           policy =>
//                           {
//                               policy.WithOrigins("http://localhost:3000")
//                                                   .AllowAnyHeader()
//                                                   .AllowAnyMethod()
//                                                   .SetIsOriginAllowed((origin) => true)
//                                                   .AllowCredentials();
//                           });
// });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corsapp");

// app.UseCors(options => options
//     .AllowAnyMethod()
//     .AllowAnyHeader()
//     .SetIsOriginAllowed(origin => true)
//     .AllowCredentials()
// );
// app.UseHttpsRedirection();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(app.Environment.ContentRootPath, "Images")),
    RequestPath = "/Images"
});

app.UseAuthorization();

app.MapControllers();

app.Run();
