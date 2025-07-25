using StoreBl.DataAccessL;
using StoreBl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBl.Bl
{
    public interface IBusinessLayer<t>
    {
        bool Add(t item);


        bool Delete(int id);


        List<t> GetAll();
       
    }
}
