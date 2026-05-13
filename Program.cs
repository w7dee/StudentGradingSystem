using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.IO;

namespace StudentGradingSystem
{
    public class Program
    {
        public static List<Course> GlobalCourses = new List<Course>();
        public static List<Student> GlobalStudents = new List<Student>();
        public static void Main(string[] args)
        {
            Load();

            Console.WriteLine("Welcome To Student Mangement System \n \n");
           
            int choice;
            do
            {
                try
                {
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine("1. Add New Course");
                    Console.WriteLine("2. Add New Student");
                    Console.WriteLine("3. Give Student Degree");
                    Console.WriteLine("4. Edit Students");
                    Console.WriteLine("5. Edit Courses");
                    Console.WriteLine("6. Display All Courses");
                    Console.WriteLine("7. Display All Students");
                    Console.WriteLine("8. View Student Final Report");
                    Console.WriteLine("9. Save & Exit ");
                    Console.WriteLine("----------------------------------\n");
                    Console.Write("Enter your choice: ");
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            AddNewCousre();
                            break;
                        case 2:
                            AddNewStudent();
                            break;
                        case 3:
                            GiveStudentDegree();
                            break;
                        case 4:
                            EditStudent();
                            break;
                        case 5:
                            EditCourse();
                            break;
                        case 6:
                            DisplayAllCourses();
                            break;
                        case 7:
                            DisplayAllStudent();
                            break;
                        case 8:
                            StudentFinalRep();
                            break;
                        case 9:
                            SaveExit();
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please choose 1-7.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input! Please enter a valid number.");
                    choice = 0;
                }

            } while (choice != 9);
        }
        public static void AddNewCousre()
        {
            Console.WriteLine("--------------");
            Console.WriteLine("Add New Course");
            Console.WriteLine("--------------");


            Course course = new Course();
            bool isValid;

            do
            {
                isValid = true;
                try
                {
                    Console.Write("Please Enter Course Code: ");
                    course.CourseCode = Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    isValid = false;
                }
            } while (!isValid);

            do
            {
                isValid = true;
                try
                {
                    Console.Write("Please Enter Course Name: ");
                    course.CourseName = Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    isValid = false;
                }
            } while (!isValid);

            do
            {
                isValid = true;
                try
                {
                    Console.Write("Please Enter Credit Hours: ");
                    course.CreditHours = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: Please enter a valid positive number.");
                    isValid = false;
                }
            } while (!isValid);
            Gradingtype selectedType;
            do
            {
                isValid = true;
                try
                {
                    Console.WriteLine("What is the Grading System for this course?");
                    Console.WriteLine("1. Weighted \t 2. Percentage ");
                    int choice = int.Parse(Console.ReadLine());

                    if (choice == 1)
                    {
                        course.CourseGradingType = Gradingtype.Weighted;
                        Console.WriteLine("System set to: Weighted");
                    }
                    else if (choice == 2)
                    {
                        course.CourseGradingType = Gradingtype.PercentageBased;
                        Console.WriteLine("System set to: Percentage");
                    }
                    else
                    {
                        throw new Exception("Please choose 1 or 2 only.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    isValid = false;
                }
            } while (!isValid);
            int componentsCount = 0;
            bool isValidCount = false;
            while (!isValidCount)
            {
                try
                {
                    Console.Write("How many grade components does this course have? ");
                    componentsCount = int.Parse(Console.ReadLine());
                    if (componentsCount < 0) throw new Exception("Number of components cannot be negative.");
                    isValidCount = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            for (int i = 0; i < componentsCount; i++)
            {
                Console.WriteLine("\n--- Entering details for Component #" + (i + 1) + " ---");
                bool isValidComponent = false;
                while (!isValidComponent)
                {
                    try
                    {
                        Console.Write("Enter Component Name: ");
                        string compName = Console.ReadLine();

                        Console.Write("Enter Max Score (like 20): ");
                        int maxScore = int.Parse(Console.ReadLine());

                        Console.Write("Enter Weight (like 0.4 for 40%): ");
                        float weight = float.Parse(Console.ReadLine());


                        GradeComponent newComponent = new GradeComponent(compName, 0, maxScore, weight);

                        course.AddGradeComponent(newComponent);
                        Console.WriteLine("Component "+compName+ " added successfully!");

                        isValidComponent = true;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Input Error: Please enter valid numbers for Score and Weight.");
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine("Validation Error: " + ex.Message);
                    }
                }
            }
            GlobalCourses.Add(course);
            Console.WriteLine("Course Added Successfully!");
        }
        public static void AddNewStudent()
        {
            Console.WriteLine("--------------");
            Console.WriteLine("Add New Student");
            Console.WriteLine("--------------");
            Student student = new Student();
            bool isValid;
            bool ifNorbreak = false;
            do
            {
                isValid = true;
                try
                {
                    Console.Write("Please Enter Student ID (number id): ");
                    int enteredId = int.Parse(Console.ReadLine());
                    bool isDuplicate = false;
                    foreach (Student s in GlobalStudents)
                    {
                        if (s.StudentID == enteredId)
                        {
                            isDuplicate = true;
                            break;
                        }
                    }

                    if (isDuplicate)
                    {
                        throw new Exception("Error: This ID already exists! Please enter a different ID.");
                    }
                    student.StudentID = enteredId;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    isValid = false;
                }
            } while (!isValid);
            do
            {
                isValid = true;
                try
                {
                    Console.Write("Please Enter Student Name: ");
                    student.Name = Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    isValid = false;
                }
            } while (!isValid);
            do
            {
                isValid = true;
                try
                {
                    Console.Write("Please Enter Student Depatment: ");
                    student.Department = Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    isValid = false;
                }
            } while (!isValid);

            int numCourses = 0;
            do
            {
                isValid = true;
                try
                {
                    Console.Write("How many courses will this student take? ");
                    numCourses = int.Parse(Console.ReadLine());
                    if (numCourses <= 0)
                    {
                        throw new Exception("Number of courses cannot be negative or equal to zero");

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    isValid = false;
                }
            } while (!isValid);

            for (int i = 0; i < numCourses; i++)
            {
                if (GlobalCourses.Count == 0)
                {
                    Console.WriteLine("Warning: No courses available in the system. Please add courses first.");
                    break;
                }
                ifNorbreak = true;
                Console.WriteLine("Available Courses (Select course #" + (i + 1) + ":");

                for (int j = 0; j < GlobalCourses.Count; j++)
                {
                    Console.WriteLine((j+1)+"."+GlobalCourses[j].CourseName +"("+GlobalCourses[j].CourseCode+")");
                }

                int courseChoice = 0;
                do
                {
                    isValid = true;
                    try
                    {
                        Console.Write("Enter the number of the course to add: ");
                        courseChoice = int.Parse(Console.ReadLine());

                        if (courseChoice < 1 || courseChoice > GlobalCourses.Count)
                        {
                            throw new Exception("Please choose a number between 1 and " + GlobalCourses.Count);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                        isValid = false;
                    }
                } while (!isValid);
                Course originalCourse = GlobalCourses[courseChoice - 1];
                Course studentCourse = new Course(originalCourse.CourseCode, originalCourse.CourseName, originalCourse.CreditHours);
                studentCourse.CourseGradingType = originalCourse.CourseGradingType;
                foreach (GradeComponent comp in originalCourse.Components)
                {
                    GradeComponent newComp = new GradeComponent(comp.ComponentName, 0, comp.MaxScore, comp.Weight);
                    studentCourse.AddGradeComponent(newComp);
                }
                student.Courses.Add(studentCourse);
                Console.WriteLine("Successfully enrolled in: " + studentCourse.CourseName);
            }
            if (ifNorbreak)
            {
                GlobalStudents.Add(student);
                Console.WriteLine("Student Added Successfully!");
            }
        }
        public static void GiveStudentDegree()
        {
            Console.WriteLine("--------------");
            Console.WriteLine("Give A Student Degree");
            Console.WriteLine("--------------");

            bool isValidId = false;
            int id = 0;

            do
            {
                try
                {
                    Console.Write("Enter Student Id: ");
                    id = int.Parse(Console.ReadLine());
                    isValidId = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Input! Please enter a valid number.");
                }
            } while (!isValidId);

            Student targetStudent = null;
            foreach (Student s in GlobalStudents)
            {
                if (s.StudentID == id)
                {
                    targetStudent = s;
                    break;
                }
            }

            if (targetStudent == null)
            {
                Console.WriteLine("Student not found! Returning to main menu...");
                return;
            }

            Console.WriteLine("\nStudent Found: " + targetStudent.Name);

            if (targetStudent.Courses.Count == 0)
            {
                Console.WriteLine("This student is not enrolled in any courses.");
                return;
            }

            Console.WriteLine("\nPlease select a course to grade:");
            for (int i = 0; i < targetStudent.Courses.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + targetStudent.Courses[i].CourseName + " (" + targetStudent.Courses[i].CourseCode + ")");
            }

            int courseChoice = 0;
            bool validCourse = false;
            do
            {
                try
                {
                    Console.Write("\nEnter Course Number: ");
                    courseChoice = int.Parse(Console.ReadLine());

                    if (courseChoice < 1 || courseChoice > targetStudent.Courses.Count)
                    {
                        Console.WriteLine("Invalid choice. Please select a number from the list.");
                    }
                    else
                    {
                        validCourse = true;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid number.");
                }
            } while (!validCourse);

            Course selectedCourse = targetStudent.Courses[courseChoice - 1];
            Console.WriteLine("\n--- Entering grades for: " + selectedCourse.CourseName + " ---");

            foreach (GradeComponent comp in selectedCourse.Components)
            {
                bool validScore = false;
                do
                {
                    try
                    {
                        Console.Write("Enter score for " + comp.ComponentName + " (Max: " + comp.MaxScore + "): ");
                        float enteredScore = float.Parse(Console.ReadLine());

                        comp.Score = enteredScore;
                        validScore = true;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Error: Please enter a valid number.");
                    }
                    catch (ArgumentException ex) 
                    {
                        Console.WriteLine("Validation Error: " + ex.Message);
                    }
                } while (!validScore);
            }

            Console.WriteLine("\nGrades updated successfully for " + targetStudent.Name + "!");
        }

        public static void EditStudent()
        {
            Console.WriteLine("--------------");
            Console.WriteLine("Edit Student");
            Console.WriteLine("--------------");

            Student targetStudent = null;
            bool isFound = false;

            try
            {
                Console.Write("Please Enter Student ID (number id): ");
                int enteredId = int.Parse(Console.ReadLine());

                foreach (Student s in GlobalStudents)
                {
                    if (s.StudentID == enteredId)
                    {
                        targetStudent = s;
                        isFound = true;
                        break;
                    }
                }

                if (targetStudent == null)
                {
                    throw new Exception("Student Not Found");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Error: Please enter numbers only. " + ex.Message);
                return; 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return; 
            }

            if (isFound == true)
            {
                Console.WriteLine("=============");
                Console.WriteLine("Student Info");
                Console.WriteLine("=============");

                targetStudent.PrintDetails();

                Console.WriteLine("=============");
                Console.WriteLine("Edit Student");
                Console.WriteLine("=============");
                Console.WriteLine("1. Edit Name");
                Console.WriteLine("2. Edit Department");
                Console.WriteLine("3. Edit Courses (Add/Remove)");
                Console.WriteLine("4. Delete student");

                int choice;

                try
                {
                    Console.Write("Enter your choice: ");
                    choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            bool namevalid = true;
                            try
                            {
                                Console.Write("Enter Your Name: ");
                                targetStudent.Name = Console.ReadLine();
                                Console.WriteLine("Name Has Edited Successfully");
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Error: " + e.Message);
                                namevalid = false;
                            }
                            break;

                        case 2:
                            bool depvalid = true;
                            try
                            {
                                Console.Write("Enter Your Department: ");
                                targetStudent.Department = Console.ReadLine();
                                Console.WriteLine("Department has edited successfully");
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Error: " + e.Message);
                                depvalid = false;
                            }
                            break;

                        case 3:
                            Console.WriteLine("\n--- Edit Enrolled Courses ---");
                            Console.WriteLine("1. Add a New Course");
                            Console.WriteLine("2. Remove an Existing Course");
                            Console.Write("Enter your choice: ");

                            try
                            {
                                int courseEditChoice = int.Parse(Console.ReadLine());

                                if (courseEditChoice == 1)
                                {
                                    if (GlobalCourses.Count == 0)
                                    {
                                        Console.WriteLine("No courses available in the system to add.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nAvailable Courses:");
                                        for (int i = 0; i < GlobalCourses.Count; i++)
                                        {
                                            Console.WriteLine((i + 1) + ". " + GlobalCourses[i].CourseName + " (" + GlobalCourses[i].CourseCode + ")");
                                        }

                                        Console.Write("\nEnter the number of the course to add: ");
                                        int courseChoice = int.Parse(Console.ReadLine());

                                        if (courseChoice >= 1 && courseChoice <= GlobalCourses.Count)
                                        {
                                            Course originalCourse = GlobalCourses[courseChoice - 1];

                                            bool alreadyEnrolled = false;
                                            foreach (Course c in targetStudent.Courses)
                                            {
                                                if (c.CourseCode == originalCourse.CourseCode)
                                                {
                                                    alreadyEnrolled = true;
                                                    break;
                                                }
                                            }

                                            if (alreadyEnrolled)
                                            {
                                                Console.WriteLine("Error: Student is already enrolled in this course!");
                                            }
                                            else
                                            {
                                                Course studentCourse = new Course(originalCourse.CourseCode, originalCourse.CourseName, originalCourse.CreditHours);
                                                studentCourse.CourseGradingType = originalCourse.CourseGradingType;

                                                foreach (GradeComponent comp in originalCourse.Components)
                                                {
                                                    GradeComponent newComp = new GradeComponent(comp.ComponentName, 0, comp.MaxScore, comp.Weight);
                                                    studentCourse.AddGradeComponent(newComp);
                                                }

                                                targetStudent.Courses.Add(studentCourse);
                                                Console.WriteLine("Course added to student successfully!");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid course number.");
                                        }
                                    }
                                }
                                else if (courseEditChoice == 2)
                                {
                                    if (targetStudent.Courses.Count == 0)
                                    {
                                        Console.WriteLine("Student has no enrolled courses to remove.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nStudent's Enrolled Courses:");
                                        for (int i = 0; i < targetStudent.Courses.Count; i++)
                                        {
                                            Console.WriteLine((i + 1) + ". " + targetStudent.Courses[i].CourseName + " (" + targetStudent.Courses[i].CourseCode + ")");
                                        }

                                        Console.Write("\nEnter the number of the course to remove: ");
                                        int removeChoice = int.Parse(Console.ReadLine());

                                        if (removeChoice >= 1 && removeChoice <= targetStudent.Courses.Count)
                                        {
                                            targetStudent.Courses.RemoveAt(removeChoice - 1);
                                            Console.WriteLine("Course removed from student successfully!");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid course number.");
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid choice.");
                                }
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Error: Please enter a valid number.");
                            }
                            break;

                        case 4:
                            Console.WriteLine("Are you Sure you want to delete this student?");
                            Console.WriteLine("Yes(y) / No(n)");

                            try
                            {
                                char confirm = char.Parse(Console.ReadLine().ToLower()); 

                                if (confirm == 'y')
                                {
                                    GlobalStudents.Remove(targetStudent);
                                    Console.WriteLine("Student has deleted Successfully.");
                                    return;
                                }
                                else if (confirm == 'n')
                                {
                                    Console.WriteLine("Deletion Cancelled");
                                }
                                else
                                {
                                    Console.WriteLine("Wrong Choice");
                                }
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Error: Invalid input. Deletion cancelled.");
                            }
                            break;

                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }catch (FormatException)
                {
                    Console.WriteLine("Error: Please enter a valid number from the menu.");
                }
            }
        }
        public static void EditCourse()
        {
            Console.WriteLine("--------------");
            Console.WriteLine("Edit Course");
            Console.WriteLine("--------------");

            try
            {
                Console.Write("Please Enter Course Code: ");
                string code = Console.ReadLine();

                Course targetCourse = null;

                foreach (Course c in GlobalCourses)
                {
                    if (c.CourseCode == code)
                    {
                        targetCourse = c;
                        break;
                    }
                }

                if (targetCourse == null)
                {
                    Console.WriteLine("Course Not Found.");
                    return;
                }

                targetCourse.DisplayCourseInfo();

                Console.WriteLine("\n1. Edit Course Name");
                Console.WriteLine("2. Edit Credit Hours");
                Console.WriteLine("3. Delete Course");
                Console.Write("Enter your choice =  ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter New Course Name: ");
                        targetCourse.CourseName = Console.ReadLine();
                        Console.WriteLine("Course Name Updated!");
                        break;

                    case 2:
                        Console.Write("Enter New Credit Hours: ");
                        targetCourse.CreditHours = int.Parse(Console.ReadLine());
                        Console.WriteLine("Credit Hours Updated!");
                        break;

                    case 3:
                        GlobalCourses.Remove(targetCourse);
                        Console.WriteLine("Course Deleted Successfully from the system catalog!");
                        break;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter valid numbers where required.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        public static void DisplayAllCourses()
        {
            Console.WriteLine("----- All Our Courses -----\n");
            for (int i = 0; i < GlobalCourses.Count; i++)
            {
                Console.WriteLine("--- Course #" + (i + 1) + " ---");
                GlobalCourses[i].DisplayCourseInfo();
            }
        }
        public static void DisplayAllStudent()
        {
            Console.WriteLine("----- All Our Student -----\n");
            SortStudentsById();
            for (int i = 0; i < GlobalStudents.Count; i++)
            {
                Console.WriteLine("--- Student #" + (i + 1) + " ---");
                GlobalStudents[i].PrintDetails();
                GlobalStudents[i].PrintEnrolledCours();
                Console.WriteLine();
            }
        }
        public static void StudentFinalRep()
        {
            Console.WriteLine("---------------------");
            Console.WriteLine("Student Final Report");
            Console.WriteLine("---------------------");

            try
            {
                Console.Write("Enter Student ID: ");
                int id = int.Parse(Console.ReadLine());

                Student targetStudent = null;
                foreach (Student s in GlobalStudents)
                {
                    if (s.StudentID == id)
                    {
                        targetStudent = s;
                        break;
                    }
                }

                if (targetStudent == null)
                {
                    Console.WriteLine("Student Not Found.");
                    return;
                }

                targetStudent.PrintDetails();
                Console.WriteLine("----------------------------------");

                Console.WriteLine("Courses and Grades:");
                foreach (Course c in targetStudent.Courses)
                {
                    double totalScore = c.CalculateTotalScore(c.CourseGradingType);

                    if (c.CourseGradingType == Gradingtype.Weighted)
                    {
                        totalScore = totalScore * 100;
                    }

                    Console.WriteLine("- " + c.CourseName + " : " + totalScore + " / 100");
                }

                Console.WriteLine("----------------------------------");

                double finalGPA = targetStudent.CalculateGPA();
                Console.WriteLine("Final Cumulative GPA: " + finalGPA + " / 4.0");

                if (finalGPA >= 2.0)
                {
                    Console.WriteLine("Status: Passed");
                }
                else
                {
                    Console.WriteLine("Status: Failed");
                }

                Console.WriteLine("----------------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        public static void Save()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("Courses.txt"))
                {
                    foreach (Course c in GlobalCourses)
                    {
                        string courseLine = c.CourseCode + "|" + c.CourseName + "|" + c.CreditHours + "|" + (int)c.CourseGradingType;

                        courseLine += "|";
                        foreach (GradeComponent comp in c.Components)
                        {
                            courseLine += comp.ComponentName + ":" + comp.MaxScore + ":" + comp.Weight + ";";
                        }
                        sw.WriteLine(courseLine.TrimEnd(';'));
                    }
                }

                using (StreamWriter sw = new StreamWriter("Students.txt"))
                {
                    foreach (Student s in GlobalStudents)
                    {
                        string studentLine = s.StudentID + "|" + s.Name + "|" + s.Department + "|";

                        foreach (Course sc in s.Courses)
                        {
                            studentLine += sc.CourseCode + "*" + sc.CourseName + "*" + sc.CreditHours + "*" + (int)sc.CourseGradingType + "*";

                            foreach (GradeComponent gc in sc.Components)
                            {
                                studentLine += gc.ComponentName + "^" + gc.Score + "^" + gc.MaxScore + "^" + gc.Weight + "~";
                            }
                            studentLine = studentLine.TrimEnd('~') + "#"; 
                        }
                        sw.WriteLine(studentLine.TrimEnd('#'));
                    }
                }
                Console.WriteLine("Data Saved Successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Saving Data: " + ex.Message);
            }
        }
        public static void Load()
        {
            try
            {
                if (File.Exists("Courses.txt"))
                {
                    GlobalCourses.Clear();
                    string[] lines = File.ReadAllLines("Courses.txt");
                    foreach (string line in lines)
                    {
                        string[] parts = line.Split('|');
                        Course c = new Course(parts[0], parts[1], int.Parse(parts[2]));
                        c.CourseGradingType = (Gradingtype)int.Parse(parts[3]);

                        if (parts.Length > 4)
                        {
                            string[] comps = parts[4].Split(';');
                            foreach (string compStr in comps)
                            {
                                string[] cParts = compStr.Split(':');
                                c.AddGradeComponent(new GradeComponent(cParts[0], 0, int.Parse(cParts[1]), float.Parse(cParts[2])));
                            }
                        }
                        GlobalCourses.Add(c);
                    }
                }

                if (File.Exists("Students.txt"))
                {
                    GlobalStudents.Clear();
                    string[] lines = File.ReadAllLines("Students.txt");
                    foreach (string line in lines)
                    {
                        string[] parts = line.Split('|');
                        Student s = new Student(int.Parse(parts[0]), parts[1], parts[2]);

                        if (parts.Length > 3 && !string.IsNullOrWhiteSpace(parts[3]))
                        {
                            string[] coursesData = parts[3].Split('#');
                            foreach (string cData in coursesData)
                            {
                                string[] cParts = cData.Split('*');
                                Course sc = new Course(cParts[0], cParts[1], int.Parse(cParts[2]));
                                sc.CourseGradingType = (Gradingtype)int.Parse(cParts[3]);

                                string[] allComps = cParts[4].Split('~');
                                foreach (string gcData in allComps)
                                {
                                    string[] gcParts = gcData.Split('^');
                                    sc.AddGradeComponent(new GradeComponent(gcParts[0], float.Parse(gcParts[1]), int.Parse(gcParts[2]), float.Parse(gcParts[3])));
                                }
                                s.Courses.Add(sc);
                            }
                        }
                        GlobalStudents.Add(s);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Loading Data: " + ex.Message);
            }
        }

        public static void SaveExit()
        {
            Console.WriteLine("Saving data before exit...");
            Save();
            Console.WriteLine("Goodbye!");
            Environment.Exit(0);
        }
        public static void SortStudentsById()
        {
            for (int i = 0; i < GlobalStudents.Count - 1; i++)
            {
                for (int j = 0; j < GlobalStudents.Count - i - 1; j++)
                {
                    if (GlobalStudents[j].StudentID > GlobalStudents[j + 1].StudentID)
                    {
                        Student temp = GlobalStudents[j];
                        GlobalStudents[j] = GlobalStudents[j + 1];
                        GlobalStudents[j + 1] = temp;
                    }
                }
            }
        }

    }
}