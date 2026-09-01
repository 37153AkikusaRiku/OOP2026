using System.ComponentModel;

namespace SQLiteProductSample;

public class Product
{

    [DisplayName("ID")]
    public int Id { get; set; }
    [DisplayName("è§ïiñº")]
    public string Name { get; set; }=string.Empty;
    [DisplayName("âøäi")]
    public int Price { get; set; }

}
