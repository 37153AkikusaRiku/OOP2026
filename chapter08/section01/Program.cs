namespace section01 {
    internal class Program {
        static private Dictionary<string, string> prefOfficeDict = new Dictionary<string, string>();

        static void Main(string[] args) {
            string? pref, prefCaptalLocation;

            Console.WriteLine("県庁所在地の登録【入力終了：Ctrl＋Z】");

            while (true) {
                Console.Write("都道府県：");
                pref = Console.ReadLine();
                if (pref == null) break;

                Console.Write("県庁所在地：");
                prefCaptalLocation = Console.ReadLine();
                if (prefCaptalLocation == null) break;

                prefOfficeDict.Add(pref, prefCaptalLocation);

            }

            foreach (var item in prefOfficeDict) {
                Console.WriteLine(item.Key + item.Value);
            }
            Console.WriteLine("＊＊＊メニュー＊＊＊");
            Console.WriteLine("1：一覧表示　2：検索　9：終了");





            int result = int.Parse(Console.ReadLine());
           
                switch (result) {
                    case 1:
                        foreach (var item in prefOfficeDict) {
                            Console.WriteLine(item.Key + item.Value);
                            
                        }
                        break;
                    case 2:
                        Console.Write("検索：");
                        var ch = Console.ReadLine();
                        foreach (var item in prefOfficeDict) {
                            if (item.Key == ch) {
                                Console.WriteLine(item);
                                break;
                            }
                            Console.WriteLine("ぶきないよっ！");
                        }

                        break;
                    case 9:break;
                }

            
            //1 => vaw(prefOfficeDict)
            //    2 =>findVaw(prefOfficeDict),
            //    3=>"終了",
            //    _ => "erarr"
            //}; 





            //static string vaw(Dictionary<string, string> prefOfficeDict) {
            //    foreach (var item in prefOfficeDict) {
            //        return "都道府県" + item.Key + "県庁" + item.Value;

            //    }
            //    return "終了";
            //}

            //static string findVaw(Dictionary<string, string> prefOfficeDict) {
            //    var ch = Console.ReadLine();
            //    foreach (var item in prefOfficeDict) {
            //        if (item.Key == ch) {
            //             Console.WriteLine(item);
            //            return "";
            //        }


            //    }
            //    return "";
            //}

        }
    }
}
