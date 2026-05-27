
namespace Chapter01 {
    internal class Program {
        static void Main(string[] args) {
            List<string> langs = [
                "C#", "Java", "Ruby", "PHP", "Python", "TypeScript",
  
                "JavaScript", "Swift", "Go",
            ];

            Exercise1(langs);
            Console.WriteLine("---");
            Exercise2(langs);
            Console.WriteLine("---");
            Exercise3(langs);
        }

        private static void Exercise1(List<string> langs) {

            //var select = langs.Select(a => a = langs.Where(c => c.Contains('o'));

            var where = langs.Where(c => c.Contains('S')).ToList();

            //foreach文
            Console.WriteLine("foreach文で出力");
            foreach (var item in where) {
                Console.WriteLine(item);
            }
            //for文
            Console.WriteLine("\nfor文で出力");
            
            for (int i = 0; i < where.Count(); i++) {


                Console.WriteLine(where[i]);
            }

            //while文
            Console.WriteLine("\nwhile文で出力");
            int a = 0;
            while (true) {
                
                Console.WriteLine(where[a]);
                a = a+1;
                if (a == where.Count()) { break; }

            }

        }

        private static void Exercise2(List<string> langs) {
            
        }

        private static void Exercise3(List<string> langs) {

        }
    }
}
