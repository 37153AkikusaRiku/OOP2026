
namespace Exercise02 {
    internal class Program {

        static void Main(string[] args) {
            string text = "Cozy lummox gives smart squid who asks for job pen";
            Console.WriteLine("問題8-1-1");
            Exercise1(text);
            Console.WriteLine("問題8-1-2");
            Exercise2(text);


        }
        //8-1-1
        private static void Exercise1(string text) {
            var dict = new Dictionary<char, int>();
            string bigtext = text.ToUpper();
            
            
            foreach (var item in bigtext) {
                if (item.ToString()==" ") {
                    continue;
                }
                if (dict.ContainsKey(item))
                    dict[item] += 1;
                else
                    dict[item] = 1;
            }
            foreach (var item in dict.OrderBy(n=>n.Key)) {
                Console.WriteLine(item);
            }
        }

        private static void Exercise2(string text) {

        }
    }
}
