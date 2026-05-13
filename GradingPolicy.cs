using System;
using System.Collections.Generic;
using System.Text;

namespace StudentGradingSystem
{
    public abstract class GradingPolicy
    {
        public abstract double CalculateFinalGrade(List<GradeComponent> components);
    }
}
