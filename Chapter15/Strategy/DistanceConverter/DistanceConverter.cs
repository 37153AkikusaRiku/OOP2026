using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter;
public class DistancConverter {
    public ConverterBase From { get; init; }
    public ConverterBase To { get; init; }


    //コンストラクタ  
    public DistancConverter(ConverterBase form,ConverterBase to) {
        From = form;
        To = to;
    }

    public double Convert(double value) {
        var meter = From.ToMeter(value);//メートルへ変換
        return To.FromMeter(meter);//メートルからそれぞれの単位へ変換
    }

}