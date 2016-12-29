using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using WebPlat.Commons;
using MODEL.Manage;
namespace DAL.Manage
{
    public partial class AboutService
    {
        public About Add(About about)
        {
            string sql = "INSERT INTO about (title, content, add_time)  output inserted.id VALUES (@title, @content, @add_time)";
            SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@title", ToDBValue(about.Title)),
						new SqlParameter("@content", ToDBValue(about.Content)),
						new SqlParameter("@add_time", ToDBValue(about.Add_time)),
					};
            int newId = (int)SqlHelper.ExecuteScalar(sql, para);
            return GetById(newId);
        }
        public int DeleteById(int id)
        {
            string sql = "DELETE  from about WHERE id = @id";
            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@id", id)
			};
            return SqlHelper.ExecuteNonQuery(sql, para);
        }
        public int DeleteAbout(About about)
        {
            string sql = "delete from about where id=@id";
            SqlParameter paras = new SqlParameter("@id",about.Id);
            return SqlHelper.ExecuteNonQuery(sql, paras);
        }
        public int Update(About about)
        {
            string sql =
                "UPDATE about " +
                "SET " +
            " title = @title"
                + ", content = @content"
                + ", add_time = @add_time"

            + " WHERE id = @id";
            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@id", about.Id)
					,new SqlParameter("@title", ToDBValue(about.Title))
					,new SqlParameter("@content", ToDBValue(about.Content))
					,new SqlParameter("@add_time", ToDBValue(about.Add_time))
			};
            return SqlHelper.ExecuteNonQuery(sql, para);
        }

        public About GetById(int id)
        {
            string sql = "SELECT * FROM about WHERE Id = @Id";
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
        public About ToModel(SqlDataReader reader)
        {
            About about = new About();

            about.Id = (int)ToModelValue(reader, "id");
            about.Title = (string)ToModelValue(reader, "title");
            about.Content = (string)ToModelValue(reader, "content");
            about.Add_time = (DateTime?)ToModelValue(reader, "add_time");
            return about;
        }
        public int GetTotalCount()
        {
            string sql = "SELECT count(*) FROM about";
            return (int)SqlHelper.ExecuteScalar(sql);
        }
        //public List<About> GetPagedData(int startRowIndex, int maximumRows)
        //{
        //    string sql = "SELECT * from(SELECT *,row_number() over(order by id) rownum FROM about) t where rownum>@minrownum and rownum<=(@minrownum+@maxrownum)";
        //    using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql,
        //        new SqlParameter("@minrownum", startRowIndex),
        //        new SqlParameter("@maxrownum", maximumRows)))
        //    {
        //        return ToModels(reader);
        //    }
        //}
        public List<About> GetPagedData(int startRowIndex, int maximumRows)
        {
            string sql = "SELECT * from(SELECT *,row_number() over(order by id) rownum FROM about) t where rownum>@minrownum and rownum<=(@minrownum+@maxrownum)";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql,
                new SqlParameter("@minrownum", startRowIndex),
                new SqlParameter("@maxrownum", maximumRows)))
            {
                 return  ToModels(reader);
            }
        }
        public List<About> GetAll()
        {
            string sql = "SELECT * FROM about";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
            {
                return ToModels(reader);
            }
        }
        protected  List<About> ToModels(SqlDataReader reader)
        {
            var list = new List<About>();
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