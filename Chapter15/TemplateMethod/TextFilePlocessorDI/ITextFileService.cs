using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TectFilePlocessor {
    public interface ITextFileService {

       void Teminate();
       void Execute(string line);
       void Initialize(string fileName);
    }
}
