using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCalculator {
    public class SalesCounter {
        private readonly IEnumerable<Sale>_sales;

        //コンストラクタ
        public SalesCounter(string filePath) {
            _sales = ReadSales(filePath);
        }

        public Dictionary<string, int> GetDict() {
            return new Dictionary<string, int>();
        }

        //店舗別売上を求める
        public IDictionary<string,int> GetPerStoreSales() {
            var dict = new SortedDictionary<string, int>();
            foreach (var sale in _sales) {
                if (dict.ContainsKey(sale.ShopName))
                    //すでに店舗名が辞書のキーに登録されている場合
                    dict[sale.ShopName] += sale.Amount;//売上を足しこみ
                else
                    //店舗名の登録がまだない場合
                    dict[sale.ShopName] += sale.Amount;//新規に売上を登録
            }
            return dict;
        }

        public IEnumerable<Sale> ReadSales(string filePath) {
            var sales = new List<Sale>();//リスト
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines) {
                var items = line.Split(',');
                var sale = new Sale {
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
