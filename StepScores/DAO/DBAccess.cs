﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DBAccess
    {
        public static StepmaniaEntities StepDB = null;

        public static void InitiateDB()
        {
            if(StepDB == null)
            {
                StepDB = new StepmaniaEntities();
            }
        }

        public static List<Scores> GetAllScores()
        {
            return StepDB.Scores.ToList();
        }

        public static List<Scores> GetFilterScore(string filter)
        {
            return StepDB.Scores.Where(s => s.Titre.Contains(filter) || s.Artiste.Contains(filter) || s.Mappeur.Contains(filter)).ToList();
        }
    }
}
