using System.Text;

namespace section01 {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello, World!");

            var sb = new StringBuilder();
            foreach (var word in GetWords()) {
                if (sb.Length > 0) {
                    sb.Append(",");
                }
                sb.Append(word);
            }

            string result = string.Join(",", GetWords());

            Console.WriteLine(result);
            Console.WriteLine(sb);
        }

        //メソッドではなく一つのオブジェクト 
        private static IEnumerable<object> GetWords() {
            return ["Orange", "Lemon", "Strawberry"];
        }

    }
}

