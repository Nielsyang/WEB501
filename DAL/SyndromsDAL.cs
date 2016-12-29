using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL;
using System.Data.SqlClient;
using System.Data;
using WebPlat.Commons;
using System.IO;

namespace DAL
{
    public class SyndromsDAL
    {
        private float[,] BG_hidden1_weight;
        private float[,] BG_hidden2_weight;
        private float[,] BG_hidden1_bias;
        private float[,] BG_hidden2_bias;
        private float[,] BG_output_weight;
        private float[,] BG_output_bias;
        private float[,] BX_hidden1_weight;
        private float[,] BX_hidden2_weight;
        private float[,] BX_hidden1_bias;
        private float[,] BX_hidden2_bias;
        private float[,] BX_output_weight;
        private float[,] BX_output_bias;
        private float[,] ZF_hidden1_weight;
        private float[,] ZF_hidden2_weight;
        private float[,] ZF_hidden1_bias;
        private float[,] ZF_hidden2_bias;
        private float[,] ZF_output_weight;
        private float[,] ZF_output_bias;
        private float[,] LJ_hidden1_weight;
        private float[,] LJ_hidden2_weight;
        private float[,] LJ_hidden1_bias;
        private float[,] LJ_hidden2_bias;
        private float[,] LJ_output_weight;
        private float[,] LJ_output_bias;
        private float[,] WQ_hidden1_weight;
        private float[,] WQ_hidden2_weight;
        private float[,] WQ_hidden1_bias;
        private float[,] WQ_hidden2_bias;
        private float[,] WQ_output_weight;
        private float[,] WQ_output_bias;
        private float[,] SJ_hidden1_weight;
        private float[,] SJ_hidden2_weight;
        private float[,] SJ_hidden1_bias;
        private float[,] SJ_hidden2_bias;
        private float[,] SJ_output_weight;
        private float[,] SJ_output_bias;
        private Dictionary<string, float> zhengzhuangid;
        private Dictionary<float, string> zhenghouid;
        private string[] tempstr;

        public SyndromsDAL()
        {
            BG_hidden1_weight = new float[1084, 100];
            BG_hidden2_weight = new float[100, 100];
            BG_hidden1_bias = new float[1, 100];
            BG_hidden2_bias = new float[1, 100];
            BG_output_weight = new float[100, 125];
            BG_output_bias = new float[1, 125];
            BX_hidden1_weight = new float[1084, 100];
            BX_hidden2_weight = new float[100, 100];
            BX_hidden1_bias = new float[1, 100];
            BX_hidden2_bias = new float[1, 100];
            BX_output_weight = new float[100, 125];
            BX_output_bias = new float[1, 125];
            ZF_hidden1_weight = new float[1084, 100];
            ZF_hidden2_weight = new float[100, 100];
            ZF_hidden1_bias = new float[1, 100];
            ZF_hidden2_bias = new float[1, 100];
            ZF_output_weight = new float[100, 125];
            ZF_output_bias = new float[1, 125];
            LJ_hidden1_weight = new float[1084, 100];
            LJ_hidden2_weight = new float[100, 100];
            LJ_hidden1_bias = new float[1, 100];
            LJ_hidden2_bias = new float[1, 100];
            LJ_output_weight = new float[100, 125];
            LJ_output_bias = new float[1, 125];
            WQ_hidden1_weight = new float[1084, 100];
            WQ_hidden2_weight = new float[100, 100];
            WQ_hidden1_bias = new float[1, 100];
            WQ_hidden2_bias = new float[1, 100];
            WQ_output_weight = new float[100, 125];
            WQ_output_bias = new float[1, 125];
            SJ_hidden1_weight = new float[1084, 100];
            SJ_hidden2_weight = new float[100, 100];
            SJ_hidden1_bias = new float[1, 100];
            SJ_hidden2_bias = new float[1, 100];
            SJ_output_weight = new float[100, 125];
            SJ_output_bias = new float[1, 125];
            zhenghouid = new Dictionary<float, string>();
            zhengzhuangid = new Dictionary<string, float>();
            tempstr = new string[125];

            using (StreamReader sr = new StreamReader("D:\\WebPlat_New\\Parameters_BaG.txt"))
            {
                string line;
                int line_position;
                int nth_parameters = 0;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] line_p = line.Split(',');
                    line_position = 0;

                    switch (nth_parameters)
                    {
                        case 0:
                            for (int i = 0; i < 1084; ++i)
                                for (int j = 0; j < 100; ++j)
                                {
                                    BG_hidden1_weight[i, j] = float.Parse(line_p[line_position++]);
                                }
                            break;
                        case 1:
                            for (int i = 0; i < 1; ++i)
                                for (int j = 0; j < 100; ++j)
                                {
                                    BG_hidden1_bias[i, j] = float.Parse(line_p[line_position++]);
                                }
                            break;
                        case 2:
                            for (int i = 0; i < 100; ++i)
                                for (int j = 0; j < 100; ++j)
                                {
                                    BG_hidden2_weight[i, j] = float.Parse(line_p[line_position++]);
                                }
                            break;
                        case 3:
                            for (int i = 0; i < 1; ++i)
                                for (int j = 0; j < 100; ++j)
                                {
                                    BG_hidden2_bias[i, j] = float.Parse(line_p[line_position++]);
                                }
                            break;
                        case 4:
                            for (int i = 0; i < 100; ++i)
                                for (int j = 0; j < 125; ++j)
                                {
                                    BG_output_weight[i, j] = float.Parse(line_p[line_position++]);
                                }
                            break;
                        case 5:
                            for (int i = 0; i < 1; ++i)
                                for (int j = 0; j < 125; ++j)
                                {
                                    BG_output_bias[i, j] = float.Parse(line_p[line_position++]);
                                }
                            break;
                        default:
                            Console.WriteLine("Error");
                            break;
                    }

                    nth_parameters++;

                }
            }
            using (StreamReader sr = new StreamReader("D:\\WebPlat_New\\Parameters_BX.txt"))
            {
                string line;
                int line_position;
                int nth_parameters = 0;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] line_p = line.Split(',');
                    line_position = 0;

