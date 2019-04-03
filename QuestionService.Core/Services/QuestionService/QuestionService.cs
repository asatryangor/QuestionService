using Microsoft.EntityFrameworkCore;
using QuestionService.Core.Services.CRUDService;
using QuestionService.Data.Context;
using QuestionService.Data.Entities;
using System;
using System.Linq;

namespace QuestionService.Core.Services.QuestionService
{
    public class QuestionService : CrudService<Question>, IQuestionService
    {
        public QuestionService(QuestionContext context) : base(context)
        {
        }

        //public override Question Update(Question model)
        //{
        //    using (var transaction = _context.Database.BeginTransaction())
        //    {
        //        try
        //        {
        //            //_context.QuestionTags.Where(x => x.QuestionId == model.Id).DeleteFromQuery();
        //            //var entry = _context.Attach(model);
        //            //entry.State = EntityState.Modified;
        //            //var questionTags = _context.QuestionTags.AsNoTracking().Where(x => x.QuestionId == model.Id).ToList();
        //            //foreach (var x in questionTags)
        //            //{
        //            //    if (model.QuestionTags.Contains(x))
        //            //    {
        //            //        _context.Entry(x).State = EntityState.Modified;
        //            //    }
        //            //    else
        //            //    {
        //            //        _context.Entry(x).State = EntityState.Deleted;
        //            //    }
        //            //}

        //            //var questionTags = _context.QuestionTags.Where(x => x.QuestionId == model.Id);
        //            //foreach(var questionTag in questionTags)
        //            //{
        //            //    _context.QuestionTags.Remove(questionTag);
        //            //}
        //            //_context.SaveChanges();
        //            //var questionTags = _context.QuestionTags.AsNoTracking().Where(x => x.QuestionId == model.Id);
        //            //foreach (var x in questionTags)
        //            //{
        //            //    _context.Entry(x).State = EntityState.Detached;
        //            //    _context.QuestionTags.RemoveRange(questionTags);
        //            //    _context.SaveChanges();
        //            //}
        //            //if (model.QuestionTags != null)
        //            //{
        //            //    foreach (var questionTag in model.QuestionTags)
        //            //    {
        //            //        questionTag.Tag = _context.Tags.SingleOrDefault(x => x.Id == questionTag.TagId);
        //            //    }
        //            //    _context.AddRange(model.QuestionTags);
        //            //    _context.SaveChanges();
        //            //}
        //            //var updated = base.Update(model);
        //            _context.SaveChanges();

        //            transaction.Commit();
        //            return entry.Entity;
        //        }
        //        catch (Exception ex)
        //        {
        //            transaction.Rollback();
        //            throw ex;
        //        }
        //    }
        //}

        public void LoadTags(Question question)
        {
            foreach (var tag in question.QuestionTags)
            {
                tag.Tag = _context.Tags.SingleOrDefault(x => x.Id == tag.TagId);
                tag.Question = _context.Questions.SingleOrDefault(x => x.Id == tag.QuestionId);
            }
        }
    }
}
