using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using MyTailor.BDO.Masters;

namespace MyTailor.DAL.Masters
{
    public class TailorDAL
    {
        public static List<Tailor> GetTailors(Tailor filterData = null)
        {
            List<Tailor> Tailors = getTailorsList();
            if (filterData != null)
            {
                return Tailors.FindAll(tl =>
                    tl.FirstName.StartsWith(filterData.FirstName) &&
                    tl.LastName.StartsWith(filterData.LastName) &&
                    tl.TailorCode.StartsWith(filterData.LastName)
                    );//.OrderBy(tl => tl.LastName).ThenBy(tl => tl.LastName).ThenBy(tl => tl.FirstName);
            }
            return Tailors;
        }

        public static Tailor GetTailorByID(int ID)
        {
            List<Tailor> Tailors = getTailorsList();
            return Tailors.Find(tl => tl.TailorID == ID);
        }

        #region Private Members

        private static List<Tailor> getTailorsList()
        {
            List<Tailor> Tailors = new List<Tailor>();
            Tailors.Add(new Tailor { TailorID = 1, TailorCode = "PK", FirstName = "Steve", LastName = "Leung", IsActive = true });
            Tailors.Add(new Tailor { TailorID = 2, TailorCode = "SLC", FirstName = "Stephan", LastName = "s", IsActive = true });
            Tailors.Add(new Tailor { TailorID = 3, TailorCode = "SSC", FirstName = "Stephan", LastName = "S", IsActive = true });
            Tailors.Add(new Tailor { TailorID = 4, TailorCode = "SUI", FirstName = "Stephan", LastName = "Sui", IsActive = true });
            Tailors.Add(new Tailor { TailorID = 5, TailorCode = "PN", FirstName = "Paul", LastName = "Ng", IsActive = true });
            Tailors.Add(new Tailor { TailorID = 6, TailorCode = "LAI-2", FirstName = "Lai", LastName = "", IsActive = true });
            Tailors.Add(new Tailor { TailorID = 7, TailorCode = "HWY", FirstName = "James", LastName = "Cheung", IsActive = true });
            Tailors.Add(new Tailor { TailorID = 8, TailorCode = "HC", FirstName = "Henry", LastName = "Chik", IsActive = true });
            Tailors.Add(new Tailor { TailorID = 9, TailorCode = "GF", FirstName = "Gao", LastName = "Feng", IsActive = true });
            Tailors.Add(new Tailor { TailorID = 10, TailorCode = "YYT", FirstName = "Eddy", LastName = "Chan", IsActive = true });
            Tailors.Add(new Tailor { TailorID = 11, TailorCode = "MB", FirstName = "Bi Zhi", LastName = "Yong", IsActive = true });
            return Tailors;
        }

        #endregion
    }
}
