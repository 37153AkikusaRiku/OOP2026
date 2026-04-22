using System.Diagnostics.Metrics;

namespace DistanceConverter
{
    internal class Program
    {
        static void Main(string[] args){
            if (args.Length >= 1 && args[0] == "-tom") {
                PrintFFeetToMeterList(1, 10);
            }
            else
            {
                for (int a = 0; a <=10 ; a++)
                {
                    double feet = MeterToFeet(a+1);
                    Console.WriteLine($"{a + 1}ft={a:0.000}ft");

                }
            }
        }

        static void PrintFFeetToMeterList(int start, int stop)
        {
            //フィールドからメールへの対応表を出力
            for (int i = 0; i < 10; i++)
            {
                double meter = FeetToMeter(i + 1);
                Console.WriteLine($"{i + 1}ft={meter:0.000}m");//$と{}で文字列の中に変数などを入れれる
            }
        }

        static double FeetToMeter(int i){
            return i * 0.3048;
        }
        static double MeterToFeet(int a)
        {
            return a/ 0.3048;
        }
    }
}
