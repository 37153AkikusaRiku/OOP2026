using System.Collections.Immutable;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            var obj = new PasswordPolicy("aaaaa", ("bbbbb"));
            //obj.GivenName = "ccccc";

            var ms = new MySaple();
            //変更不可のオブジェクトなので、add、removeatは新たなインスタンスを返す
            var newList = ms.MyList.Add(6).RemoveAt(0);
            ms.MyList.ForEach(n => Console.WriteLine($"{n}"));
            Console.WriteLine();

            newList.ForEach(n => Console.WriteLine($"{n}"));
            Console.WriteLine();



            //var data = obj.Name;

            //var ms = new MySaple();
            //ms.MyList.Add(6);
            //ms.MyList.RemoveAt(0);
            //ms.MyList[0] =10;

            foreach (var n in ms.MyList) {
                Console.WriteLine(n);
            }

            //ms.MyList = new List<int>();

        }
    }

    class MySaple {
        public ImmutableList<int> MyList { get; private set; }

        public MySaple() {
           var list = new List<int>() { 1, 2, 3, 4, 5 };
            MyList = list.ToImmutableList();
        }
    }

    class PasswordPolicy {
        //プロパティーの初期化
        public int MinimumLength { get; set; } = 8;

        //読み取り専用
        public string GivenName { get; private set; } = null!;
        public string FamilyName { get; private set; } = null!;


        ////getアクセサーのみを定義した読み取り専用プロパティ
        //public string Name {
        //    get { return FamilyName + " " + GivenName; }
        //}

        public string Name => FamilyName + " " + GivenName;

        



        //public void abc() {
        //    GivenName = "ffffff";
        //}
    }

}
