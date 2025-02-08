using QuizYnovRendu.Dto;
using QuizYnovRendu.Models;
using AutoMapper;
using static QuizYnovRendu.Dto.QuizDto;
using static QuizYnovRendu.Dtos.AnswerDto;
using static QuizYnovRendu.Dtos.QuestionDto;
using static QuizYnovRendu.Dtos.UserDto;
namespace QuizYnovRendu.Mappers
{
    public class Mapper : Profile
    {
        public Mapper() 
        {
            // User
            CreateMap<UserModel, UserReadDto>();
            CreateMap<UserCreateDto, UserModel>();
            CreateMap<UserUpdateDto, UserModel>();

            // Quiz
            CreateMap<QuizModel, QuizReadDto>();
            CreateMap<QuizCreateDto, QuizModel>();
            CreateMap<QuizUpdateDto, QuizModel>();

            // Question
            CreateMap<QuestionModel, QuestionReadDto>();
            CreateMap<QuestionCreateDto, QuestionModel>();
            CreateMap<QuestionUpdateDto, QuestionModel>();

            // Answer
            CreateMap<AnswerModel, AnswerReadDto>();
            CreateMap<AnswerCreateDto, AnswerModel>();
            CreateMap<AnswerUpdateDto, AnswerModel>();
        }

    }
}
