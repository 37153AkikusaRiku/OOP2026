using SQLiteProductSample;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using static CarReportSystem.CarReport;

namespace CarReportSystem {
	public partial class Form1 : Form {


		





		//カーレポート管理用リスト
		BindingList<CarReport> listCarReports = new BindingList<CarReport>();
        // DB操作を担当するRepository
        CarReportRepository carReportRepository = new CarReportRepository();


        ////設定クラスのオブジェクトを生成
        //Settings settings = Settings.Instance;

        public Form1() {
			InitializeComponent();
			dgvRecords.DataSource = listCarReports;
			Settings.Instance.Load();

			ReloadProducts();


            // 2. 読み込んだ色を背景色に適用する
            this.BackColor = Color.FromArgb(Settings.Instance.MainFormBackColor);
		}


		private void Form1_Load(object sender, EventArgs e) {
			//設定ファイルを読み込み背景色を設定する（逆シリアル化）

			//listCarReports.Clear();

			//foreach (var carReport in CarRepository.GetAll()) {
			//    listCarReports.Add(carReport);
			//}

			//dgvRecords.ClearSelection();

			//ファイルが存在するか？
			//if (File.Exists("setting.xml")) {
				try {

					//P286以降を参考にする（ファイル名：setting.xml）
					using (var reader = XmlReader.Create("setting.xml")) {
						var serializer = new XmlSerializer(typeof(Settings));

						if (serializer.Deserialize(reader) is Settings loadedSettings) {
						   var settings = loadedSettings;
							//背景色
							BackColor = Color.FromArgb(Settings.Instance.MainFormBackColor);
						}

					   
					}
				}
				catch (Exception ex) {
					tsslbMessage.Text = "設定ファイル読み込みエラー";
					MessageBox.Show(ex.Message);//←より具体的なエラーを出力         
				}
			//} else {
			   tsslbMessage.Text = "設定ファイルがありません";
			//}
		}

        private void ReloadProducts() {
            

            listCarReports.Clear();
            cbAuthor.Items.Clear();
            cbCarName.Items.Clear();

            foreach (var carReport in carReportRepository.GetAll()) {
                listCarReports.Add(carReport);

				

				SetCbAuthor(carReport.Author);
				SetCbCarName(carReport.CarName);
            }
            dgvRecords.ClearSelection();
        }


        private void ShowError(string title, Exception ex) {
			tsslbMessage.Text = title;
			MessageBox.Show(
				ex.Message,
				title,
				MessageBoxButtons.OK,
				MessageBoxIcon.Error);
		}

		//追加ボタンイベントハンドラ
		private void btAddRecord_Click(object sender, EventArgs e) {

			tsslbMessage.Text = String.Empty;   //メッセージ領域のクリア

			if (String.IsNullOrWhiteSpace(cbAuthor.Text) || String.IsNullOrWhiteSpace(cbCarName.Text)) {
				tsslbMessage.Text = "記録者、または車名が未入力です";
				return;
			}

			var carReport = new CarReport {
				Date = dtpDate.Value.Date,
				Author = cbAuthor.Text.Trim(),
				Maker = GetRadioButtonMaker(),
				CarName = cbCarName.Text.Trim(),
				Report = tbReport.Text,
				Picture = pbPicture.Image,
			};
			

            carReport.Id = carReportRepository.Add(carReport);
            listCarReports.Add(carReport);
			ReloadProducts();

   //         //入力履歴を登録
   //         SetCbAuthor(cbAuthor.Text.Trim());
			//SetCbCarName(cbCarName.Text.Trim());

			dgvRecords.ClearSelection(); //セルの選択を解除する
			InputItemsUpdate(); //データグリッドビューを更新したら呼ぶメソッド


			


		}





        






        private MakerGroup GetRadioButtonMaker() {
			if (rbToyota.Checked)
				return MakerGroup.トヨタ;
			if (rbNissan.Checked)
				return MakerGroup.日産;
			if (rbHonda.Checked)
				return MakerGroup.ホンダ;
			if (rbSubaru.Checked)
				return MakerGroup.スバル;
			if (rbImport.Checked)
				return MakerGroup.輸入車;

			return MakerGroup.その他;
		}


