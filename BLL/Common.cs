using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL;

namespace BLL
{
    public class Common
    {
        public static List<string> GetNodesByEdges(List<Edge_displayName> listEdge)
        {
            List<string> list = new List<string>();
            foreach (Edge_displayName edge in listEdge)
            {
                string leftNode = edge.DB_ID_displayName;
                string rightNode = edge.HasEvent_displayName;
                if (!list.Contains(leftNode))
                {
                    list.Add(leftNode);
                }
                if (!list.Contains(rightNode))
                {
                    list.Add(rightNode);
                }
            }
            return list;
        }
    }
}
