using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL.Manage;
using System.Data.SqlClient;
using WebPlat.Commons;

namespace DAL.Manage
{
    public partial class QuestionService
    {
        public Question Add
            (Question question)
        {
            string sql = "INSERT INTO question (name, email, subject, message, send_time)  output inserted.id VALUES (@name, @email, @subject, @message, @send_time)";
            SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@name", ToDBValue(question.Name)),
						new SqlParameter("@email", ToDBValue(question.Email)),
						new SqlParameter("@subject", ToDBValue(question.Subject)),
						new SqlParameter("@message", ToDBValue(question.Message)),
						new SqlParameter("@send_time", ToDBValue(question.Send_time)),
					};

            int newId = (int)SqlHelper.ExecuteScalar(sql, para);
            return GetById(newId);
        }
        public int DeleteById(int id)
        {
            string sql = "DELETE question WHERE Id = @Id";

            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@id", id)
			};

            return SqlHelper.ExecuteNonQuery(sql, para);
        }
        public int DeleteQuestion(Question question)
        {
            string sql = "delete from question where Id=@Id";
            return SqlHelper.ExecuteNonQuery(sql, new SqlParameter("@Id",question.Id));
        }

        public int Update(Question question)
        {
            string sql =
                "UPDATE question " +
                "SET " +
            " name = @name"
                + ", email = @email"
                + ", subject = @subject"
                + ", message = @message"
                + ", send_time = @send_time"

            + " WHERE id = @id";


            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@id", question.Id)
					,new SqlParameter("@name", ToDBValue(question.Name))
					,new SqlParameter("@email", ToDBValue(question.Email))
					,new SqlParameter("@subject", ToDBValue(question.Subject))
					,new SqlParameter("@message", ToDBValue(question.Message))
					,new SqlParameter("@send_time", ToDBValue(question.Send_time))
			};

            return SqlHelper.ExecuteNonQuery(sql, para);
        }

        public Question GetById(int id)
        {
            string sql = "SELECT * FROM question WHERE Id = @Id";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql, new SqlParameter("@Id", id)))
            {
                if (reader.Read())
                {
                    return ToModel(reader);
                }
                else
                {
                    return null;
                }
            }
        }

        public Question ToModel(SqlDataReader reader)
        {
            Question question = new Question();

            question.Id = (int)ToModelValue(reader, "id");
            question.Name = (string)ToModelValue(reader, "name");
            question.Email = (string)ToModelValue(reader, "email");
            question.Subject = (string)ToModelValue(reader, "subject");
            question.Message = (string)ToModelValue(reader, "message");
            question.Send_time = (DateTime?)ToModelValue(reader, "send_time");
            return question;
        }

        public int GetTotalCount()
        {
            string sql = "SELECT count(*) FROM question";
            return (int)SqlHelper.ExecuteScalar(sql);
        }

        public List<Question> GetPagedData(int startRowIndex, int maximumRows)
        {
            string sql = "SELECT * from(SELECT *,row_number() over(order by id) rownum FROM question) t where rownum>@minrownum and rownum<=(@minrownum+@maxrownum)";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql,
                new SqlParameter("@minrownum", startRowIndex),
                new SqlParameter("@maxrownum", maximumRows)))
            {
                return ToModels(reader);
            }
        }

        public List<Question> GetAll()
        {
            string sql = "SELECT * FROM question";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
            {
                return ToModels(reader);
            }
        }
        public List<Question> getPart()
        {
            string sql = "SELECT  id ,name ,email  ,subject ,send_time FROM question ";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
            {
                return ToModels(reader);
            }
        }
        protected List<Question> ToModels(SqlDataReader reader)
        {
            var list = new List<Question>();
            while (reader.Read())
            {
                list.Add(ToModel(reader));
            }
            return list;
        }

        protected object ToDBValue(object value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }
            else
            {
                return value;
            }
        }

        protected object ToModelValue(SqlDataReader reader, string columnName)
        {
            if (reader.IsDBNull(reader.GetOrdinal(columnName)))
            {
                return null;
            }
            else
            {
                return reader[columnName];
            }
        }
    }
}
