using System;
using System.Collections.Generic;
using System.Text;

namespace StudentGradingSystem
{
    public class PercentageBasedPolicy : GradingPolicy
    {
        public override double CalculateFinalGrade(List<GradeComponent> components)
        {
            float totalScore = 0;
            float totalMaxScore = 0;

            foreach (var component in components)
            {
                totalScore += component.Score;        
                totalMaxScore += component.MaxScore; 
            }

            if (totalMaxScore == 0)
            {
                return 0f;
            }

            return (totalScore / totalMaxScore) * 100f;
        }
    }
}