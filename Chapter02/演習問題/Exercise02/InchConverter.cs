using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    internal class InchConverter {

        private static readonly double ratio = 0.0254;//定数
        public static double FromMeter(int meter)
            //メートルからインチを求める
        {
            //feet*0.3048
            return meter / ratio;
        }


        public static double ToMeter(int feet)
            //インチからメートルを求める
        {
            return feet * ratio;
        }










        //public static double Convert(int con,double tei){
        //    return con * tei;
        //    }


    }
}
