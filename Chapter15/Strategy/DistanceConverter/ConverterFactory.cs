using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter;
public class ConverterFactory {
    public readonly static ConverterBase[] _converters = {
        new MeterConverter(),
        new FeetConverter(),
        new YardConverter(),
        new InchConverter(),
        new MiluConverter(),
        new MiluConverter(),

    };

    public static ConverterBase? GetInstance(string name) =>
        _converters.FirstOrDefault(x => x.IsMyUnit(name));


}

