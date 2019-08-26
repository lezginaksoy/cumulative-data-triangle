using insurance_Paymnt.Builder;
using insurance_Paymnt.Init;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace insurance_Paymnt
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Wellcome.. !");
            try
            {
                Console.WriteLine("Initializer Start to upload File !");
                Initializer iniFile = new Initializer();
                Console.WriteLine("Initializer completed in Success !");
                Console.WriteLine("         ||||||||||                  ");

                Console.WriteLine("Parser Start to Parsing and add to List !");
                Parser parseStart = new Parser(iniFile.InitTriangleList());
                parseStart.ParseAndValidate();
                Console.WriteLine("Initializer completed in Success !");
                Console.WriteLine("         ||||||||||                  ");
                
                
                Console.WriteLine("OutPutBuilder Start !");
                Console.WriteLine("OutPutBuilder Start to Calculate incremental data ");
                Console.WriteLine("OutPutBuilder Start to prepare OutPut data ");

                new OutPutBuilder()
                    .AddTriangles(parseStart.GetGroupedTriangleList())
                    .AddDevYearsCount(parseStart.GetDevYearsCount())
                    .AddOriginYear(parseStart.GetOriginYear())
                    .CalculateIncValues()
                    .Build();

                Console.WriteLine("         ||||||||||                  ");
                Console.WriteLine("OutPutBuilder completed in Success !");

            }
            catch (Exception ex)
            {

                Console.WriteLine("         ||||||||||                  ");
                Console.WriteLine("Failed at : ",ex.Message);
                throw ex;

            }
            finally
            {
                Console.ReadLine();
            }



           




        }



    }
}
