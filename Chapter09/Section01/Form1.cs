using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Section01 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e) {

        }

        private void getBtn_Click(object sender, EventArgs e) {
            
            DateTime dates = dtpDate.Value;
            DateTime date = new DateTime(dates.Year, dates.Month, dates.Day);
            var bars = dtp2.Value;
            var nawbars = new DateTime(date.Year, bars.Month, bars.Day);
            //var bars = new DateTime(2006, 8, 6);



            outTb.Text = "‚ ‚È‚½‚Í" + GetAge(bars, date) + "Î‚Å‚·";
            textBox1.Text = "" + (date - bars).Days;
            tb3.Text = "¶‚Ü‚ê‚½" + bars.ToString("MMŒdd“ú") + "‚Í" + NthWeek(bars).ToString("‘æ##T‚Ì") + Weekch(bars) + "‚Å‚·";



            if ((date - nawbars).Days < 0) {
                tb4.Text = ((nawbars - date).Days).ToString();
            } else if ((date - nawbars).Days >0) {
                tb4.Text = (365 - (date - nawbars).Days).ToString();
            } else if(date==nawbars){
                tb4.Text = "¡“ú‚ª’a¶“úII";
            }
        }

        static string Weekch(DateTime bars) {
            switch (bars.DayOfWeek) {
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


        static int NthWeek(DateTime date) {
            var firstDay = new DateTime(date.Year, date.Month, 1);
            var firstDayOfWeek = (int)(firstDay.DayOfWeek);
            return (date.Day + firstDayOfWeek - 1) / 7 + 1;
        }


        static int GetAge(DateTime birthday, DateTime targetDay) {
            var age = targetDay.Year - birthday.Year;
            if (targetDay < birthday.AddYears(age)) {
                age--;
            }
            return age;
        }

        static int NextBars(DateTime bars,DateTime date) {
            return date.Day - bars.Day;
        }


    }
}