using StudentGradingSystem;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace StudentGradingSystem
{
     public enum Gradingtype
    {
        Weighted=1 ,
        PercentageBased=2
    }

    public class Course
    {
        private string courseCode;
        private string courseName;
        private int creditHours;
        public List<GradeComponent> Components { get; set; }
        public Gradingtype CourseGradingType { get; set; }
        public Course()
        {
            courseCode = " ";
            courseName = " ";
            creditHours = 0;
            Components = new List<GradeComponent>();
        }
        public Course(string code, string name, int hours)
        {
            CourseCode = code;
            CourseName = name;
            CreditHours = hours;
            Components = new List<GradeComponent>();
        }

        public string CourseCode
        {
            get { return courseCode; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Course Code cannot be empty or null.");
                else
                    courseCode = value;
            }
        }

        public string CourseName
        {
            get { return courseName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Course Name cannot be empty or null.");
                }
                else
                    courseName = value;
            }
        }

        public int CreditHours
        {
            get { return creditHours; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Credit Hours must be greater or equal to zero.");
                else
                    creditHours = value;
            }
        }

        public void AddGradeComponent(GradeComponent component)
        {
            if (component != null)
            {
                Components.Add(component);
            }
            else
            {
                Console.WriteLine("Cannot add an empty grade component.");
            }
        }

        public void DisplayCourseInfo()
        {
            Console.WriteLine("Course Code = " + courseCode + " | Course Name = " + courseName + " | Credit Hours = " + creditHours + " | Grading Type = " + CourseGradingType);
            foreach (GradeComponent c in Components)
            {
                Console.WriteLine("Component Name:" + c.ComponentName );
            }
        }
        public double CalculateTotalScore(Gradingtype choice)
        {
            if (choice == Gradingtype.PercentageBased)
            {
                PercentageBasedPolicy p = new PercentageBasedPolicy();
                return p.CalculateFinalGrade(this.Components);
            }
            else if (choice == Gradingtype.Weighted)
            {
                WeightedPolicy w = new WeightedPolicy();
                return w.CalculateFinalGrade(this.Components);
            }
            return 0;
        }
    }
}