using System;
using System.Collections.Generic;
using System.Text;

namespace StudentGradingSystem
{
    public class GradeComponent
    {
        private string componentName;
        private float score;
        private int maxScore;
        private float weight;

        public string ComponentName
        {
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Component Name cannot be empty or null.");
                }
                else
                    componentName = value;
            }
            get { return componentName; }
        }

        public int MaxScore
        {
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Max Score must be greater than zero.");
                }
                else
                    maxScore = value;
            }
            get { return maxScore; }
        }

        public float Score
        {
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Score cannot be negative.");
                }
                else if (value > maxScore)
                {
                    throw new ArgumentException("Score cannot be greater than the Max Score");
                }
                else
                    score = value;
            }
            get { return score; }
        }

        public float Weight
        {
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Weight must be greater than zero.");
                }
                else
                    weight = value;
            }
            get { return weight; }
        }

        public GradeComponent(string _ComponentName, float _Score, int _MaxScore, float _Weight = 1.0f)
        {
            ComponentName = _ComponentName;
            MaxScore = _MaxScore;
            Score = _Score;
            Weight = _Weight;
        }
    }
}
