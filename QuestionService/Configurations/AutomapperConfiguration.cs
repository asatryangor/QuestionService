using AutoMapper;
using QuestionService.Data.Entities;
using QuestionService.Models.EntityModels;

namespace QuestionService.Configurations
{
    public class AutomapperConfiguration : Profile
    {
        public AutomapperConfiguration()
        {
            BaseEntityModelMapping();
            QuestionModelMapping();
        }

        public void BaseEntityModelMapping()
        {
            CreateMap<BaseEntity, BaseEntityModel>();
            CreateMap<BaseEntityModel, BaseEntity>();
        }

        public void QuestionModelMapping()
        {
            CreateMap<Question, QuestionModel>();
            CreateMap<QuestionModel, Question>();
        }
    }
}
