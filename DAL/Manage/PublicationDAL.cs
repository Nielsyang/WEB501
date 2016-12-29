using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL.Manage;
using System.Data.SqlClient;
using WebPlat.Commons;

namespace DAL.Manage
{
    public class PublicationDAL
    {
        public Publication Add
           (Publication publication)
		{
				string sql ="INSERT INTO publication (paper_name, level, type, abstract, publish_time, url, Author, keyWord)  output inserted.id VALUES (@paper_name, @level, @type, @abstract, @publish_time, @url, @Author, @keyWord)";
				SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@paper_name", ToDBValue(publication.paper_name)),
						new SqlParameter("@level", ToDBValue(publication.level)),
						new SqlParameter("@type", ToDBValue(publication.type)),
						new SqlParameter("@abstract", ToDBValue(publication.Abstract)),
						new SqlParameter("@publish_time", ToDBValue(publication.publish_time)),
						new SqlParameter("@url", ToDBValue(publication.url)),
						new SqlParameter("@Author", ToDBValue(publication.Author)),
						new SqlParameter("@keyWord", ToDBValue(publication.keyWord)),
					};
					
				int newId = (int)SqlHelper.ExecuteScalar(sql, para);
				return GetByid(newId);
		}

        public int DeleteByid(int id)
        {
            string sql = "DELETE publication WHERE id = @id";

            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@id", id)
			};

            return SqlHelper.ExecuteNonQuery(sql, para);
        }


        public int Update(Publication publication)
        {
            string sql =
                "UPDATE publication " +
                "SET " +
			" paper_name = @paper_name" 
                +", level = @level" 
                +", type = @type" 
                +", abstract = @abstract" 
                +", publish_time = @publish_time" 
                +", url = @url" 
                +", Author = @Author" 
                +", keyWord = @keyWord" 
               
            +" WHERE id = @id";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@id", publication.id)
					,new SqlParameter("@paper_name", ToDBValue(publication.paper_name))
					,new SqlParameter("@level", ToDBValue(publication.level))
					,new SqlParameter("@type", ToDBValue(publication.type))
					,new SqlParameter("@abstract", ToDBValue(publication.Abstract))
					,new SqlParameter("@publish_time", ToDBValue(publication.publish_time))
					,new SqlParameter("@url", ToDBValue(publication.url))
					,new SqlParameter("@Author", ToDBValue(publication.Author))
					,new SqlParameter("@keyWord", ToDBValue(publication.keyWord))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }

        public Publication GetByid(int id)
        {
            string sql = "SELECT * FROM publication WHERE id = @id";
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

        public Publication ToModel(SqlDataReader reader)
		{
			Publication publication = new Publication();

			publication.id = (int)ToModelValue(reader,"id");
			publication.paper_name = (string)ToModelValue(reader,"paper_name");
			publication.level = (string)ToModelValue(reader,"level");
			publication.type = (string)ToModelValue(reader,"type");
			publication.Abstract = (string)ToModelValue(reader,"abstract");
			publication.publish_time = (DateTime?)ToModelValue(reader,"publish_time");
			publication.url = (string)ToModelValue(reader,"url");
			publication.Author = (string)ToModelValue(reader,"Author");
			publication.keyWord = (string)ToModelValue(reader,"keyWord");
			return publication;
		}

        public int GetTotalCount()
        {
            string sql = "SELECT count(*) FROM publication";
            return (int)SqlHelper.ExecuteScalar(sql);
        }

        public List<Publication> GetPagedData(int startIndex, int pageSize)
        {
            string sql = "SELECT * from(SELECT *,row_number() over(order by id) rownum FROM publication) t where rownum>@minrownum and rownum<=(@maxrownum+@minrownum)";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql,
                new SqlParameter("@minrownum", startIndex),
                new SqlParameter("@maxrownum", pageSize)))
            {
                return ToModels(reader);
            }
        }

        public List<Publication> GetAll()
        {
            string sql = "SELECT * FROM publication";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
            {
                return ToModels(reader);
            }
        }

        protected List<Publication> ToModels(SqlDataReader reader)
        {
            var list = new List<Publication>();
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
