using TextFilePlocessor;

namespace TextFileProcessorDI {
    public class TextFilePlocessor {
        private ITextFileService _service;

        public TextFilePlocessor(ITextFileService service) {
            _service = service;
        }

        public void Run(string fileName) {
            _service.Initialize(fileName);
            var lines = File.ReadLines(fileName);
            foreach (var line in lines) {
                _service.Execute(line);

                if (20>= _service.Teminate()) {
                    Console.WriteLine(line);
                }

            }
            
        }
    }
}
