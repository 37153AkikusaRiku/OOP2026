using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    //売り上げクラス
    public class Song {
        //タイトル
        public string Title { get; set; } = string.Empty;
        //名前
        public string ArtistName { get; set; } = string.Empty;
        //なにこれ
        public int Lenght { get; set; }
        //コンストラクタ
        public Song(string　Title,string ArtistName,int Lenght) {
            this.Title = Title;
            this.ArtistName = ArtistName;
            this.Lenght = Lenght;
        }
        //店舗別売上を求める
        public IDictionary<string, int> GetPerStoreSales() {
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

    }
}
