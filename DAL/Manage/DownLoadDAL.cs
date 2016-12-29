using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using WebPlat.Commons;
using MODEL.Manage;

namespace DAL.Manage
{
   public class DownLoadDAL
    {
         public FileDownload  Add
			(FileDownload download)
		{
				string sql ="INSERT INTO download (filename, info, url, add_time)  output inserted.id VALUES (@filename, @info, @url, @add_time)";
				SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@filename", ToDBValue(download.filename)),
						new SqlParameter("@info", ToDBValue(download.info)),
						new SqlParameter("@url", ToDBValue(download.url)),
						new SqlParameter("@add_time", ToDBValue(download.add_time)),
					};
					
				int newId = (int)SqlHelper.ExecuteScalar(sql, para);
				return GetByid(newId);
		}

        public int DeleteByid(int id)
		{
            string sql = "DELETE from download  WHERE  id = @id";

           SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@id", id)
			};
		
            return SqlHelper.ExecuteNonQuery(sql, para);
		}
		
				
        public int Update(FileDownload download)
        {
            string sql =
                "UPDATE download " +
                "SET " +
			" filename = @filename" 
                +", info = @info" 
                +", url = @url" 
                +", add_time = @add_time" 
               
            +" WHERE id = @id";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@id", download.id)
					,new SqlParameter("@filename", ToDBValue(download.filename))
					,new SqlParameter("@info", ToDBValue(download.info))
					,new SqlParameter("@url", ToDBValue(download.url))
					,new SqlParameter("@add_time", ToDBValue(download.add_time))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }		
		
        public FileDownload GetByid(int id)
        {
            string sql = "SELECT * FROM download WHERE id = @id";
            using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql, new SqlParameter("@id", id)))
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
		
		public FileDownload ToModel(SqlDataReader reader)
		{
			FileDownload download = new FileDownload();

			download.id = (int)ToModelValue(reader,"id");
			download.filename = (string)ToModelValue(reader,"filename");
			download.info = (string)ToModelValue(reader,"info");
			download.url = (string)ToModelValue(reader,"url");
			download.add_time = (DateTime?)ToModelValue(reader,"add_time");
			return download;
		}
		
		public int GetTotalCount()
		{
			string sql = "SELECT count(*) FROM download";
			return (int)SqlHelper.ExecuteScalar(sql);
		}
		
		public List<FileDownload> GetPagedData(int startIndex,int pageSize)
		{
			string sql = "SELECT * from(SELECT *,row_number() over(order by id) rownum FROM download) t where rownum>@minrownum and rownum<=(@maxrownum+@minrownum)";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql,
				new SqlParameter("@minrownum",startIndex),
				new SqlParameter("@maxrownum",pageSize)))
			{
				return ToModels(reader);					
			}
		}
		
		public  List<FileDownload> GetAll()
		{
			string sql = "SELECT * FROM download";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
			{
				return ToModels(reader);			
			}
		}
		
		protected List<FileDownload> ToModels(SqlDataReader reader)
		{
			var list = new List<FileDownload>();
			while(reader.Read())
			{
				list.Add(ToModel(reader));
			}	
			return list;
		}		
		
		protected object ToDBValue(object value)
		{
			if(value==null)
			{
				return DBNull.Value;
			}
			else
			{
				return value;
			}
		}
		
		protected object ToModelValue(SqlDataReader reader,string columnName)
		{
			if(reader.IsDBNull(reader.GetOrdinal(columnName)))
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
