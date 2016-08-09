using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BEL;

namespace Interfaces
{
    public interface IBusiness
    {
        List<BEL.Business> Get();
        BEL.Business Get(int id);
        int Post(BEL.Business obj);
    }
}
