# Student Grading System  🎓

A comprehensive, modular C# Console Application designed for academic management. This system provides a centralized platform for handling student records, course configurations, and high-precision grade calculations using Object-Oriented Programming (OOP) principles.

---

## 👥 Team Members
The project was developed and implemented by the following team members:
* **Ahmed Abdelnasser Ahmed**
* **Mohamed Gamal Hussein**
* **Ahmed Hussein El-Sayed**
* **Ahmed Ezz Abo El-Haggag**
* **Tawfik Abdelsalam Fahmy**
* **Ahmed Abo Huraira**

---

## 📝 Project Description
**Student Grading System (SGS)** is a robust backend-focused application. It allows administrators to manage educational data with a focus on data integrity and flexibility in grading standards.

### ✨ Core Features
* **Advanced Grading Policies:** Implements a polymorphic grading engine supporting both **Weighted** and **Percentage-Based** calculations.
* **Data Persistence:** Uses a local file-based storage system (`Courses.txt` and `Students.txt`) to ensure data is saved and reloaded automatically.
* **Dynamic GPA Calculation:** Automatically computes the Cumulative GPA (on a 4.0 scale) based on earned grades and credit hours.
* **Academic Management:** Full CRUD (Create, Read, Update, Delete) functionality for students and courses.
* **Sorting Algorithm:** Features a custom **Bubble Sort** implementation to organize students by their ID for better reporting.

---

## 🛠 Technical Architecture
The system is built following **Object-Oriented Programming (OOP)** principles and uses specific design patterns to ensure modularity:

* **`Program.cs`**: The main entry point managing the user interface, menu logic, and file I/O operations.
* **`Student.cs`**: Manages student attributes, enrollment lists, and the core GPA calculation engine.
* **`Course.cs`**: Defines course properties and manages the application of different grading policies.
* **`GradeComponent.cs`**: Represents individual grading items such as Midterms, Finals, or Quizzes.
* **`GradingPolicy.cs`**: An abstract base class defining the standard for calculation strategies.
* **`WeightedPolicy.cs` & `PercentageBasedPolicy.cs`**: Concrete implementations of specific grading logic.

---

## 🚀 How to Run the Project

### System Requirements
* **.NET SDK 9.0 or 10.0** (Minimum requirement).
* A C# IDE (e.g., Visual Studio 2022) or Terminal.

### Execution Steps
1.  **Launch:** Open the project solution and run the application.
2.  **Course Setup:** Use **Option 1** to add courses and define their grading components.
3.  **Student Enrollment:** Use **Option 2** to register students and assign them to courses.
4.  **Grading:** Use **Option 3** to input scores for specific components.
5.  **Reporting:** Use **Option 8** to generate a detailed success report and view the calculated GPA.
6.  **Termination:** Use **Option 9** to save all progress to the disk before closing.

---

## 📊 UML Class Diagram
Below is the structural representation of the system architecture.

![UML Diagram](https://via.placeholder.com/800x400.png?text=Place+Your+UML+Diagram+Image+Link+Here)

---

## 📂 Data Storage
The system maintains data in the following local text files located in the execution directory:
* `Students.txt`: Stores student IDs, names, and enrolled course data.
* `Courses.txt`: Stores available course definitions and grading structures.

---
*Created as part of Academic Project Luxor FCI - 2026*
