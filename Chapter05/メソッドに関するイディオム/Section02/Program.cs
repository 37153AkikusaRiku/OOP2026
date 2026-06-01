namespace Section02 {
    internal class Program {
        static void Main(string[] args) {

            DoSomeshing(100);
            DoSomeshing(100, "エラーです");
            DoSomeshing(100, "エラーです", 5);

        }

        public static void DoSomeshing(int num,string messeage="エラーじゃない",int retryCount=6) {
            //仮のコード 
            Console.WriteLine($"{num}{messeage}{retryCount}");
        }
    }
}
