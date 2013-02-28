using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using MyTailor.BDO.Masters;
using MyTailor.DAL.Masters;

namespace MyTailor.Logic.Masters
{
    public class CommonLogic
    {
        public static List<Color> GetColors()
        {
            return CommonDAL.GetColors();
        }

        public static Color GetColorByID(long ID)
        {
            return CommonDAL.GetColorByID(ID);
        }

        public static List<Pattern> GetPatterns()
        {
            return CommonDAL.GetPatterns();
        }

        public static Pattern GetPatternByID(long ID)
        {
            return CommonDAL.GetPatternByID(ID);
        }

        public static List<Category> GetCategories()
        {
            return CommonDAL.GetCategories();
        }

        public static Category GetCategoryByID(long ID)
        {
            return CommonDAL.GetCategoryByID(ID);
        }

        public static List<ItemDescriptionType> GetItemDescriptionTypes()
        {
            return CommonDAL.GetItemDescriptionTypes();
        }

        public static ItemDescriptionType GetItemDescriptionTypeByID(long ID)
        {
            return CommonDAL.GetItemDescriptionTypeByID(ID);
        }
    }
}
