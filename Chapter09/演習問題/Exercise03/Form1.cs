namespace Exercise03 {
    public partial class Form1 : Form {
        TimeWatch tw;

        public Form1() {
            InitializeComponent();
        }

        private void btStart_Click(object sender, EventArgs e) {
            tw = new TimeWatch();
            tw.Start();
            
        }

        private void btStop_Click(object sender, EventArgs e) {
            tw.Stop();
            TimeSpan duration = tw.Stop();
            lbTimeDisp.Text = $"{duration.TotalSeconds}•b";
        }
    }
}

internal class TimeWatch {
    private DateTime _time;
    

    public void Start() {
      _time  = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
        
        

    }

    public TimeSpan Stop() {
        var stopTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

        return stopTime - _time;
    }
}
