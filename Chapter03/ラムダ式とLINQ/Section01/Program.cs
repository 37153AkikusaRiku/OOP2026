using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace Section01 {
    internal class Program {


        static void Main(string[] args) {
            var cities = new List<string> {
                "Tokyo",
                "New Delhi",
                "Bangkok",
                "London",
                "Paris",
                "Berlin",
                "Canberra",
                "Hong Kong",
            };

            var exists = cities.Exists(s =>6<= s.Length && s.Contains('o') && s.EndsWith('n'));

            Console.WriteLine(exists);
            






            //var exists = cities.Exists(s => s[0] == 'T');//ある文字があるかどうか
            //var count = cities.Count(c => c[0] == 'T');//文字を数える
            //var find = cities.Find(c => c[0] == 'T');//特定の文字を探す
            //var findindex = cities.FindIndex(c => c[0] == 'T');
            //var findall = cities.FindAll(c => c[0] == 'T');
            //findall.ForEach(s => Console.WriteLine(s));

            //foreach (var item in findall) {
            //    Console.WriteLine(item);

            //}
            //Console.WriteLine(exists);

        }

    }
}
