using TextFileProcessorDI;

var service = new LineCounterService();
var processor = new TextFileProcessorDI.TextFilePlocessor(service);
Console.Write("パスの入力 : ");
processor.Run(Console.ReadLine());
