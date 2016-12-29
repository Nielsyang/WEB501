using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL.Manage;
using DAL.Manage;

namespace BLL.Manage
{
    public class MemberBLL
    {
        public Member Add(Member member)
        {
            return new MemberDAL().Add(member);
        }

        public int DeleteByid(int id)
        {
            return new MemberDAL().DeleteByid(id);
        }

        public int Update(Member member)
        {
            return new MemberDAL().Update(member);
        }


        public Member GetByid(int id)
        {
            return new MemberDAL().GetByid(id);
        }
        public int GetTotalCount()
        {
            return new MemberDAL().GetTotalCount();
        }

        public List<Member> GetPagedData(int minrownum, int maxrownum)
        {
            return new MemberDAL().GetPagedData(minrownum, maxrownum);
        }

        public List<Member> GetAll()
        {
            return new MemberDAL().GetAll();
        }
    }
}
