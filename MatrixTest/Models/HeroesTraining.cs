using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static MatrixTest.HeroConstants;

namespace MatrixTest
{
    public class HeroesTraining
    {
        public static bool Train(Hero hero)
        {
            if (CanTraining(hero))
            {
                int trainingNum = 1;

                if (hero.TrainingCounter.Item1.Date == DateTime.Now.Date)
                {
                    trainingNum = hero.TrainingCounter.Item2 + 1;
                }

                hero.TrainingCounter = new Tuple<DateTime, int>(DateTime.Now, trainingNum);
                return true;
            }

            return false;
        }

        private static bool CanTraining(Hero hero)
        {
            if (hero.TrainingCounter.Item1.Date == DateTime.Now.Date)
            {
                if (hero.TrainingCounter.Item2 < MAX_TRINING_IN_DAY)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}