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
            TagModelMapping();
            QuestionTagModelMapping();
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
        public void TagModelMapping()
        {
            CreateMap<Tag, TagModel>();
            CreateMap<TagModel, Tag>();
        }
        public void QuestionTagModelMapping()
        {
            CreateMap<QuestionTag, QuestionTagModel>();
            CreateMap<QuestionTagModel, QuestionTag>();
        }
    }
}
