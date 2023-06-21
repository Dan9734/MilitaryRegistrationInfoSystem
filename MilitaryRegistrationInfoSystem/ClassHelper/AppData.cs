using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryRegistrationInfoSystem.ClassHelper
{
    public class AppData
    {
        public static EF.MilitaryRegistrationEntities context = new EF.MilitaryRegistrationEntities();
        //public static EF.Entities context = new EF.Entities();
    }
}
