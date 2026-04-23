using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter
{
    internal class FeetConverter
    {


        //メートルからフィートを求める

        public double FromMeter(int meter)
        {

            //feet*0.3048

            return meter / 0.3048;

        }
        public double ToMeter(int feet)//フィートからメートルを求める

        {

            //feet*0.3048

            return feet * 0.3048;

        }
    }
}
