
namespace Exercise01 {
    public class Program {
        public static void Main(string[] args) {
            Console.WriteLine("Hello, World!");

            var songs = new Song[] {

                new Song("Let it be", "The Beatles", 243),
                new Song("Bridge Over Troubled Water", "Simon & Garfunkel", 293),
                new Song("Close To You", "Carpenters", 276),
                new Song("Honesty", "Billy Joel", 231),
                new Song("I Will Always Love You", "Whitney Houston", 273),

            };

            PrintSongs(songs);
        }

        public static void PrintSongs(Song[] songs) {
            foreach(var Song in songs) {
                Song[]=
                Console.WriteLine($"{Song.Title}{Song.ArtistName}{Song.Lenght}");
            }
        }
    }
}