		private void btOpenPicture_Click(object sender, EventArgs e) {
			if (ofdPicFileOpen.ShowDialog() == DialogResult.OK) {
				pbPicture.Image = Image.FromFile(ofdPicFileOpen.FileName);
			}
		}


		private void btNewInput_Click(object sender, EventArgs e) {
			InputItemsAllClear();
		}


		private void InputItemsAllClear() {
			dtpDate.Value = DateTime.Today;
			cbAuthor.Text = string.Empty;
			rbOther.Checked = true;
			cbCarName.Text = string.Empty;
			tbReport.Text = string.Empty;
			pbPicture.Image = null;

			dgvRecords.ClearSelection();//セルの選択を解除する
		}


		private void SetRadioButtonMaker(MakerGroup targetMaker) {

			switch (targetMaker) {

				case MakerGroup.トヨタ:
					rbToyota.Checked = true;
					break;
				case MakerGroup.日産:
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
		//記録者の入力履歴をコンボボックスへ登録
		private void SetCbAuthor(string author) {
			//未登録なら登録【登録済みなら何もしない】
			if (!cbAuthor.Items.Contains(author))
				cbAuthor.Items.Add(author);
		}
		//車名の入力履歴をコンボボックスへ登録
		private void SetCbCarName(string carName) {
			//未登録なら登録【登録済みなら何もしない】
			if (!cbCarName.Items.Contains(carName))
				cbCarName.Items.Add(carName);

		}
		private void btDeletePicture_Click(object sender, EventArgs e) {
			pbPicture.Image = null;
		}


		private void btDeleteRecord_Click(object sender, EventArgs e) {
			if (dgvRecords.CurrentRow ?.DataBoundItem is not CarReport carReport) {
				tsslbMessage.Text = "削除するレポートを選択してください";
				return;
				}
			
			try {
				// リポジトリのDeleteを呼び出す
				carReportRepository.Delete(carReport);

				ReloadProducts();

				InputItemsAllClear();

                tsslbMessage.Text = $"商品情報を削除しました。(ID: {carReport.Id})";
			}
			catch (Exception ex) {
				ShowError("商品の削除に失敗しました", ex);
			}
		}



		//データグリッドビューを更新したら呼ぶメソッド
		private void InputItemsUpdate() {
			// 1. そもそもカレント行がない、またはカレント行が選択されていない場合
			if (dgvRecords.CurrentRow == null || !dgvRecords.CurrentRow.Selected) {
				InputItemsAllClear();
			}
		}
		private void btModifyRecord_Click(object sender, EventArgs e)  {

			if (dgvRecords.SelectedRows.Count == 0) {
				tsslbMessage.Text = "修正するレポートを選択してください";
				return;
			}

			if (String.IsNullOrWhiteSpace(cbAuthor.Text)
					|| String.IsNullOrWhiteSpace(cbCarName.Text)) {
				tsslbMessage.Text = "記録者、または車名が未入力です";
				return;
			}
			if (dgvRecords.CurrentRow?.DataBoundItem is not CarReport carReport) {
				tsslbMessage.Text = "修正するレポートを選択してください";
				return;
			}
			//カーレポート管理用リストの該当する要素のデータを書き換える
			listCarReports[dgvRecords.CurrentRow.Index].Date = dtpDate.Value.Date;
			listCarReports[dgvRecords.CurrentRow.Index].Author = cbAuthor.Text.Trim();
			listCarReports[dgvRecords.CurrentRow.Index].Maker = GetRadioButtonMaker();
			listCarReports[dgvRecords.CurrentRow.Index].CarName = cbCarName.Text.Trim();
			listCarReports[dgvRecords.CurrentRow.Index].Report = tbReport.Text;
			listCarReports[dgvRecords.CurrentRow.Index].Picture = pbPicture.Image;

			//SetCbAuthor(cbAuthor.Text.Trim());
			//SetCbCarName(cbCarName.Text.Trim());

			dgvRecords.Refresh();   //データグリッドビューの更新
			tsslbMessage.Text = "レポートを修正しました";



			try {
				
				carReportRepository.Update(carReport);

				ReloadProducts();

                InputItemsAllClear();
				tsslbMessage.Text = $"商品情報を修正しました。(ID: {carReport.Id})";
		}
			catch (Exception ex) {
			ShowError("商品の修正に失敗しました", ex);
		}



		}

		private void dgvRecords_SelectionChanged(object sender, EventArgs e) {

			if ((dgvRecords.CurrentRow?.DataBoundItem is not CarReport carReport)
					|| (!dgvRecords.CurrentRow.Selected)) return;

			dtpDate.Value = carReport.Date;
			cbAuthor.Text = carReport.Author;
			SetRadioButtonMaker(carReport.Maker);
			cbCarName.Text = carReport.CarName;
			tbReport.Text = carReport.Report;
			pbPicture.Image = carReport.Picture;

			InputItemsUpdate(); //データグリッドビューを更新したら呼ぶメソッド
		}

		private void 終了ToolStripMenuItem_Click(object sender, EventArgs e) {
			Application.Exit();
		}

		private void 色設定ToolStripMenuItem_Click(object sender, EventArgs e) {
			if (cdColor.ShowDialog() == DialogResult.OK) {
				BackColor = cdColor.Color;
				// 変更された色の情報を保存
				Settings.Instance.MainFormBackColor = cdColor.Color.ToArgb();

				// 【追加】ファイルへの保存処理を明示的に呼び出す
				Settings.Instance.Save();

			}
		}

		//フォームが閉じたら呼ばれるイベントハンドラ
		private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
			//設定ファイルへ色情報を保存する処理（シリアル化）
			//P284以降を参考にする（ファイル名：setting.xml）

			using (var writer = XmlWriter.Create("setting.xml")) {
				var serializer = new XmlSerializer(Settings.Instance.GetType());
				serializer.Serialize(writer, Settings.Instance);
			}
		}

		private void 保存ToolStripMenuItem_Click(object sender, EventArgs e) {
			reportSaveFile();
		}

		private void 開くToolStripMenuItem_Click(object sender, EventArgs e) {
			reportOpenFile();
		}

		//ファイルセーブ処理
		private void reportSaveFile() {
			if (sfdReportFileSave.ShowDialog() == DialogResult.OK) {
				try {
					//バイナリ形式でシリアル化
#pragma warning disable SYSLIB0011
					var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011
					using (FileStream fs = File.Open(sfdReportFileSave.FileName, FileMode.Create)) {
						bf.Serialize(fs, listCarReports);
					}
				}
				catch (Exception ex) {
					tsslbMessage.Text = "ファイル書き出しエラー";
					MessageBox.Show(ex.Message);
				}
			}
		}

		//ファイルオープン処理
		private void reportOpenFile() {
			if (ofdReportFileOpen.ShowDialog() == DialogResult.OK) {
				try {
					//逆シリアル化でバイナリ形式を取り込む
#pragma warning disable SYSLIB0011
					var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011
					using (FileStream fs = File.Open(
						ofdReportFileOpen.FileName, //ファイル名
						FileMode.Open,  //ファイルモード
						FileAccess.Read //アクセス
						)) {

						listCarReports = (BindingList<CarReport>)bf.Deserialize(fs);
						dgvRecords.DataSource = listCarReports;
					}
					//コンボボックスの履歴を消す
					cbAuthor.Items.Clear();
					cbCarName.Items.Clear();

					//コンボボックスの履歴を再登録
					foreach (var report in listCarReports) {
						SetCbAuthor(report.Author);
						SetCbCarName(report.CarName);
					}
				}
				catch (Exception ex) {
					tsslbMessage.Text = "ファイル読み出しエラー";
					MessageBox.Show(ex.Message);
				}
			}

		}

		private void cbAuthor_SelectedIndexChanged(object sender, EventArgs e) {

		}
	}
}
