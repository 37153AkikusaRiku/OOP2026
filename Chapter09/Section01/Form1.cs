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

            if (DateTime.IsLeapYear(dt1.Year)) {
                outTb.Text = "‚¤‚é‚¤”N";
            } else {
                outTb.Text = "‚¤‚é‚¤”N‚¶‚á‚È‚¢";
            }

            switch (dayOfWeek) {
                case DayOfWeek.Sunday:
                    outTb.Text = "“ú—j“ú";
                    break;
                case DayOfWeek.Monday:
                    outTb.Text = "Œ—j“ú";
                    break;
                case DayOfWeek.Tuesday:
                    outTb.Text = "‰Î—j“ú";
                    break;
                case DayOfWeek.Wednesday:
                    outTb.Text = "…—j“ú";
                    break;
                case DayOfWeek.Thursday:
                    outTb.Text = "–Ø—j“ú";
                    break;
                case DayOfWeek.Friday:
                    outTb.Text = "‹à—j“ú";
                    break;
                case DayOfWeek.Saturday:
                    outTb.Text = "“y—j“ú";
                    break;
                default:
                    break;
            }
        }
    }
}
