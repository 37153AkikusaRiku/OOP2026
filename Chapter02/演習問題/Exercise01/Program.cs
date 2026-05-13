
namespace Exercise01 {
    public class Program {
        public static void Main(string[] args) {
            Console.WriteLine("Hello, World!");
            var songs = new List<Song>();
            //PrintIn();

            while (true) {


                Console.Write("曲名");
                string? title = Console.ReadLine();

                if (title == "end") { break; } else {

                    Console.Write("アーティスト名");
                    string? artistname = Console.ReadLine();

                    Console.Write("演奏時間");
                    int lenght = int.Parse(Console.ReadLine());

                    Song song = new Song(title, artistname, lenght);

                    songs.Add(song);
                }
            }
            PrintSongs(songs);
        }


        public static void PrintSongs(IEnumerable<Song> songs) {
            foreach (var Song in songs) {

                Console.WriteLine($"{Song.Title}{Song.ArtistName}{Song.Lenght / 60}:{Song.Lenght % 60:00}");
            }
        }
    }
}
