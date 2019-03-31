using QuestionService.Core.Services.CRUDService;
using QuestionService.Data.Entities;

namespace QuestionService.Core.Services.QuestionService
{
    public interface IQuestionService : ICrudService<Question>
    {
    }
}
