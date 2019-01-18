using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ.classes
{
   public class Feature
    {
        public string type { get; set; }
        public Geometry geometry { get; set; }
        public Properties properties { get; set; }
        public object ObjectID { get; internal set; }
    }
}
