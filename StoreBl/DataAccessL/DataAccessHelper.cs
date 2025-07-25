using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBl.DataAccessL
{
    public class DataAccessHelper
    {
        public static IDataAccess CreateObject()
        {
            return new FileDataLayer();
        }
    }
}
