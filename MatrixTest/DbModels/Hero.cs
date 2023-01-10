using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using static MatrixTest.HeroConstants;

namespace MatrixTest
{
    public class Hero
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Ability Ability { get; set; }
        public int GuidId { get; set; }
        public DateTime StartedTrainDate { get; set; }
        public string SuitColor { get; set; }
        public decimal StartingPower { get; set; }
        public decimal CurrentPower { get; set; }
        public Tuple<DateTime, int> TrainingCounter { get; set; }

        public Hero() { }

        public Hero(int id, string name, Ability ability, int guidId, DateTime startedTrainDate, string suitColor, decimal startingPower, decimal currentPower)
        {
            Id = id;
            Name = name;
            Ability = ability;
            GuidId = guidId;
            StartedTrainDate = startedTrainDate;
            SuitColor = suitColor;
            StartingPower = startingPower;
            CurrentPower = currentPower;
            TrainingCounter = new Tuple<DateTime, int>(DateTime.Now, 0);
        }
    }
}