                    switch (nth_parameters)
                    {
                        case 0:
                            for (int i = 0; i < 1084; ++i)
                                for (int j = 0; j < 100; ++j)
                                {
                                    BX_hidden1_weight[i, j] = float.Parse(line_p[line_position++]);
                                }
                            break;
                        case 1:
                            for (int i = 0; i < 1; ++i)
                                for (int j = 0; j < 100; ++j)
                                {
                                    BX_hidden1_bias[i, j] = float.Parse(line_p[line_position++]);
                                }
                            break;
                        case 2:
                            for (int i = 0; i < 100; ++i)
                                for (int j = 0; j < 100; ++j)
                                {
                                    BX_hidden2_weight[i, j] = float.Parse(line_p[line_position++]);
                                }
                            break;
                        case 3:
                            for (int i = 0; i < 1; ++i)
                                for (int j = 0; j < 100; ++j)
                                {
                                    BX_hidden2_bias[i, j] = float.Parse(line_p[line_position++]);
                                }
                            break;
                        case 4:
                            for (int i = 0; i < 100; ++i)
                                for (int j = 0; j < 125; ++j)
                                {
                                    BX_output_weight[i, j] = float.Parse(line_p[line_position++]);
                                }
                            break;
                        case 5:
                            for (int i = 0; i < 1; ++i)
                                for (int j = 0; j < 125; ++j)
                                {
                                    BX_output_bias[i, j] = float.Parse(line_p[line_position++]);
                                }
                            break;
                        default:
                            Console.WriteLine("Error");
                            break;
                    }

