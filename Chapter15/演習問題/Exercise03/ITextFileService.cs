using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFilePlocessor {
    public interface ITextFileService {

       int Teminate();
       void Execute(string line);
       void Initialize(string fileName);
    }
}
