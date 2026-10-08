using Microsoft.AspNetCore.Mvc;         // MVCの機能を使用 
using Microsoft.EntityFrameworkCore;    // ToListAsyncを使用 
using MvcBasicSample.Data;              // AppDbContextを使用 

namespace MvcBasicSample.Controllers;
public class ProductsController　:Controller {
    private readonly AppDbContext _db;  // DBへ問い合わせるためのフィールド 

    public ProductsController(AppDbContext db) {
        _db = db;  // 受け取ったAppDbContextをフィールドに保存
    }
    //Products/Indexで商品一覧を取得する
    public async Task<IActionResult> Index() {

        //Idの昇順で取得し結果をList＜Product＞にする
        var products = await _db.Products.OrderBy(product => product.Price).Where(product =>product.Price >= 500).ToListAsync();

        //商品一覧をViewへ渡す
        return View (products);
    }


}

