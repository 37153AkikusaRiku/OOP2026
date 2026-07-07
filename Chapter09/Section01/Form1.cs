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
            DateTime date = dtpDate.Value;
            DateTime date2 = dtp2.Value;
            DateTime bars = dtp2.Value;

            outTb.Text = "‚ ‚È‚½‚Í" + GetAge(date2, date) + "Î‚Å‚·";
            textBox1.Text = "" + (date - date2).Days;

            
            tb3.Text = "¶‚Ü‚ê‚½" + bars.ToString("MMŒdd“ú") + "‚Í" +NthWeek(bars).ToString("‘æ##T‚Ì")+Weekch(bars)+"‚Å‚·";

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
    }
}