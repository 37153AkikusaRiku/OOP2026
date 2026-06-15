
using System.Text;

namespace Exercise03 {
    internal class Program {
        static void Main(string[] args) {

            var text = "Jackdaws love my big sphinx of quartz";
            #region
            Console.WriteLine("6.3.1");
            Exercise1(text);

            Console.WriteLine("6.3.2");
            Exercise2(text);

            Console.WriteLine("6.3.3");
            Exercise3(text);

            Console.WriteLine("6.3.4");
            Exercise4(text);

            Console.WriteLine("6.3.5");
            Exercise5(text);

            Console.WriteLine("6.3.99");
            Exercise6(text);
            #endregion
        }

        private static void Exercise1(string text) {
            int spaceCount = text.Count(c => c == ' ');
            Console.WriteLine(spaceCount);
        }

        private static void Exercise2(string text) {
            string result = text.Replace("big", "small");

            Console.WriteLine(result);
        }

        private static void Exercise3(string text) {
            var shortWords = text.Split(' ');

            var sb = new StringBuilder();
            foreach (var word in shortWords) {
                if (sb.Length > 0) {
                    sb.Append(" ");
                }
                sb.Append(word);
            }
            Console.WriteLine(sb + ".");

            string result = string.Join(" ", shortWords);
            Console.WriteLine(result + ".");




        }

        private static void Exercise4(string text) {
            int spaceCount = text.Count(c => c == ' ');
            Console.WriteLine(spaceCount + 1);
        }

        private static void Exercise5(string text) {
            var shortWords = text.Split(' ')
                                        .Where(word => word.Length <= 4);

            foreach (var word in shortWords) {
                Console.WriteLine(word);
            }
        }

        public static void Exercise6(string text) {
            var str = text.ToLower().Replace(" ", "　");//小文字にする、空白をなくす

            //////ディクショナリ   
            //var alphDicCount = Enumerable.Range('a', 26).
            //    ToDictionary(num => ((char)num),num => 0);


            ////var dict = new SortedDictionary<char, int>();

            //foreach (var c in str) {
            //    if (alphDicCount.ContainsKey(c))
            //        //すでに店舗名が辞書のキーに登録されている場合
            //        alphDicCount[c]++;
            //    else
            //        //店舗名の登録がまだない場合
            //        alphDicCount[c] = 1;
            //    foreach (var word in alphDicCount) {
            //        Console.WriteLine(word.Key + ";" + word.Value);
            //    }
            //}

            ////配列を用いた集計
            //var array = Enumerable.Repeat(0, 26).ToArray();
            ////foreach (var alph in str) {
            ////    array[alph - 'a']++;
            ////}
            ////for (char ch = 'a'; ch <= 'z'; ch++) {
            ////    Console.WriteLine($"{ch}:{array[ch - 'a']}");
            ////}
            ////foreach (var num in array) {

            ////}

            ////'a'から順にカウントして集計
            //for (char ch = 'a'; ch <= 'z'; ch++) {
            //    Console.WriteLine($"{ch}:{text.Count(c=>c==(ch))}");
            //}



        }
    }
}
