using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using MODEL;
using WebPlat.Commons;

namespace DAL
{
    public class NetDAL
    {
        public string GetNodes()
        {
            string sql = "select * from [NetNodes]";
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            return TableConvertToString(dt);
        }

        public string GetLinks()
        {
            string sql = "select * from [NetLinks]";
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            return TableConvertToString(dt);
        }

        public string[] GetNodeNums(string AnalyseType, int num)
        {
            string[] res = new string[num];
            if (AnalyseType == "Formula")
            {
                string sql = "select count(*) as cnt from [NetNodes] where category='1'";
                DataTable dt = SqlHelper.ExecuteDataTable(sql);
                res[0] = TableToString(dt);
                string sql1 = "select count(*) as cnt from [NetNodes] where category='2'";
                DataTable dt1 = SqlHelper.ExecuteDataTable(sql1);
                res[1] = TableToString(dt1);
                string sql2 = "select count(*) as cnt from [NetNodes] where category='3'";
                DataTable dt2 = SqlHelper.ExecuteDataTable(sql2);
                res[2] = TableToString(dt2);
                string sql3 = "select count(*) as cnt from [NetNodes] where category='4'";
                DataTable dt3 = SqlHelper.ExecuteDataTable(sql3);
                res[3] = TableToString(dt3);
            }
            else if (AnalyseType == "Herb")
            {
                string sql = "select count(*) as cnt from [NetNodes] where category='1'";
                DataTable dt = SqlHelper.ExecuteDataTable(sql);
                res[0] = TableToString(dt);
                string sql1 = "select count(*) as cnt from [NetNodes] where category='2'";
                DataTable dt1 = SqlHelper.ExecuteDataTable(sql1);
                res[1] = TableToString(dt1);
                string sql2 = "select count(*) as cnt from [NetNodes] where category='3'";
                DataTable dt2 = SqlHelper.ExecuteDataTable(sql2);
                res[2] = TableToString(dt2);
            }
            return res;
        }
        public string TableToString(DataTable dt)
        {
            string res = "";
            foreach (DataRow dr in dt.Rows)
            {
                res = dr["cnt"].ToString();
            }
            return res;
        }
        public void Generate_Net(string formula, string herb, string disease, string tissue, float ptvalue, float pdvalue)
        {
            //执行存储过程
            string procName = "Generate_net";
            SqlParameter Formula = new SqlParameter("@Formula", formula);
            SqlParameter Herb = new SqlParameter("@Herb", herb);
            SqlParameter Disease = new SqlParameter("@Disease", disease);
            SqlParameter Tissue = new SqlParameter("@Tissue", tissue);
            SqlParameter Pvalue_t = new SqlParameter("@Pvalue_t", ptvalue);
            SqlParameter Pvalue_O = new SqlParameter("@Pvalue_O", pdvalue);
            SqlHelper.ExecuteStoredProcedureTable(procName, Formula, Herb, Disease, Tissue, Pvalue_t, Pvalue_O);
        }

        public string TableConvertToString(DataTable dt)
        {
            string res = "";
            if (dt.Rows.Count == 0)
               return res;

            if (dt.Columns.Count == 3)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    res += dr["itema"].ToString() + "~" + dr["itemb"].ToString() + "~" + dr["category"].ToString() + ";";
                }
            }
            else if (dt.Columns.Count == 2)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    res += dr["itema"].ToString() + "~" + dr["category"].ToString() + ";";
                }

            }

                return res.Substring(0, res.Length - 1);
        }
    }
}
