using Microsoft.EntityFrameworkCore;
using SelfOrderSystem.Models;

namespace SelfOrderSystem.Data;

public class AppDbContext : DbContext {
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) {
    }
    //Categories テーブルをCategory型として問い合わせるためのプロパティ
    public DbSet<Category> Categories => Set<Category>();        // カテゴリ 

    //Productsテーブル
    public DbSet<Product> Products => Set<Product>();            // 商品 
}