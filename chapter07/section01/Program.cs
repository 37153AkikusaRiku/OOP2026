using Section01;

namespace section01 {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello, World!");

            var numbers = Enumerable.Repeat(1, 20).ToList();//1で埋めてる    
            var numberss = Enumerable.Range(1, 20).ToList();//連続した値で埋めてる    

            var numbersss = new List<int> { 9, 7, 5, 4, 2, 5, 4, 0, 4, 1, 0, 4 };
            var average = numbersss.Average();
            Console.WriteLine("平均:"+average);

            var books = Books.GetBooks();
            var averagee = books.Average(x => x.Price);
            var pageaveragee = books.Sum(x => x.Pages);
            var maxPrice = books.Max(x => x.Price);
            var highPrice = books.Where(x => x.Price >= 500);
            

            Console.WriteLine("平均価格:" + averagee);
            Console.WriteLine("合計ページ:"+pageaveragee);
            Console.WriteLine("高価な本:" + maxPrice);

            Console.WriteLine("===500円以上の本===");
            foreach (var item in highPrice) { 
                Console.WriteLine( item.Title);

            }

            //本のページが２５０ページ以上の本を上位３冊
            Console.WriteLine("===本のページが２５０ページ以上の本を上位３冊===");
            var HighPages = books.Where(x => x.Pages >= 250).Take(3);
            foreach (var item in HighPages) {
                Console.WriteLine(item.Title);

            }

        }
    }
}
