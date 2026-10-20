using System.Diagnostics;

namespace Section03 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            //Thread.Sleep(5000);
            //MessageBox.Show("Š®—¹");

            //await Task.Delay(5000);
            //MessageBox.Show("Š®—¹");

            var elapsed = DoLongTimeWork(5000);
            MessageBox.Show(elapsed + "ƒ~ƒŠ•b");

        }
        //–ß‚è’l‚È‚µ
        private async Task DoLongTimeWork() {
            await Task.Run(() => {
                Thread.Sleep(5000);
            });
        }

        //–ß‚è’l‚ ‚è
        private long DoLongTimeWork(int milliseconds) {
            var sw = Stopwatch.StartNew();

            Thread.Sleep(milliseconds);

            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

    }
}
