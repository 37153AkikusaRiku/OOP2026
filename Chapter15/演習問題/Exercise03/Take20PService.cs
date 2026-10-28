using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFilePlocessor;

namespace TextFileProcessorDI {
    internal class LineCounterService : ITextFileService {
        private int _count = 0;

        public void Initialize(string fname) => _count = 0;

        public void Execute(string line) => _count++;

        public int Teminate() => _count;
    }
}
