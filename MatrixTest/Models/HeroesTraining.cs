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

                if (hero.LastTrainingDate.Date == DateTime.Now.Date)
                {
                    trainingNum = hero.TrainingCounter + 1;
                }
                Random rnd = new Random();
                hero.CurrentPower = hero.CurrentPower + hero.CurrentPower * rnd.Next(0, 11) / 100;
                hero.TrainingCounter = trainingNum;
                hero.LastTrainingDate = DateTime.Now;
                return true;
            }

            return false;
        }

        private static bool CanTraining(Hero hero)
        {
            if (hero.LastTrainingDate.Date == DateTime.Now.Date)
            {
                if (hero.TrainingCounter < MAX_TRINING_IN_DAY)
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