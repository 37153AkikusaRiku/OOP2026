using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section02 {
    internal class YearMonth {

        public int Year { get; private set; }
        public int Month { get; private set; }
        //public int Is21Century { get; private init; }

        public bool Is21Century => 2001 <=2100;
            
        


        public YearMonth(int year, int month) {
            Year = year;
            Month = month;

        }

        public YearMonth addOneMonth(int year, int month) {
            if (month == 12) {
                return new YearMonth(year + 1, 1);
            } else {
                return new YearMonth(year, month+1);
            }
        }

    }
}
