namespace Exercise03 {
    //クラスの定義（ToString()を定義していない）
    internal class Program {
        static void Main(string[] args) {
            var ym1 = new YearMonth(2002, 10);
            var ym2 = new YearMonth(2002, 10);

            if (ym1==ym2) {
                Console.WriteLine("等しい");
            } else { Console.WriteLine("等しくない"); }

        }


    }
}
