namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            var box = Console.ReadLine();
            var changeint = int.Parse(box);
            string changestr = changeint.ToString("#,0");

            Console.WriteLine(changestr);
        }
    }
}
