using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    class DBAccess
    {
        public static StepmaniaEntities1 StepDB = null;

        public static void InitiateDB()
        {
            if(StepDB == null)
            {
                StepDB = new StepmaniaEntities1();
            }
        }
    }
}
