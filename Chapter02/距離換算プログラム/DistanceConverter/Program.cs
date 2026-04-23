using System.ComponentModel.Design;

using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;

namespace DistanceConverter
{
    internal class Program
    {
        public static object PrintMeterToFeet { get; private set; }
        static void Main(string[] args)
        {
            if (Error(args) != false)
            {
                if (args.Length >= 1 && args[0] == "-tom")
                {
                    PrintFeetToMeterList(int.Parse(args[1]), int.Parse(args[2]));
                }//メートルへの変換
                else if (args.Length >= 1 && args[0] == "-tof")
                {
                    PrintMeterToFeetList(int.Parse(args[1]), int.Parse(args[2]));//メートルからフィートへの変換
                }
            }
        }


        private static void PrintMeterToFeetList(int start, int stop)
        {
            //FeetConverter converter = new FeetConverter();
            for (int meter = start; meter <= stop; meter++)
            {
                double feet = FeetConverter.FromMeter(meter);
                Console.WriteLine($"{meter}m={feet:0.0000}ft");
            }
        }


        private static void PrintFeetToMeterList(int start, int stop)
        {
            //FeetConverter converter = new FeetConverter();
            for (int feet = start; feet <= stop; feet++)
            {
                double meter = FeetConverter.ToMeter(feet);
                Console.WriteLine($"{feet}ft={meter:0.0000}m");
            }

        }

        //static double FeetToMeter(int feet)//フィートからメートルを求める
        //{
        //    //feet*0.3048
        //    return feet * 0.3048;
        //}

        ////メートルからフィートを求める
        //static double MeterToFeet(int meter)
        //{
        //    //feet*0.3048
        //    return meter / 0.3048;
        //}

        static Boolean Error(String[] args)
        {
            if (args[0] != "-tom" && args[0] != "-tof")
            {
                Console.WriteLine("Error1:未知の引数です");

                if (args.Length != 3)
                {
                    Console.WriteLine("Error2:引数が3つではありません");

                    if (int.TryParse(args[1], out int start) || int.TryParse(args[2], out int stop)) { }
                    else
                    {
                        Console.WriteLine("Error3:数値に変換できません");
                        return false;
                    }

                    return false;
                }

                return false;
            }

            return true;


        }


    }

}


