using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace insurance_Paymnt.Builder
{
    public class OutPut
    {
        private string product;
        private List<double> incrementalValue;

        public string Product { get => product; set => product = value; }
        public List<double> IncrementalValue { get => incrementalValue; set => incrementalValue = value; }
    }
}
