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


            outTb.Text = "Ç†Ç»ÇΩÇÕ" + (date - date2).Days / 365 + "çŒÇ≈Ç∑";



        }

        private void getBtn2_Click(object sender, EventArgs e) {
            DateTime date = dtpDate.Value;
            DateTime date2 = dtp2.Value;
            textBox1.Text = "" + (date - date2).Days;

        }

        private void dtp2_ValueChanged(object sender, EventArgs e) {

        }
    }
}