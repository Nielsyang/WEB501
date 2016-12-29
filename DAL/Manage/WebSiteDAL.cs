using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using MODEL.Manage;
using WebPlat.Commons;

namespace DAL.Manage
{
    public class WebSiteDAL
    {
        public WebSite Add
           (WebSite website)
        {
            string sql = "INSERT INTO website (web_name, link, logo)  output inserted.id VALUES (@web_name, @link, @logo)";
            SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@web_name", ToDBValue(website.web_name)),
						new SqlParameter("@link", ToDBValue(website.link)),
						new SqlParameter("@logo", ToDBValue(website.logo)),
					};

            int newId = (int)SqlHelper.ExecuteScalar(sql, para);
            return GetByid(newId);
        }

        public int DeleteByid(int id)
        {
            string sql = "DELETE website WHERE id = @id";

            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@id", id)
			};

            return SqlHelper.ExecuteNonQuery(sql, para);
        }


        public int Update(WebSite website)
        {
            string sql =
                "UPDATE website " +
                "SET " +
            " web_name = @web_name"
                + ", link = @link"
                + ", logo = @logo"

            + " WHERE id = @id";


            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@id", website.id)
					,new SqlParameter("@web_name", ToDBValue(website.web_name))
					,new SqlParameter("@link", ToDBValue(website.link))
					,new SqlParameter("@logo", ToDBValue(website.logo))
			};

            return SqlHelper.ExecuteNonQuery(sql, para);
        }

        public WebSite GetByid(int id)
        {
            string sql = "SELECT * FROM website WHERE id = @id";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql, new SqlParameter("@id", id)))
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

        public WebSite ToModel(SqlDataReader reader)
        {
            WebSite website = new WebSite();

            website.id = (int)ToModelValue(reader, "id");
            website.web_name = (string)ToModelValue(reader, "web_name");
            website.link = (string)ToModelValue(reader, "link");
            website.logo = (string)ToModelValue(reader, "logo");
            return website;
        }

        public int GetTotalCount()
        {
            string sql = "SELECT count(*) FROM website";
            return (int)SqlHelper.ExecuteScalar(sql);
        }

        public List<WebSite> GetPagedData(int startIndex, int pageSize)
        {
            string sql = "SELECT * from(SELECT *,row_number() over(order by id) rownum FROM website) t where rownum>@minrownum and rownum<=(@maxrownum+@minrownum)";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql,
                new SqlParameter("@minrownum", startIndex),
                new SqlParameter("@maxrownum", pageSize)))
            {
                return ToModels(reader);
            }
        }

        public List<WebSite> GetAll()
        {
            string sql = "SELECT * FROM website";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
            {
                return ToModels(reader);
            }
        }

        protected List<WebSite> ToModels(SqlDataReader reader)
        {
            var list = new List<WebSite>();
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
