using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
     public  class Model
    {
         private int modelId;
         private string modelName;

         public int ModelId
         {
             get { return modelId;}
             set { modelId = value; }
         }
         public string ModelName
         {
             get { return modelName; }
             set { modelName = value; }
         }
    }
}
