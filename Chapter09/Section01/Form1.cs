using System.Globalization;

namespace Section01 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e) {

        }

        private void getBtn_Click(object sender, EventArgs e) {
            var dt1 = dtpDate.Value;
            DayOfWeek dayOfWeek = dt1.DayOfWeek;
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var strDate = dt1.ToString("ggyy”NMŒŽd“ú", culture);
            outTb.Text = strDate;



        }
    }
}