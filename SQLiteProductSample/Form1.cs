using System.ComponentModel;

namespace SQLiteProductSample;

public partial class Form1 : Form {
    // DataGridViewへ表示する商品の一覧
    private readonly BindingList<Product> _products = new();
    // DB操作を担当するRepository
    private readonly ProductRepository _repository = new();

    public Form1() {
        InitializeComponent();

        dgvProducts.AutoGenerateColumns = true;
        dgvProducts.DataSource = _products;

        ReloadProducts();

        tsslMessage.Text = $"DB: {Database.FilePath}";
    }
    //入力値が不正なら処理を終了
    private void btAdd_Click(object sender, EventArgs e) {
        if (!TryGetInput(out string name, out int price))
            return;
        try {
            int newId = _repository.Add(name, price);
            ReloadProducts();
            ClearInput();
            tsslMessage.Text = $"商品を追加しました。(ID: {newId})";
        }
        catch (Exception ex) {
            ShowError("商品の追加に失敗しました", ex);
        }



    }

    private void btUpdate_Click(object sender, EventArgs e) {


        if (dgvProducts.CurrentRow?.DataBoundItem is not Product selectedProduct) {
            tsslMessage.Text = "修正する商品を選択してください。";
            return;
        }

        if (!TryGetInput(out string name, out int price)) {
            return;
        }

        try {
            // リポジトリのUpdateを呼び出す
            selectedProduct.Name = name;
            selectedProduct.Price = price;
            _repository.Update(selectedProduct);

            ReloadProducts();
            ClearInput();
            tsslMessage.Text = $"商品情報を修正しました。(ID: {selectedProduct.Id})";
        }
        catch (Exception ex) {
            ShowError("商品の修正に失敗しました", ex);
        }


    }

    private void btDelete_Click(object sender, EventArgs e) {


        if (dgvProducts.CurrentRow?.DataBoundItem is not Product selectedProduct) {
            tsslMessage.Text = "削除する商品を選択してください。";
            return;
        }

        var result = MessageBox.Show(
            $"「{selectedProduct.Name}」を削除してもよろしいですか？",
            "削除確認",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

        if (result != DialogResult.Yes) {
            return;
        }

        try {
            // リポジトリのDeleteを呼び出す
            _repository.Delete(selectedProduct.Id);
            ReloadProducts();
            ClearInput();
            tsslMessage.Text = $"商品を削除しました。(ID: {selectedProduct.Id})";
        }
        catch (Exception ex) {
            ShowError("商品の削除に失敗しました", ex);
        }


    }

    private void btClear_Click(object sender, EventArgs e) {


       
        dgvProducts.ClearSelection();
        ClearInput();
        tsslMessage.Text = "入力をクリアしました。";


    }

    private void dgvProducts_SelectionChanged(object sender, EventArgs e) {
        if (dgvProducts.CurrentRow?.DataBoundItem is not Product product) 
            return;

        tbName.Text = product.Name;
        tbPrice.Text = product.Price.ToString();
        tsslMessage.Text = $"商品を選択中 (ID: {product.Id})";
    }

    private void ReloadProducts() {
        _products.Clear();

        foreach (var product in _repository.GetAll()) {
            _products.Add(product);
        }

        dgvProducts.ClearSelection();
    }

    private bool TryGetInput(out string name, out int price) {
        name = tbName.Text.Trim();

        if (string.IsNullOrWhiteSpace(name)) {
            price = 0;
            tsslMessage.Text = "商品名を入力してください。";
            tbName.Focus();
            return false;
        }

        if (!int.TryParse(tbPrice.Text, out price) || price < 0) {
            tsslMessage.Text = "価格は0以上の整数で入力してください。";
            tbPrice.Focus();
            tbPrice.SelectAll();
            return false;
        }

        return true;
    }

    private void ClearInput() {
        tbName.Clear();
        tbPrice.Clear();
        tbName.Focus();
    }

    private void ShowError(string title, Exception ex) {
        tsslMessage.Text = title;
        MessageBox.Show(
            ex.Message,
            title,
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
    }

    private void Form1_Load(object sender, EventArgs e) {

    }

    private void tbName_TextChanged(object sender, EventArgs e) {

    }

    private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e) {

    }
}
