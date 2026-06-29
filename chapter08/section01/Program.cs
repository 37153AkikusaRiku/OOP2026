using System.Threading.Channels;

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

                if (prefOfficeDict.ContainsKey(pref)) {
                    Console.WriteLine("上書きする？");
                    if (Console.ReadLine()=="N") {
                        continue;
                    }
                }


            }

            foreach (var item in prefOfficeDict) {
                Console.WriteLine(item.Key + item.Value);
            }
            menu();
        }



            static void menu() {
                while (true) {
                    Console.WriteLine("＊＊＊メニュー＊＊＊");
                    Console.WriteLine("1：一覧表示　2：検索　9：終了");
                    int result = int.Parse(Console.ReadLine());
                    switch (result) {

                        case 1:
                            vaw(prefOfficeDict);
                            break;
                        //foreach (var item in prefOfficeDict) {
                        //    Console.WriteLine(item.Key + item.Value);
                        //}
                        //break;

                        case 2:
                            findVaw(prefOfficeDict);
                            break;
                        //Console.Write("検索：");
                        //var ch = Console.ReadLine();
                        //foreach (var item in prefOfficeDict) {
                        //    if (item.Key == ch) {
                        //        Console.WriteLine(item);
                        //        break;
                        //    }
                        //    Console.WriteLine("ぶきないよっ！");
                        //}
                        //break;

                        case 9:
                            break;
                    }

                }

            }





            static void vaw(Dictionary<string, string> prefOfficeDict) {
                foreach (var item in prefOfficeDict) {
                    Console.WriteLine("都道府県:" + item.Key + "県庁:" + item.Value);

                }
            }

            static void findVaw(Dictionary<string, string> prefOfficeDict) {
                Console.Write("検索：");
                var ch = Console.ReadLine();
                
                

                foreach (var item in prefOfficeDict) {
                    if (item.Key == ch) {
                        Console.WriteLine("都道府県:" + item.Key + "県庁:" + item.Value);
                        break;
                    }
                    
                }
            }
        }
    }

    

