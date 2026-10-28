using System.Text.RegularExpressions;
using TextFileProcessar;


string path = @"C:\Users\infosys\source\repos\OOP2026\Chapter14\Section14\Program.cs";
TextProcessar.Run<LineCounterProcessor>(path);



public class LineCounterProcessor : TextProcessar {
    public int _count = 0;
    string? Word = string.Empty;

    protected override void Initializer(string fname) {
        Console.Write("検索ワード:");
        Word = Console.ReadLine() ?? "";

        _count = 0;
    }
    protected override void Execute(string fname) =>
       _count += Regex.Matches(fname, Regex.Escape(Word)).Count;

    protected override void Teminate() =>
        Console.WriteLine("{0}個", _count);


}