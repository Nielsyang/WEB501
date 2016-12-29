using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using WebPlat.Commons;
using System.Data;
using MODEL.Manage;

namespace DAL.Manage
{
    public class AdminDAL
    {
        public bool checkLogin(string username, string password)
        {
            string sql = "select * from admin where username=@username  and password=@password";
            SqlDataReader reader= SqlHelper.ExecuteDataReader(sql, new SqlParameter("@username", username), new SqlParameter("@password", password));
            if (reader.HasRows) return true;
            else return false;
        }
        public Admin Add
			(Admin admin)
		{
				string sql ="INSERT INTO admin (username, password)  output inserted.id VALUES (@username, @password)";
				SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@username", ToDBValue(admin.Username)),
						new SqlParameter("@password", ToDBValue(admin.Password)),
					};
					
				int newId = (int)SqlHelper.ExecuteScalar(sql, para);
				return GetById(newId);
		}

        public int DeleteById(int id)
		{
            string sql = "DELETE admin WHERE Id = @Id";

           SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@id", id)
			};
		
            return SqlHelper.ExecuteNonQuery(sql, para);
		}
        public int DeleteAdmin(Admin admin)
        {
            string sql = "delete from admin where id=@id";
            SqlParameter para = new SqlParameter("@id",admin.Id);
            return SqlHelper.ExecuteNonQuery(sql,para);
        }
				
        public int Update(Admin admin)
        {
            string sql =
                "UPDATE admin " +
                "SET "
                +" password = @password" 
               
            +" WHERE id = @id";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@id", admin.Id)
					,new SqlParameter("@password", ToDBValue(admin.Password))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }		
		
        public Admin GetById(int id)
        {
            string sql = "SELECT * FROM admin WHERE Id = @Id";
            using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql, new SqlParameter("@Id", id)))
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
		
		public Admin ToModel(SqlDataReader reader)
		{
			Admin admin = new Admin();

			admin.Id = (int)ToModelValue(reader,"id");
			admin.Username = (string)ToModelValue(reader,"username");
			admin.Password = (string)ToModelValue(reader,"password");
			return admin;
		}
		
		public int GetTotalCount()
		{
			string sql = "SELECT count(*) FROM admin";
			return (int)SqlHelper.ExecuteScalar(sql);
		}
		
		public List<Admin> GetPagedData(int startRowIndex,int maximumRows)
		{
            string sql = "SELECT * from(SELECT *,row_number() over(order by id) rownum FROM admin) t where rownum>@minrownum and rownum<=(@minrownum+@maxrownum)";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql,
                new SqlParameter("@minrownum", startRowIndex),
                new SqlParameter("@maxrownum", maximumRows)))
			{
				return ToModels(reader);					
			}
		}
		
		public List<Admin> GetAll()
		{
			string sql = "SELECT * FROM admin";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
			{
				return ToModels(reader);			
			}
		}
		
		protected List<Admin> ToModels(SqlDataReader reader)
		{
			var list = new List<Admin>();
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