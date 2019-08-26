using insurance_Paymnt.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace insurance_Paymnt
{
    public class Initializer : IInitializer
    {
        const string APP_CONFIG_FILE = "INPUT_FILE_PATH";
        IList<string> RowList;
        
        //stream data from from file and validate for basic gap
        public  Initializer()
        {
            string InputPath =ConfigurationManager.AppSettings[APP_CONFIG_FILE];
            RowList = new List<string>();
            using (StreamReader reader = new StreamReader(InputPath))
            {
                reader.ReadLine();
                string line;// = new StringBuilder();
                while ((line = reader.ReadLine()) != null)
                {
                    RowList.Add(line);
                }
            }
        }

        public IList<string> InitTriangleList()
        {
            return RowList;
        }


    }
}
