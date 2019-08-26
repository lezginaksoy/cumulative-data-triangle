using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace insurance_Paymnt.Init
{
    public class Triangle
    {
        private string product;
        private int originYear;
        private int developmentYear;
        private double incrementalValue;

        public string Product { get => product; set => product = value; }
        public int OriginYear { get => originYear; set => originYear = value; }
        public int DevelopmentYear { get => developmentYear; set => developmentYear = value; }
        public double IncrementalValue { get => incrementalValue; set => incrementalValue = value; }


    }
}
