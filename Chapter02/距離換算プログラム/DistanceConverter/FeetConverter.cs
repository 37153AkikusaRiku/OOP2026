using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter
{
    internal static class FeetConverter
    {
        private static readonly double ratio = 0.3048;//定数
        public static double FromMeter(int meter)//メートルからフィートを求める
        {
            //feet*0.3048
            return meter / ratio;
        }


        public static double ToMeter(int feet)//フィートからメートルを求める
        {
            return feet * ratio;
        }
    }
}
