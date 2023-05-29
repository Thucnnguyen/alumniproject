using AlumniProject.Data;
using AlumniProject.Data.Repostitory;
using AlumniProject.Data.Repostitory.RepositoryImp;
using AlumniProject.Service;
using AlumniProject.Service.ServiceImp;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContextPool<AlumniDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("userDb"))
);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IAlumniService, AlumniService>();
builder.Services.AddScoped<ISchoolService, SchoolService>();
builder.Services.AddScoped<IGradeService, GradeService>();


builder.Services.AddScoped<IAlumniRepo, AlumniRepo>();
builder.Services.AddScoped<ISchoolRepo, SchoolRepo>();
builder.Services.AddScoped<IGradeRepo, GradeRepo>();


FirebaseApp.Create(new AppOptions()
{
    Credential = GoogleCredential.FromFile("firebase-config.json")
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
