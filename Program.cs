using Microsoft.EntityFrameworkCore;
using QuizYnov.Data;
using QuizYnovRendu.Interfaces;
using QuizYnovRendu.Mappers;
using QuizYnovRendu.Repositories;
using QuizYnovRendu.Services;
using static QuizYnovRendu.Dto.QuizDto;
using static QuizYnovRendu.Dtos.AnswerDto;
using static QuizYnovRendu.Dtos.QuestionDto;
using static QuizYnovRendu.Dtos.UserDto;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<Mapper>();
builder.Services.AddScoped<IUserRepository<UserReadDto, UserCreateDto, UserUpdateDto>, UserService>();
builder.Services.AddScoped<IQuizRepository<QuizReadDto, QuizCreateDto, QuizUpdateDto>, QuizService>();
builder.Services.AddScoped<IQuestionRepository<QuestionReadDto, QuestionCreateDto, QuestionUpdateDto>, QuestionService>();
builder.Services.AddScoped<IAnswerRepository<AnswerReadDto, AnswerCreateDto, AnswerUpdateDto>, AnswerService>();

builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 35))
    )
);
builder.Services.AddAutoMapper(typeof(Mapper).Assembly);


/* builder.Services.AddAuthentication(Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "your-issuer",
            ValidAudience = "your-audience",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("123456"))
        };
    });
*/

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseRouting();

app.UseCors(x=> x.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowCredentials());

app.MapControllers();

app.Run();
