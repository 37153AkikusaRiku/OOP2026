using Section01;
using System.Text;    //Section01プロジェクトにあるBookクラスを利用

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            var books = new List<Book> {
                new Book { Title = "C#プログラミングの新常識", Price = 3800, Pages = 378 },
                new Book { Title = "ラムダ式とLINQの極意", Price = 2500, Pages = 312 },
                new Book { Title = "ワンダフル・C#ライフ", Price = 2900, Pages = 385 },
                new Book { Title = "一人で学ぶ並列処理プログラミング", Price = 4800, Pages = 464 },
                new Book { Title = "フレーズで覚えるC#入門", Price = 5300, Pages = 604 },
                new Book { Title = "私でも分かったASP.NET Core", Price = 3200, Pages = 453 },
                new Book { Title = "楽しいC#プログラミング教室", Price = 2540, Pages = 348 },
            };
            #region
            Console.WriteLine("\n7.2.1");
            Exercise1(books);

            Console.WriteLine("\n7.2.2");
            Exercise2(books);

            Console.WriteLine("\n7.2.3");
            Exercise3(books);

            Console.WriteLine("\n7.2.4");
            Exercise4(books);

            Console.WriteLine("\n7.2.5");
            Exercise5(books);

            Console.WriteLine("\n7.2.6");
            Exercise6(books);

            Console.WriteLine("\n7.2.7");
            Exercise7(books);
            #endregion
        }

        private static void Exercise1(List<Book> books) {
            var selctBook = books.Find(n => n.Title==("ワンダフル・C#ライフ"));

            Console.WriteLine("価格"+selctBook.Price+"ページ数"+selctBook.Pages);
        }

        private static void Exercise2(List<Book> books) {
            //var whCntBook = books.Where(n => n.Title.Contains("C#")).Count();
            //Console.WriteLine(whCntBook);

            var whCntBook = books.Count(n => n.Title.Contains("C#"));
            Console.WriteLine(whCntBook);

        }

        private static void Exercise3(List<Book> books) {
            //var whCntBook = books.Where(n => n.Title.Contains("C#"));
            //var avBook = 0;
            //foreach (var item in whCntBook) {
            //    avBook += item.Pages;
            //}
            //Console.WriteLine(avBook/whCntBook.Count());
            var whCntBook = books.Where(n => n.Title.Contains("C#")).Average(n=>n.Price);
            Console.WriteLine(whCntBook);

        }

        private static void Exercise4(List<Book> books) {
            var hgitBook = books.Find(n => n.Price >= 4000);
            Console.WriteLine(hgitBook.Title);
        }

        private static void Exercise5(List<Book> books) {
            var hgitBook = books.Where(n => n.Price < 4000);
            var maxPagesBook = hgitBook.Max(n=>n.Pages);
            Console.WriteLine(maxPagesBook);
        }

        private static void Exercise6(List<Book> books) {
            var hgitBook = books.OrderByDescending(n=>n.Price).Where(n => n.Pages <= 400);
            foreach (var item in hgitBook) {
                Console.WriteLine("タイトル"+item.Title+"価格"+item.Price);
            }
        }

        private static void Exercise7(List<Book> books) {
            var whCntBook = books.Where(n => n.Title.Contains("C#"));
            var whCntBook2 = whCntBook.Where(n => n.Pages <= 500);
            foreach (var item in whCntBook2) {
                Console.WriteLine(item.Title);
            }
        }
    }
}
