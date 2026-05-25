
namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            var cities = new List<string> {
                "Tokyo", "New Delhi", "Bangkok", "London",
                "Paris", "Berlin", "Canberra", "Hong Kong",
            };

            Console.WriteLine("***** 3.2.1 *****");
            Exercise2_1(cities);
            Console.WriteLine();

            Console.WriteLine("***** 3.2.2 *****");
            Exercise2_2(cities);
            Console.WriteLine();

            Console.WriteLine("***** 3.2.3 *****");
            Exercise2_3(cities);
            Console.WriteLine();

            Console.WriteLine("***** 3.2.4 *****");
            Exercise2_4(cities);
            Console.WriteLine();
        }

        private static void Exercise2_1(List<string> cities) {
            while (true) {
                var name = Console.ReadLine();
                var findindex = cities.FindIndex(s => s == name);
                Console.WriteLine(findindex);
                if (name=="") {
                    break;
                }
            }
        }

        private static void Exercise2_2(List<string> cities) {
            var count = cities.Count(c => c.Contains('o'));
            Console.WriteLine(count);
	        
        }

        private static void Exercise2_3(List<string> cities) {
            var where = cities.Where(c => c.Contains('o'));
            foreach (var item in where) {
                Console.WriteLine(item);
            }

        }

        private static void Exercise2_4(List<string> cities) {
            var where = cities.Where(s => s.StartsWith('B')).Select(s => new { s, s.Length });

            //var where = cities.Where(c => c.Contains('B'));
            
            foreach (var item in where) {
                Console.Write(item+",");
                Console.WriteLine(item.Length);

            }
        }
    }
}
