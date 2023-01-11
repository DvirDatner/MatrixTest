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
        public DateTime LastTrainingDate { get; set; }
        public int TrainingCounter { get; set; }
        public virtual Trainer Trainer { get; set; }

        public Hero() 
        {
            StartedTrainDate = DateTime.Now;
            LastTrainingDate = DateTime.Now;
            TrainingCounter = 0;
        }

        public Hero(int id, string name, Ability ability, int guidId, string suitColor, decimal startingPower, decimal currentPower)
        {
            Id = id;
            Name = name;
            Ability = ability;
            GuidId = guidId;
            StartedTrainDate = DateTime.Now;
            SuitColor = suitColor;
            StartingPower = startingPower;
            CurrentPower = currentPower;
            LastTrainingDate = DateTime.Now;
            TrainingCounter = 0;
        }
    }
}