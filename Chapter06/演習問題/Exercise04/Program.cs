using System.Threading.Channels;
using static System.Net.Mime.MediaTypeNames;

namespace Exercise04 {
    internal class Program {
        static void Main(string[] args) {
            var line = "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886";
            var cutWords = new char[] { '=',';' };
            var Words = line.Split(cutWords);
            string result = string.Join(" ", Words);
            //Console.WriteLine(result);

            for (int i = 0; i < Words.Length; i+=2) {
                Console.Write(ToJapanese(Words[i]));
                Console.WriteLine(":" + Words[i+1]);
            }

            //foreach (var word in Words) {
                
            //    Console.Write(ToJapanese(word));

            //    if (ToJapanese(word).Equals(word)) {
            //        Console.WriteLine("");
            //    }

            //}
            





        }
        static string ToJapanese(string key) {
            return key switch {
                "Novelist" => "作家",
                "BestWork" => "代表作",
                "Born" => "誕生年",
                _ => key
            };
            //古い書き方
            //switch (key) {
            //    case "Novelist":　
            //        return "作家";
            //    case "BestWork":
            //        return "代表作";
            //    case "Born":
            //        return "誕生年";
            //    default:
            //        return "引数keyは、正しい値ではありません";
            //}
        }
    }
}
