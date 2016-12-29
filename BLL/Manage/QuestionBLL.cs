using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL.Manage;
using DAL.Manage;

namespace BLL.Manage
{
    public partial class QuestionManager
    {
        public Question Add(Question question)
        {
            return new QuestionService().Add(question);
        }

        public int DeleteById(int id)
        {
            return new QuestionService().DeleteById(id);
        }
        public int DeleteQuestion(Question question)
        {
            return new QuestionManager().DeleteQuestion(question);
        }
        public int Update(Question question)
        {
            return new QuestionService().Update(question);
        }


        public Question GetById(int id)
        {
            return new QuestionService().GetById(id);
        }
        public int GetTotalCount()
        {
            return new QuestionService().GetTotalCount();
        }

        public List<Question> GetPagedData(int minrownum, int maxrownum)
        {
            return new QuestionService().GetPagedData(minrownum, maxrownum);
        }

        public List<Question> GetAll()
        {
            return new QuestionService().GetAll();
        }
        public List<Question> getPart()
        {
            return new QuestionService().getPart();
        }
    }
}
