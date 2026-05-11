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
        public Song(string　title,string artistName,int lenght) {
            Title = title;
            ArtistName = artistName;
            Lenght = lenght;
        }

    }
}
