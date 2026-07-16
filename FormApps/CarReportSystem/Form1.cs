using System.ComponentModel;
using static CarReportSystem.CarReport;

namespace CarReportSystem {
    public partial class Form1 : Form {

        //カーレポート管理用リスト
        BindingList<CarReport> listCarReports = new BindingList<CarReport>();

        public Form1() {
            InitializeComponent();
            dgvRecords.DataSource = listCarReports;
        }
        //追加ボタンイベントハンドラ
        private void btAddRecord_Click(object sender, EventArgs e) {

            tsslb.Text = string.Empty;//メッセージクリア

            //記録者と車名が未記入だった場合は追加しない
            if (cbAuthor.Text == string.Empty || cbCarName.Text == string.Empty) {
                tsslb.Text = "記録者、または車名が未記入です";
                return;
            }

            var carReport = new CarReport {
                Date = dtpDate.Value,
                Author = cbAuthor.Text,
                CarName = cbCarName.Text,
                Meker = getRadioButttonMaker(),
                Report = tbReport.Text,
                Picture = pbPicture.Image,
            };
            listCarReports.Add(carReport);


            SetCbAuthor(cbAuthor.Text);
            SetCbcarname(cbCarName.Text);


        }

        private MakerGroup getRadioButttonMaker() {
            if (rbHonda.Checked) {
                return MakerGroup.ホンダ;
            } else if (rbImport.Checked) {
                return MakerGroup.輸入車;
            } else if (rbNissan.Checked) {
                return MakerGroup.ニッサン;
            } else if (rbSubaru.Checked) {
                return MakerGroup.スバル;
            } else if (rbToyota.Checked) {
                return MakerGroup.トヨタ;
            }
            return MakerGroup.その他;
        }

        private void btOpenPicture_Click(object sender, EventArgs e) {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                pbPicture.Image = Image.FromFile(openFileDialog1.FileName);
            }

        }



        private void btNewInput_Click(object sender, EventArgs e) {
            empty();

        }

        private void empty() {
            tsslb.Text = string.Empty;
            cbAuthor.Text = string.Empty;
            tbReport.Text = string.Empty;
            cbCarName.Text = string.Empty;
            dtpDate.Value = DateTime.Today;


            foreach (RadioButton rb in groupBox1.Controls.OfType<RadioButton>()) {
                rb.Checked = false;
            }
            pbPicture.Image = null;
        }

        private void dgvRecords_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            dtpDate.Value = (DateTime)dgvRecords.CurrentRow.Cells["Date"].Value;
            cbAuthor.Text = (string)dgvRecords.CurrentRow.Cells["Author"].Value;

            SetRadoButtonMaker((MakerGroup)dgvRecords.CurrentRow.Cells["meker"].Value);

            cbCarName.Text = (string)dgvRecords.CurrentRow.Cells["CarName"].Value;
            tbReport.Text = (string)dgvRecords.CurrentRow.Cells["Report"].Value;
            pbPicture.Image = (Image)dgvRecords.CurrentRow.Cells["Picture"].Value;
        }

        private void SetRadoButtonMaker(MakerGroup meker) {


            switch (meker) {
                case MakerGroup.トヨタ:
                    rbToyota.Checked = true;
                    break;
                case MakerGroup.ニッサン:
                    rbNissan.Checked = true;
                    break;
                case MakerGroup.ホンダ:
                    rbHonda.Checked = true;
                    break;
                case MakerGroup.スバル:
                    rbSubaru.Checked = true;
                    break;
                case MakerGroup.輸入車:
                    rbImport.Checked = true;
                    break;
                default:
                    rbOther.Checked = true;
                    break;

            }

        }
        //記録者の入力履歴をコンボボックスへ登録（重複なし）
        private void SetCbAuthor(string author) {
            // 空文字または空白スペースのみの場合は登録しない
            if (string.IsNullOrWhiteSpace(author)) return;

            // すでに同じ名前がリストにない場合のみ追加する
            if (!cbAuthor.Items.Contains(author)) {
                cbAuthor.Items.Add(author);
            }
        }

        //車名の入力履歴をコンボボックスへ登録（重複なし）
        private void SetCbcarname(string carName) {
            // 空文字または空白スペースのみの場合は登録しない
            if (string.IsNullOrWhiteSpace(carName)) return;

            // すでに同じ車名がリストにない場合のみ追加する
            if (!cbCarName.Items.Contains(carName)) {
                cbCarName.Items.Add(carName);
            }
        }

    }
}