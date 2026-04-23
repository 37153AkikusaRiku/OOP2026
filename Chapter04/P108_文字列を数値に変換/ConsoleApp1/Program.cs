namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var str = "1234";

            // --- 1. TryParse を使う方法 ---
            // 変換に失敗してもエラーで止まらないため、推奨される方法です。
            if (int.TryParse(str, out int height))
            {
                Console.WriteLine(height + ":変換成功");
            }
            else
            {
                Console.WriteLine("変換できません");
            }


            // --- 2. int.Parse と try-catch を使う方法 ---
            // Parseで変換する場合は例外処理が必要となる
            try
            {
                int num = int.Parse(str);
                Console.WriteLine(num + ":変換成功（Parse）");
            }
            catch (Exception)
            {
                Console.WriteLine("変換できません");
            }
        }
    }

}