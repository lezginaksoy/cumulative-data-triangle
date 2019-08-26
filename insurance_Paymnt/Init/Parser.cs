using insurance_Paymnt.Builder;
using insurance_Paymnt.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace insurance_Paymnt.Init
{
    public class Parser:IParser
    {
        IList<string> PrimiList;//= new List<string>();
        IList<Triangle> TriangleList;// = new List<Triangle>();

        public Parser(IList<string> UnParsedList)
        {
            PrimiList = new List<string>();
            this.PrimiList = UnParsedList;
        }

        //Parse,validate and to List
        //
        public IList<Triangle> ParseAndValidate()
        {
            Triangle tri;
            TriangleList = new List<Triangle>();
            foreach (var item in this.PrimiList)
            {
                tri = new Triangle();
                tri.Product = item.Split(',').GetValue(0).ToString();
                tri.OriginYear = Convert.ToInt32(item.Split(',').GetValue(1).ToString());
                tri.DevelopmentYear = Convert.ToInt32(item.Split(',').GetValue(2).ToString());
                tri.IncrementalValue = 0;
                if (!string.IsNullOrWhiteSpace(item.Split(',').GetValue(3).ToString()))
                    tri.IncrementalValue = Convert.ToDouble(item.Split(',').GetValue(3).ToString());

                TriangleList.Add(tri);
            }
            return TriangleList;
        }
    
        //grouping Triangles by Products name and order by Origin year
        public List<List<Triangle>> GetGroupedTriangleList()
        {
            var group = TriangleList
             .GroupBy(u => u.Product)             
             .Select(grp => grp.ToList())
             .ToList();

            return group;
        }
                             
        //get origin year in Triangles
        public int GetOriginYear()
        {           
            return TriangleList.Select(i => i.OriginYear).Min(); 
        }

        //Get development years count or angin from min2max origin years
        public int GetDevYearsCount()
        {
            int dev = TriangleList.Select(x => x.OriginYear).Max() - TriangleList.Select(i => i.OriginYear).Min() + 1;
            return dev;
        }

    



    }


}
