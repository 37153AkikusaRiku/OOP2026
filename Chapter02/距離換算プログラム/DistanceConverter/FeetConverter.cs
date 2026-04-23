using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter
{
    internal static class FeetConverter
    {
        public static double FromMeter(int meter)//メートルからフィートを求める
        {
            //feet*0.3048
            return meter / 0.3048;
        }


        public static double ToMeter(int feet)//フィートからメートルを求める
        {
            //feet*0.3048
            return feet * 0.3048;
        }
    }
}
