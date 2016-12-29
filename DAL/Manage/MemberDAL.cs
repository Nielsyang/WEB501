using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL.Manage;
using System.Data.SqlClient;
using WebPlat.Commons;

namespace DAL.Manage
{
    public class MemberDAL
    {
        public Member Add
            (Member member)
        {
            string sql = "INSERT INTO member (name, sex, birth, degree, college, major, assignment, email, introduce, photo, add_time, address)  output inserted.id VALUES (@name, @sex, @birth, @degree, @college, @major, @assignment, @email, @introduce, @photo, @add_time, @address)";
            SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@name", ToDBValue(member.name)),
						new SqlParameter("@sex", ToDBValue(member.sex)),
						new SqlParameter("@birth", ToDBValue(member.birth)),
						new SqlParameter("@degree", ToDBValue(member.degree)),
						new SqlParameter("@college", ToDBValue(member.college)),
						new SqlParameter("@major", ToDBValue(member.major)),
						new SqlParameter("@assignment", ToDBValue(member.assignment)),
						new SqlParameter("@email", ToDBValue(member.email)),
						new SqlParameter("@introduce", ToDBValue(member.introduce)),
						new SqlParameter("@photo", ToDBValue(member.photo)),
						new SqlParameter("@add_time", ToDBValue(member.add_time)),
						new SqlParameter("@address", ToDBValue(member.address)),
					};

            int newId = (int)SqlHelper.ExecuteScalar(sql, para);
            return GetByid(newId);
        }

        public int DeleteByid(int id)
        {
            string sql = "DELETE member WHERE id = @id";

            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@id", id)
			};

            return SqlHelper.ExecuteNonQuery(sql, para);
        }


        public int Update(Member member)
        {
            string sql =
                "UPDATE member " +
                "SET " +
            " name = @name"
                + ", sex = @sex"
                + ", birth = @birth"
                + ", degree = @degree"
                + ", college = @college"
                + ", major = @major"
                + ", assignment = @assignment"
                + ", email = @email"
                + ", introduce = @introduce"
                + ", photo = @photo"
                + ", add_time = @add_time"
                + ", address = @address"

            + " WHERE id = @id";


            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@id", member.id)
					,new SqlParameter("@name", ToDBValue(member.name))
					,new SqlParameter("@sex", ToDBValue(member.sex))
					,new SqlParameter("@birth", ToDBValue(member.birth))
					,new SqlParameter("@degree", ToDBValue(member.degree))
					,new SqlParameter("@college", ToDBValue(member.college))
					,new SqlParameter("@major", ToDBValue(member.major))
					,new SqlParameter("@assignment", ToDBValue(member.assignment))
					,new SqlParameter("@email", ToDBValue(member.email))
					,new SqlParameter("@introduce", ToDBValue(member.introduce))
					,new SqlParameter("@photo", ToDBValue(member.photo))
					,new SqlParameter("@add_time", ToDBValue(member.add_time))
					,new SqlParameter("@address", ToDBValue(member.address))
			};

            return SqlHelper.ExecuteNonQuery(sql, para);
        }

        public Member GetByid(int id)
        {
            string sql = "SELECT * FROM member WHERE id = @id";
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

        public Member ToModel(SqlDataReader reader)
        {
            Member member = new Member();
            member.id = (int)ToModelValue(reader, "id");
            member.name = (string)ToModelValue(reader, "name");
            member.sex = (string)ToModelValue(reader, "sex");
            member.birth = (DateTime?)ToModelValue(reader, "birth");
            member.degree = (string)ToModelValue(reader, "degree");
            member.college = (string)ToModelValue(reader, "college");
            member.major = (string)ToModelValue(reader, "major");
            member.assignment = (string)ToModelValue(reader, "assignment");
            member.email = (string)ToModelValue(reader, "email");
            member.introduce = (string)ToModelValue(reader, "introduce");
            member.photo = (string)ToModelValue(reader, "photo");
            member.add_time = (DateTime?)ToModelValue(reader, "add_time");
            member.address = (string)ToModelValue(reader, "address");
            return member;
        }

        public int GetTotalCount()
        {
            string sql = "SELECT count(*) FROM member";
            return (int)SqlHelper.ExecuteScalar(sql);
        }

        public List<Member> GetPagedData(int startIndex, int pageSize)
        {
            string sql = "SELECT * from(SELECT *,row_number() over(order by id) rownum FROM member) t where rownum>@minrownum and rownum<=(@maxrownum+@minrownum)";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql,
                new SqlParameter("@minrownum", startIndex),
                new SqlParameter("@maxrownum", pageSize)))
            {
                return ToModels(reader);
            }
        }

        public List<Member> GetAll()
        {
            string sql = "SELECT * FROM member";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
            {
                return ToModels(reader);
            }
        }

        protected List<Member> ToModels(SqlDataReader reader)
        {
            var list = new List<Member>();
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
