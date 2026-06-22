namespace SalesCalculator {
    internal class Program {
        static void Main(string[] args) 
            {
            //var sales = new SalesCounter(SalesCounter.ReadSales(@"data\sales.csv"));

            var sales = new SalesCounter((@"data\sales.csv"));
            var amountPerStore =  (sales.GetDict());
            foreach(KeyValuePair<string,int>obj in amountPerStore) {
                Console.WriteLine($"{obj.Key}{obj.Value}");
            }
        }


        static List<Sale> ReadSales(string filePath) {
            List<Sale> sales = new List<Sale>();//リスト
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines) {
                string[] items = line.Split(',');
                Sale sale = new Sale {
                    ShopName = items[0],
                    PeoductCategory = items[1],
                    Amount = int.Parse(items[2]),
                };
                sales.Add(sale);

            }

            return sales;
        }


    }
}
