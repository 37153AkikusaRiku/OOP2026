
namespace TextFileProcessar;
public abstract class TextProcessar {
    public static void Run<T>(string fileName) where T : TextProcessar, new() {
        var self = new T();
        self.Process(fileName);
    }

    private void Process(string fileName) {
        Initializer(fileName);
        var lines = File.ReadLines(fileName);
        foreach(var line in lines) {
            Execute(line);       
        }
        Teminate();
    }

    protected abstract void Teminate();
    protected abstract void Execute(string line);
    protected abstract void Initializer(string fileName);
}