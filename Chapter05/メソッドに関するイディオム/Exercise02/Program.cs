


using Section02;
using System.Security.Cryptography.X509Certificates;

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            // 5.2.1
            var ymCollection = new YearMonth[] {
                new YearMonth(1980, 1),
                new YearMonth(1990, 4),
                new YearMonth(2000, 7),
                new YearMonth(2010, 9),
                new YearMonth(2024, 12),
            };

            Console.WriteLine("5.2.2");
            Exercise2(ymCollection);


            Console.WriteLine("5.2.3");
            Exercise3(ymCollection);


            Console.WriteLine("5.2.4");
            Exercise4(ymCollection);
            
            

            Console.WriteLine("5.2.5");
            Exercise5(ymCollection);
        }

        

        private static void Exercise2(YearMonth[] ymCollection) {

            foreach (var item in ymCollection) {
                Console.WriteLine(item);
            }

        }


        private static YearMonth? FindFast(YearMonth[] ymCollection) {
             foreach (var item in ymCollection) {
                if (item.Is21Century) {
                    return item;
                } 
            }
            return null;
        }



        private static void Exercise3(YearMonth[] ymCollection) {

            Console.WriteLine( FindFast(ymCollection));

            

        }

        private static void Exercise4(YearMonth[] ymCollection) {
            var ym = FindFast(ymCollection);

            if (ym==null) {
                Console.WriteLine("ありません");
            } else { Console.WriteLine(ym); }

        }


        private static void Exercise5(YearMonth[] ymCollection) {

            foreach (var item in ymCollection) {
                Console.WriteLine( item.addOneMonth(item.Year, item.Month));

            }

        }
    }
}
