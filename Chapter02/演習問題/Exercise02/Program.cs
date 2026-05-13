namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            PrintFeetToMeterList(1, 10);
           
        }
        private static void PrintFeetToMeterList(int start, int stop) {
            //FeetConverter converter = new FeetConverter();
            for (int feet = start; feet <= stop; feet++) {
                double meter = InchConverter.ToMeter(feet);
                Console.WriteLine($"{feet}inch={meter:0.0000}m");
            }

        }


        }

    }