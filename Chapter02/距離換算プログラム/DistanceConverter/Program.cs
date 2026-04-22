using System.ComponentModel.Design;

using System.Diagnostics.Metrics;

namespace DistanceConverter

{

    internal class Program

    {

        public static object PrintMeterToFeet { get; private set; }

        static void Main(string[] args)

        {

            if (args.Length >= 1 && args[0] == "-tom")

            {

                PrintFeetToMeterList(int.Parse(args[1]), int.Parse(args[2]));

            }//メートルへの変換

            else if (args.Length >= 1 && args[0] == "-tof")

            {

                PrintMeterToFeetList(int.Parse(args[1]), int.Parse(args[2]));//メートルからフィートへの変換

            }


            else

            {

                Console.WriteLine("因数エラー");
                Error(args.Length);
            }

        }


        private static void PrintMeterToFeetList(int start, int stop)

        {

            for (int meter = start; meter <= stop; meter++)

            {

                double feet = MeterToFeet(meter);

                Console.WriteLine($"{meter}m={feet:0.0000}ft");

            }

        }

        private static void PrintFeetToMeterList(int start, int stop)

        {

            for (int feet = start; feet <= stop; feet++)

            {

                double meter = FeetToMeter(feet);

                Console.WriteLine($"{feet}ft={meter:0.0000}m");

            }

        }

        static double FeetToMeter(int feet)//フィートからメートルを求める

        {

            //feet*0.3048

            return feet * 0.3048;

        }

        //メートルからフィートを求める

        static double MeterToFeet(int meter)

        {

            //feet*0.3048

            return meter / 0.3048;

        }
        static void Error(int cnt)
        {
            if (cnt != 3) Console.WriteLine("引数が3つではありません");


        }


    }

}


