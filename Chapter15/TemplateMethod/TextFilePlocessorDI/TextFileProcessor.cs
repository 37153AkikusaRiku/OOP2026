using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TectFilePlocessor;

namespace TectFilePlocessorDI {
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
            }
            _service.Teminate();
        }
    }
}
