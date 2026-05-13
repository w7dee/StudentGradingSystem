using System;
using System.Collections.Generic;
using System.Text;

namespace StudentGradingSystem
{
    public class Student
    {

        private int studentId;
        private string name;
        private string department;
        public List<Course> Courses { get; private set; }

        public int StudentID
        {
            get { return studentId; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Student ID must be a positive number.");
                studentId = value;
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be empty.");
                name = value;
            }
        }

        public string Department
        {
            get { return department; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Department cannot be empty.");
                department = value;
            }
        }

        public Student(int id, string name, string department)
        {
            StudentID = id;
            Name = name;
            Department = department;

            Courses = new List<Course>();
        }
        public Student()
        {
            studentId = 0;
            name = " " ;
            department =  " ";

            Courses = new List<Course>();
        }




        private double ConvertScoreToGPA(double score)
        {
            if (score >= 90) return 4.0;       
            else if (score >= 85) return 3.7;  
            else if (score >= 80) return 3.3;  
            else if (score >= 75) return 3.0;  
            else if (score >= 70) return 2.7;  
            else if (score >= 65) return 2.4;  
            else if (score >= 60) return 2.0;  
            else if (score >= 50) return 1.0;  
            else return 0.0;                   
        }

        public double CalculateGPA()
        {
            if (Courses.Count == 0)
            {
                return 0.0;
            }

            double totalQualityPoints = 0;
            int totalCreditHours = 0;

            foreach (Course c in Courses)
            {
                double courseScore = c.CalculateTotalScore(c.CourseGradingType);

                if (c.CourseGradingType == Gradingtype.Weighted)
                {
                    courseScore = courseScore * 100;
                }

                double courseGPA = ConvertScoreToGPA(courseScore);

                totalQualityPoints += (courseGPA * c.CreditHours);
                totalCreditHours += c.CreditHours;
            }

            if (totalCreditHours == 0) return 0.0;

            return totalQualityPoints / totalCreditHours;
        }



        public virtual void PrintDetails()
        {

            Console.WriteLine("ID: " + StudentID + " | Name: " + Name + " | Department:" + Department);
           

        }


        public void PrintEnrolledCours()
        {
            Console.Write("Enrolled Courses: ");
            if (Courses.Count == 0)
            {
                Console.WriteLine("None");
            }
            else
            {
                foreach (Course c in Courses)
                {
                    Console.Write(c.CourseName + " , ");
                }
                Console.WriteLine();
            }
        }








    }
}