                    nth_parameters++;

                }
            }
            using (StreamReader sr = new StreamReader("D:\\WebPlat_New\\Parameters_ZF.txt"))
            {
                string line;
                int line_position;
                int nth_parameters = 0;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] line_p = line.Split(',');
                    line_position = 0;

                    switch (nth_parameters)
                    {
                        case 0:
                            for (int i = 0; i < 1084; ++i)
                                for (int j = 0; j < 100; ++j)
                                {
                                    ZF_hidden1_weight[i, j] = float.Parse(line_p[line_position++]);
                                }
                            break;
                        case 1:
                            for (int i = 0; i < 1; ++i)
                                for (int j = 0; j < 100; ++j)
                                {
                                    ZF_hidden1_bias[i, j] = float.Parse(line_p[line_position++]);
                                }
                            break;
                        case 2:
                            for (int i = 0; i < 100; ++i)
                                for (int j = 0; j < 100; ++j)
                                {
                                    ZF_hidden2_weight[i, j] = float.Parse(line_p[line_position++]);
                                }
                            break;
                        case 3:
                            for (int i = 0; i < 1; ++i)
                                for (int j = 0; j < 100; ++j)
                                {
                                    ZF_hidden2_bias[i, j] = float.Parse(line_p[line_position++]);
                                }
                            break;
                        case 4:
                            for (int i = 0; i < 100; ++i)
                                for (int j = 0; j < 125; ++j)
                                {
                                    ZF_output_weight[i, j] = float.Parse(line_p[line_position++]);
                                }
                            break;
                        case 5:
                            for (int i = 0; i < 1; ++i)
                                for (int j = 0; j < 125; ++j)
                                {
                                    ZF_output_bias[i, j] = float.Parse(line_p[line_position++]);
                                }
                            break;
                        default:
                            Console.WriteLine("Error");
                            break;
                    }

                    nth_parameters++;

                }
            }
            using (StreamReader sr = new StreamReader("D:\\WebPlat_New\\Parameters_LJ.txt"))
            {
                string line;
                int line_position;
                int nth_parameters = 0;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] line_p = line.Split(',');
                    line_position = 0;

                    switch (nth_parameters)
                    {
                        case 0:
                            for (int i = 0; i < 1084; ++i)
                                for (int j = 0; j < 100; ++j)
                                {
                                    LJ_hidden1_weight[i, j] = float.Parse(line_p[line_position++]);
                                }
                            break;
                        case 1:
                            for (int i = 0; i < 1; ++i)
                                for (int j = 0; j < 100; ++j)
                                {
                                    LJ_hidden1_bias[i, j] = float.Parse(line_p[line_position++]);
                                }
                            break;
                        case 2:
                            for (int i = 0; i < 100; ++i)
                                for (int j = 0; j < 100; ++j)
                                {
                                    LJ_hidden2_weight[i, j] = float.Parse(line_p[line_position++]);
                                }
                            break;
                        case 3:
                            for (int i = 0; i < 1; ++i)
                                for (int j = 0; j < 100; ++j)
                                {
                                    LJ_hidden2_bias[i, j] = float.Parse(line_p[line_position++]);
                                }
                            break;
                        case 4:
                            for (int i = 0; i < 100; ++i)
                                for (int j = 0; j < 125; ++j)
                                {
                                    LJ_output_weight[i, j] = float.Parse(line_p[line_position++]);
                                }
                            break;
                        case 5:
                            for (int i = 0; i < 1; ++i)
                                for (int j = 0; j < 125; ++j)
                                {
                                    LJ_output_bias[i, j] = float.Parse(line_p[line_position++]);
                                }
                            break;
                        default:
                            Console.WriteLine("Error");
                            break;
                    }

                    nth_parameters++;

                }
            }
            using (StreamReader sr = new StreamReader("D:\\WebPlat_New\\Parameters_WQ.txt"))
            {
                string line;
                int line_position;
                int nth_parameters = 0;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] line_p = line.Split(',');
                    line_position = 0;

                    switch (nth_parameters)
                    {
                        case 0:
                            for (int i = 0; i < 1084; ++i)
                                for (int j = 0; j < 100; ++j)
                                {
                                    WQ_hidden1_weight[i, j] = float.Parse(line_p[line_position++]);
                                }
                            break;
                        case 1:
                            for (int i = 0; i < 1; ++i)
                                for (int j = 0; j < 100; ++j)
                                {
                                    WQ_hidden1_bias[i, j] = float.Parse(line_p[line_position++]);
                                }
                            break;
                        case 2:
                            for (int i = 0; i < 100; ++i)
                                for (int j = 0; j < 100; ++j)
                                {
                                    WQ_hidden2_weight[i, j] = float.Parse(line_p[line_position++]);
                                }
                            break;
                        case 3:
                            for (int i = 0; i < 1; ++i)
                                for (int j = 0; j < 100; ++j)
                                {
                                    WQ_hidden2_bias[i, j] = float.Parse(line_p[line_position++]);
                                }
                            break;
                        case 4:
                            for (int i = 0; i < 100; ++i)
                                for (int j = 0; j < 125; ++j)
                                {
                                    WQ_output_weight[i, j] = float.Parse(line_p[line_position++]);
                                }
                            break;
                        case 5:
                            for (int i = 0; i < 1; ++i)
                                for (int j = 0; j < 125; ++j)
                                {
                                    WQ_output_bias[i, j] = float.Parse(line_p[line_position++]);
                                }
                            break;
                        default:
                            Console.WriteLine("Error");
                            break;
                    }

                    nth_parameters++;

                }
            }
            using (StreamReader sr = new StreamReader("D:\\WebPlat_New\\Parameters_SJ.txt"))
            {
                string line;
                int line_position;
                int nth_parameters = 0;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] line_p = line.Split(',');
                    line_position = 0;

                    switch (nth_parameters)
                    {
                        case 0:
                            for (int i = 0; i < 1084; ++i)
                                for (int j = 0; j < 100; ++j)
                                {
                                    SJ_hidden1_weight[i, j] = float.Parse(line_p[line_position++]);
                                }
                            break;
                        case 1:
                            for (int i = 0; i < 1; ++i)
                                for (int j = 0; j < 100; ++j)
                                {
                                    SJ_hidden1_bias[i, j] = float.Parse(line_p[line_position++]);
                                }
                            break;
                        case 2:
                            for (int i = 0; i < 100; ++i)
                                for (int j = 0; j < 100; ++j)
                                {
                                    SJ_hidden2_weight[i, j] = float.Parse(line_p[line_position++]);
                                }
                            break;
                        case 3:
                            for (int i = 0; i < 1; ++i)
                                for (int j = 0; j < 100; ++j)
                                {
                                    SJ_hidden2_bias[i, j] = float.Parse(line_p[line_position++]);
                                }
                            break;
                        case 4:
                            for (int i = 0; i < 100; ++i)
                                for (int j = 0; j < 125; ++j)
                                {
                                    SJ_output_weight[i, j] = float.Parse(line_p[line_position++]);
                                }
                            break;
                        case 5:
                            for (int i = 0; i < 1; ++i)
                                for (int j = 0; j < 125; ++j)
                                {
                                    SJ_output_bias[i, j] = float.Parse(line_p[line_position++]);
                                }
                            break;
                        default:
                            Console.WriteLine("Error");
                            break;
                    }

                    nth_parameters++;

                }
            }

        }

        public void GetDataZhengzhuangToId()
        {
            string sql = "Select * from 临床症状ID字典";
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            foreach (DataRow dr in dt.Rows)
            {
                zhengzhuangid.Add(dr["临床症状"].ToString(), Convert.ToInt32(dr["id"]));
            }
        }

        public void GetDataZhenghouToXuhao()
        {
            string sql = "Select * from 证候";
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            foreach (DataRow dr in dt.Rows)
            {
                zhenghouid.Add(Convert.ToInt32(dr["序号"]), dr["证候"].ToString());
            }
        }

        public void GetDataXuhaoToZhengzhuang()
        {
            string sql = "Select * from zhengzhuangzonghe";
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            foreach (DataRow dr in dt.Rows)
            {
                tempstr[Convert.ToInt32(dr["序号"]) - 1] += dr["临床症状"].ToString() + ",";
            }
            for (int i = 0; i < 125; i++)
            {
                tempstr[i] = tempstr[i].Remove(tempstr[i].Length - 1);
            }
        }

        public float[,] ToStdData(float[] data)
        {
            float[,] std = new float[1, 1084];
            for (int i = 0; i < data.Length; ++i)
            {
                std[0, (int)((int)data[i] - 1)] = 1;
            }

            return std;
        }

        public float[,] MatMul(float[,] a, float[,] b)
        {
            int a_row = a.GetLength(0);
            int a_col = a.GetLength(1);
            int b_row = b.GetLength(0);
            int b_col = b.GetLength(1);
            float[,] res = new float[a_row, b_col];

            for (int i = 0; i < a_row; ++i)
            {
                for (int j = 0; j < b_col; ++j)
                {
                    for (int k = 0; k < a_col; ++k)
                    {
                        res[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return res;
        }

        public float[,] Softmax(float[,] data)
        {
            float[,] res = new float[1, data.GetLength(1)];
            float denominator = 0;  //fenmu

            for (int i = 0; i < data.GetLength(1); ++i)
                denominator += (float)Math.Exp(data[0, i]);

            for (int i = 0; i < data.GetLength(1); ++i)
                res[0, i] = (float)Math.Exp(data[0, i]) / denominator;

            return res;

        }

        public float[,] relu(float[,] data)
        {
            float[,] res = new float[data.GetLength(0), data.GetLength(1)];
            for (int i = 0; i < data.GetLength(0); ++i)
                for (int j = 0; j < data.GetLength(1); ++j)
                    if (data[i, j] < 0)
                        res[i, j] = 0;
                    else
                        res[i, j] = data[i, j];
            return res;
        }

        public float[,] model(float[,] data, float[,] h1w, float[,] h1b, float[,] h2w, float[,] h2b, float[,] ow, float[,] ob)
        {
            float[,] h1_out = new float[1, 100];
            float[,] h2_out = new float[1, 100];
            float[,] final_out = new float[1, 125];
            //float[,] res = new float[1, 125];
            h1_out = MatMul(data, h1w);
            for (int i = 0; i < 1; ++i)
                for (int j = 0; j < 100; ++j)
                    h1_out[i, j] += h1b[i, j];
            h1_out = relu(h1_out);
            h2_out = MatMul(h1_out, h2w);
            for (int i = 0; i < 1; ++i)
                for (int j = 0; j < 100; ++j)
                    h2_out[i, j] += h2b[i, j];
            h2_out = relu(h2_out);
            final_out = MatMul(h2_out, ow);
            for (int i = 0; i < 1; ++i)
                for (int j = 0; j < 100; ++j)
                    final_out[i, j] += ob[i, j];
            return Softmax(final_out);
        }

        public string GetResults(List<string> input_data)
        {
            string results = "";
            string printtext_BG = "在八纲辨证下的证候是";
            string printtext_BX = "在病性辨证下的证候是";
            string printtext_ZF = "在脏腑辨证下的证候是";
            string printtext_LJ = "在六经辨证下的证候是";
            string printtext_WQ = "在卫气营血辨证下的证候是";
            string printtext_SJ = "在三焦辨证下的证候是";

            float[] data = new float[input_data.Count()];
            int len = 0;
            foreach (string s in input_data)
            {
                foreach (KeyValuePair<string, float> kv in zhengzhuangid)
                {
                    if (s == kv.Key)
                    {
                        data[len++] = kv.Value;
                    }
                }
            }

            float[,] stddata = ToStdData(data);
            float[,] res_BG = model(stddata, BG_hidden1_weight, BG_hidden1_bias, BG_hidden2_weight, BG_hidden2_bias, BG_output_weight, BG_output_bias);
            float[,] res_BX = model(stddata, BX_hidden1_weight, BX_hidden1_bias, BX_hidden2_weight, BX_hidden2_bias, BX_output_weight, BX_output_bias);
            float[,] res_ZF = model(stddata, ZF_hidden1_weight, ZF_hidden1_bias, ZF_hidden2_weight, ZF_hidden2_bias, ZF_output_weight, ZF_output_bias);
            float[,] res_LJ = model(stddata, LJ_hidden1_weight, LJ_hidden1_bias, LJ_hidden2_weight, LJ_hidden2_bias, LJ_output_weight, LJ_output_bias);
            float[,] res_WQ = model(stddata, WQ_hidden1_weight, WQ_hidden1_bias, WQ_hidden2_weight, WQ_hidden2_bias, WQ_output_weight, WQ_output_bias);
            float[,] res_SJ = model(stddata, SJ_hidden1_weight, SJ_hidden1_bias, SJ_hidden2_weight, SJ_hidden2_bias, SJ_output_weight, SJ_output_bias);

            int ans = -1;
            float max_num = 0;
            bool isuse = false;


            for (int i = 0; i < res_BG.GetLength(1); i++)
            {
                if (res_BG[0, i] > max_num)
                {
                    max_num = res_BG[0, i];
                    ans = i;
                }
            }
            printtext_BG += zhenghouid[ans];
            string[] tempres_BG = tempstr[ans - 1].Split(',');
            List<float> res = new List<float>();
            for (int i = 0; i < tempres_BG.Length; i++)
                res.Add(zhengzhuangid[tempres_BG[i]]);
            for (int i = 0; i < input_data.Count(); i++)
            {
                if (res.Contains(zhengzhuangid[input_data[i]]))
                {
                    isuse = true;
                    break;
                }
            }

            if (isuse)
                results += printtext_BG + "\r\n" + "\r\n";
            isuse = false;

            ans = -1;
            max_num = 0;
            for (int i = 0; i < res_BX.GetLength(1); i++)
            {
                if (res_BX[0, i] > max_num)
                {
                    max_num = res_BX[0, i];
                    ans = i;
                }
            }
            printtext_BX += zhenghouid[ans];
            string[] tempres_BX = tempstr[ans - 1].Split(',');
            res.Clear();
            for (int i = 0; i < tempres_BX.Length; i++)
                res.Add(zhengzhuangid[tempres_BX[i]]);
            for (int i = 0; i < input_data.Count(); i++)
            {
                if (res.Contains(zhengzhuangid[input_data[i]]))
                {
                    isuse = true;
                    break;
                }
            }

            if (isuse)
                results += printtext_BX + "\r\n" + "\r\n";
            isuse = false;

            ans = -1;
            max_num = 0;
            for (int i = 0; i < res_ZF.GetLength(1); i++)
            {
                if (res_ZF[0, i] > max_num)
                {
                    max_num = res_ZF[0, i];
                    ans = i;
                }
            }
            printtext_ZF += zhenghouid[ans];
            string[] tempres_ZF = tempstr[ans - 1].Split(',');
            res.Clear();
            for (int i = 0; i < tempres_ZF.Length; i++)
                res.Add(zhengzhuangid[tempres_ZF[i]]);
            for (int i = 0; i < input_data.Count(); i++)
            {
                if (res.Contains(zhengzhuangid[input_data[i]]))
                {
                    isuse = true;
                    break;
                }
            }

            if (isuse)
                results += printtext_ZF + "\r\n" + "\r\n";
            isuse = false;


            ans = -1;
            max_num = 0;
            for (int i = 0; i < res_LJ.GetLength(1); i++)
            {
                if (res_LJ[0, i] > max_num)
                {
                    max_num = res_LJ[0, i];
                    ans = i;
                }
            }
            printtext_LJ += zhenghouid[ans];
            string[] tempres_LJ = tempstr[ans - 1].Split(',');
            res.Clear();
            for (int i = 0; i < tempres_LJ.Length; i++)
                res.Add(zhengzhuangid[tempres_LJ[i]]);
            for (int i = 0; i < input_data.Count(); i++)
            {
                if (res.Contains(zhengzhuangid[input_data[i]]))
                {
                    isuse = true;
                    break;
                }
            }

            if (isuse)
                results += printtext_LJ + "\r\n" + "\r\n";
            isuse = false;

            ans = -1;
            max_num = 0;
            for (int i = 0; i < res_WQ.GetLength(1); i++)
            {
                if (res_WQ[0, i] > max_num)
                {
                    max_num = res_WQ[0, i];
                    ans = i;
                }
            }
            printtext_WQ += zhenghouid[ans];
            string[] tempres_WQ = tempstr[ans - 1].Split(',');
            res.Clear();
            for (int i = 0; i < tempres_WQ.Length; i++)
                res.Add(zhengzhuangid[tempres_WQ[i]]);
            for (int i = 0; i < input_data.Count(); i++)
            {
                if (res.Contains(zhengzhuangid[input_data[i]]))
                {
                    isuse = true;
                    break;
                }
            }

            if (isuse)
                results += printtext_WQ + "\r\n" + "\r\n";
            isuse = false;

            ans = -1;
            max_num = 0;
            for (int i = 0; i < res_SJ.GetLength(1); i++)
            {
                if (res_SJ[0, i] > max_num)
                {
                    max_num = res_SJ[0, i];
                    ans = i;
                }
            }
            printtext_SJ += zhenghouid[ans];
            string[] tempres_SJ = tempstr[ans - 1].Split(',');
            res.Clear();
            for (int i = 0; i < tempres_SJ.Length; i++)
                res.Add(zhengzhuangid[tempres_SJ[i]]);
            for (int i = 0; i < input_data.Count(); i++)
            {
                if (res.Contains(zhengzhuangid[input_data[i]]))
                {
                    isuse = true;
                    break;
                }
            }

            if (isuse)
                results += printtext_SJ + "\r\n" + "\r\n";
            isuse = false;
            return results;
        }
    }
}
