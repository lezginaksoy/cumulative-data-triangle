using insurance_Paymnt.Init;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace insurance_Paymnt.Interfaces
{
    interface IParser
    {
        IList<Triangle> ParseAndValidate();
        int GetOriginYear();
        int GetDevYearsCount();
        List<List<Triangle>> GetGroupedTriangleList();

    }
}
