using insurance_Paymnt.Init;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace insurance_Paymnt.Builder
{
    public sealed class OutPutBuilder
    {
        const string APP_CONFIG_FILE = "OUTPUT_FILE_PATH";
        private List<List<Triangle>> _groupedList;
        private List<OutPut> _outputList;
        private int _originYear;
        private int _devYearCount;
        public OutPutBuilder AddTriangles(List<List<Triangle>> triList)
        {
            this._groupedList = triList;
            return this;
        }
        
        public OutPutBuilder AddOriginYear(int originYear)
        {
            this._originYear = originYear;
            return this;
        }

        public OutPutBuilder AddDevYearsCount(int devYears)
        {
            this._devYearCount = devYears;
            return this;
        }
               
        //Sort Triangle and Find gap(missing development years)
        public OutPutBuilder CalculateIncValues()
        {
           _outputList = new List<OutPut>();
            OutPut output;
            List<double> incLis;

            foreach (var item in _groupedList)
            {
                item.Sort((x, y) => x.OriginYear.CompareTo(y.OriginYear));//need to Before finding  gap

                output = new OutPut();
                incLis = new List<double>();

                output.Product = item.FirstOrDefault().Product;
                incLis.Add(item.FirstOrDefault().IncrementalValue);

                int tempDev = item.FirstOrDefault().DevelopmentYear;
                int tempOrigin = item.FirstOrDefault().OriginYear;
                double tempValue = item.FirstOrDefault().IncrementalValue;

                for (int i = 1; i < item.Count; i++)
                {
                    if (tempOrigin == item[i].OriginYear)
                    {
                        //Find a gap or Missing development year
                        if (item[i].DevelopmentYear - tempDev > 1)
                        {
                            incLis.Add(tempValue);
                        }

                        tempValue += item[i].IncrementalValue;
                        incLis.Add(tempValue);

                    }
                    else
                    {
                        tempValue = item[i].IncrementalValue;
                        incLis.Add(tempValue);
                    }

                    tempDev = item[i].DevelopmentYear;
                    tempOrigin = item[i].OriginYear;
                }

                output.IncrementalValue = incLis;
                _outputList.Add(output);

            }

            return this;
        }
               
        private void CheckArguments()
        {
            if (this._groupedList == null)
                throw new ArgumentNullException("Triangle List");
            if (this._outputList == null)
                throw new ArgumentNullException("OutPut List");
            if (string.IsNullOrEmpty(this._originYear.ToString()))
                throw new ArgumentNullException("originYear");
            if (string.IsNullOrEmpty(this._devYearCount.ToString()))
                throw new ArgumentNullException("DevYearCount");
        }

        //Prepare Output Data and write to file
        public void Build()
        {
            CheckArguments();

            string outPutPath = ConfigurationManager.AppSettings[APP_CONFIG_FILE];
            int maxLength = _outputList.Select(x => x.IncrementalValue).Max(u => u.Count);

            FileStream stream = new FileStream(outPutPath, FileMode.Create);
            using (StreamWriter writer = new StreamWriter(stream))
            {
                writer.WriteLine(this._originYear + " , " + this._devYearCount);
                foreach (var listItem in _outputList)
                {
                    writer.WriteLine();
                    writer.Write(listItem.Product);
                    for (int i = 0; i < maxLength - listItem.IncrementalValue.Count; i++)
                        writer.Write(" , 0");

                    foreach (var item in listItem.IncrementalValue)
                        writer.Write(" , " + item.ToString());
                }

            }

        }






    }
}
