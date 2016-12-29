using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL;
using DAL;

namespace BLL
{
    public class SyndromsBLL
    {
        private SyndromsDAL syn_pre = new SyndromsDAL();

        public string GetResults(List<string> input)
        {
            return syn_pre.GetResults(input);
        }

        public float[,] model(float[,] data, float[,] h1w, float[,] h1b, float[,] h2w, float[,] h2b, float[,] ow, float[,] ob)
        {
            return syn_pre.model(data, h1w, h1b, h2w, h2b, ow, ob);
        }

        public float[,] relu(float[,] data)
        {
            return syn_pre.relu(data);
        }

        public float[,] Softmax(float[,] data)
        {
            return syn_pre.Softmax(data);
        }

        public float[,] MatMul(float[,] a, float[,] b)
        {
            return syn_pre.MatMul(a, b);
        }

        public float[,] ToStdData(float[] data)
        {
            return syn_pre.ToStdData(data);
        }

        public void GetDataXuhaoToZhengzhuang()
        {
            syn_pre.GetDataXuhaoToZhengzhuang();
        }

        public void GetDataZhenghouToXuhao()
        {
            syn_pre.GetDataZhenghouToXuhao();
        }

        public void GetDataZhengzhuangToId()
        {
            syn_pre.GetDataZhengzhuangToId();
        }
    }

}
