namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            double tei = .0254;//定数
            InchConverter inchConverter = new InchConverter();

            for (int con=1; con < 11; con++) {
                InchConverter.Convert(con, tei);
            }
           
            }



        }
    }
}
