using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using MyTailor.BDO.Masters;
using MyTailor.DAL.Masters;

namespace MyTailor.Logic.Masters
{
    public class TailorLogic
    {
        public static List<Tailor> GetTailors(Tailor filterData = null)
        {
            return TailorDAL.GetTailors(filterData);
        }

        public static Tailor GetTailorByID(int ID)
        {
            return TailorDAL.GetTailorByID(ID);
        }
    }
}
