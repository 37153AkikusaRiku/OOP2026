using System.ComponentModel;
using System.Diagnostics.Metrics;
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

            dgvRecords.ClearSelection();
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

        private void btDeletePicture_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }

        private void btDeleteRecord_Click(object sender, EventArgs e) {
            if (dgvRecords.CurrentRow == null || dgvRecords.CurrentRow.Index < 0) {
                MessageBox.Show("削除する行が選択されていません。", "通知", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            listCarReports.RemoveAt(dgvRecords.CurrentRow.Index);
            empty();

            if (dgvRecords.CurrentRow == null || dgvRecords.CurrentRow.Index < 0) {
                return;
            }

            dtpDate.Value = (DateTime)dgvRecords.CurrentRow.Cells["Date"].Value;
            cbAuthor.Text = (string)dgvRecords.CurrentRow.Cells["Author"].Value;

            SetRadoButtonMaker((MakerGroup)dgvRecords.CurrentRow.Cells["meker"].Value);

            cbCarName.Text = (string)dgvRecords.CurrentRow.Cells["CarName"].Value;
            tbReport.Text = (string)dgvRecords.CurrentRow.Cells["Report"].Value;
            pbPicture.Image = (Image)dgvRecords.CurrentRow.Cells["Picture"].Value;
        }

        private void btModifyRecord_Click(object sender, EventArgs e) {
            if (dgvRecords.CurrentRow == null || dgvRecords.CurrentRow.Index < 0) {
                MessageBox.Show("修正する行が選択されていません。", "通知", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //記録者と車名が未記入だった場合は追加しない
            if (cbAuthor.Text == string.Empty || cbCarName.Text == string.Empty) {
                tsslb.Text = "記録者、または車名が未記入です";
                return;
            }


            DialogResult result = MessageBox.Show(
               "選択したレコードを修正してもよろしいですか？",
               "修正の確認",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question
            );

            // 3. 「いいえ」が押された場合は、ここで処理を中断する
            if (result == DialogResult.No) {
                return;
            }

            // 4. 「はい」の場合のみ、以下の修正処理を実行

            DataGridViewRow selectedRow = dgvRecords.CurrentRow;

            dgvRecords.CurrentRow.Cells["Date"].Value = dtpDate.Value;
            dgvRecords.CurrentRow.Cells["Author"].Value = cbAuthor.Text;

            dgvRecords.CurrentRow.Cells["Meker"].Value = getRadioButttonMaker();

            dgvRecords.CurrentRow.Cells["CarName"].Value = cbCarName.Text.Trim();
            dgvRecords.CurrentRow.Cells["Report"].Value = tbReport.Text;
            dgvRecords.CurrentRow.Cells["Picture"].Value = pbPicture.Image;
            //listCarReports[dgvRecords.CurrentRow.Index].Dat //e = dtpDate.Value;この形でもできる

            SetCbAuthor(cbAuthor.Text.Trim());
            SetCbcarname (cbAuthor.Text.Trim());
            dgvRecords.Refresh();
        }

        private void dgvRecords_SelectionChanged(object sender,EventArgs e) {
            if ((dgvRecords.CurrentRow?.DataBoundItem is not CarReport carReport)
                || (!dgvRecords.CurrentRow.Selected)) return;

            dtpDate.Value = carReport.Date;
            cbAuthor.Text = carReport.Author;

            SetRadoButtonMaker((MakerGroup)dgvRecords.CurrentRow.Cells["meker"].Value);

            cbCarName.Text = carReport.CarName;
            tbReport.Text = carReport.Report;
            pbPicture.Image = carReport.Picture;


        }




        private void 色設定ToolStripMenuItem_Click(object sender, EventArgs e) {
            using (ColorDialog colorDialog = new ColorDialog()) {
                if (colorDialog.ShowDialog() == DialogResult.OK) {
                    this.BackColor = colorDialog.Color;


                }
            }
        }

        //フォームが閉じられたら発動する
        private void Form1_FormClosed(object sender,FormClosedEventArgs e) {
            //i
        }


    }
    
}




















































































































































































































































































































































































































































