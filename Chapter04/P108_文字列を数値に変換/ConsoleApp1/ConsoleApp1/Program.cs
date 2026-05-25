namespace ConsoleApp1 {
    internal class Program {
        static void Main(string[] args) {

            #region nullの判定
            string? name = null;

            if (name is null)
                Console.WriteLine("nameはnullです");
            #endregion

            #region null合体演算子
            string code = "12345";
            //GetMessage()メソッドの戻り値がnullだったら、
            //DefaultMessage()メソッドが実行される。
            var message = GetMessage(code) ?? DefaultMessage();
            Console.WriteLine(message);
            #endregion

            #region null合体代入演算子
            message = null;
            message ??= DefaultMessage();


            #endregion




            #region null条件演算子

            Sale? sale = new Sale {
                ShopName = "新宿店",
                PeoductCategory = "洋菓子",
                Amount = 523100,
            };
            Console.WriteLine(sale);
            sale = null;

            int? amount = sale?.Amount;
            Console.WriteLine("売上高:" + amount);


            #endregion

            #region ２つを入れ替える
            int a = 10;
            int b = 20;
            int c = 30;

            Console.WriteLine("入れ替え前");
            Console.WriteLine("a=" + a + "b=" + b);

            (b, a, c,int d) = (a, b, 999,55);

            //int box = a;
            //a = b;
            //b = a;


            Console.WriteLine("入れ替え後");
            Console.WriteLine("a=" + a + "b=" + b+"c="+c+"d="+d);

            #endregion

        }

        private static string? DefaultMessage() {
            return "DefaultMessage";
        }

        private static string? GetMessage(string code) {
            return "GetMessage";
        }

    }

    public class Sale {
        //店舗名
        public string ShopName { get; set; } = string.Empty;
        //商品カテゴリ
        public string PeoductCategory { get; set; } = string.Empty;
        //売り上げ高
        public int Amount { get; set; }
    }

}
