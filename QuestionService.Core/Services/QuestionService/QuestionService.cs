using QuestionService.Core.Services.CRUDService;
using QuestionService.Core.Services.QuestionService;
using QuestionService.Data.Context;
using QuestionService.Data.Entities;

namespace QuestionService.Core.Services.QuestionService
{
    public class QuestionService : CrudService<Question>, IQuestionService
    {
        public QuestionService(QuestionContext context) : base(context)
        {
        }
    }
}
