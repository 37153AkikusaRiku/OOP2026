using System.Globalization;

namespace Exercise01 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e) {
            var ToDay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            outputTextBox1.Text = $"{ToDay.ToString("yyyy/MM/dd HH:mm")}";
        }

        private void outputBt2_Click(object sender, EventArgs e) {
            var ToDay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            outputTextBox2.Text = $"{ToDay.ToString("yyyy”NMMŒdd“úHHmm•ªss•b")}";
        }

        private void outputBt3_Click(object sender, EventArgs e) {
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();

            var ToDay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

            outputTextBox3.Text = $"{ToDay.ToString("g y”N MMŒ dd“ú", culture)}{Weekch(ToDay)}";
        }


        static string Weekch(DateTime week) {
            switch (week.DayOfWeek) {
                case DayOfWeek.Sunday:
                    return "“ú—j“ú";

                case DayOfWeek.Monday:
                    return "Œ—j“ú";

                case DayOfWeek.Tuesday:
                    return "‰Î—j“ú";

                case DayOfWeek.Wednesday:
                    return "…—j“ú";

                case DayOfWeek.Thursday:
                    return "–Ø—j“ú";

                case DayOfWeek.Friday:
                    return "‹à—j“ú";

                case DayOfWeek.Saturday:
                    return "“y—j“ú";

                default:
                    return "";

            }
        }
    }
}