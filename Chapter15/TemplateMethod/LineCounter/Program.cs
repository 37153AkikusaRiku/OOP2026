
using TextFileProcessar;


string path = @"C:\Users\infosys\source\repos\OOP2026\Chapter14\演習問題\Exercise01_WPF\吾輩は猫である.txt";

public class  LineCounterProcessor : TextProcessar {
    public int _count = 0;

    protected override void Initializer(string fname) =>
        _count = 0;

    protected override void Execute (string fname) =>
       _count++;

    protected override void Teminate() =>
        Console.WriteLine("{0}行", _count);

    
}

 

