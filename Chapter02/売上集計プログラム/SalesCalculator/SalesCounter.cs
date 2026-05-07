using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCalculator {
    public class SalesCounter {
        private readonly List<Sale>_sales;

        //コンストラクタ
        public SalesCounter(List<Sale> sales) {
            _sales = sales;
        }

        //店舗別売上を求める
        public Dictionary<string,int> GetPerStoreSales() {
            Dictionary<string, int> dict = new Dictionary<string, int>();

            foreach(var sale in _sales) {
                if (dict.ContainsKey(sale.ShopName))
                    //すでに店舗名が辞書のキーに登録されている場合
                    dict[sale.ShopName] += sale.Amount;//売上を足しこみ
                else
                    //店舗名の登録がまだない場合
                    dict[sale.ShopName] += sale.Amount;//新規に売上を登録
            }
            return dict;
        }

        public static List<Sale> ReadSales(string filePath) {
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
