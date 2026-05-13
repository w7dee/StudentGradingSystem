using System;
using System.Collections.Generic;
using System.Text;

namespace StudentGradingSystem
{

        public class WeightedPolicy : GradingPolicy
        {
            public override double CalculateFinalGrade(List<GradeComponent> components)
            {
                double finalGrade = 0;

                foreach (var component in components)
                {
                    if (component.MaxScore > 0)
                    {
                        finalGrade += (component.Score / component.MaxScore) * component.Weight;
                    }
                }

                return finalGrade;
            }
        }
    }