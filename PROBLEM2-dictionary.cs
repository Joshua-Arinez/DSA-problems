using System;
using System.Collections.Generic;

struct Student
{
    public string StudentNumber;
    public string Name;
    public string Program;
    public int YearLevel;
}

class Program
{
    static void Main()
    {
        Dictionary<string, Student> studentDictionary =
            new Dictionary<string, Student>();

        while (true)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("       STUDENT LOOKUP USING DICTIONARY");
            Console.WriteLine("========================================");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Search Student");
            Console.WriteLine("3. Display All Students");
            Console.WriteLine("4. Exit");
            Console.Write("Enter choice: ");

            string choice = Console.ReadLine();

            Console.Clear();

            if (choice == "1")
            {
                Console.Write("Enter Student Number: ");
                string studentNumber = Console.ReadLine();

                if (studentDictionary.ContainsKey(studentNumber))
                {
                    Console.WriteLine("Student Number already exists.");
                }
                else
                {
                    Console.Write("Enter Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter Program: ");
                    string program = Console.ReadLine();

                    Console.Write("Enter Year Level (1-4): ");
                    int yearLevel = Convert.ToInt32(Console.ReadLine());

                    Student student = new Student();

                    student.StudentNumber = studentNumber;
                    student.Name = name;
                    student.Program = program;
                    student.YearLevel = yearLevel;

                    studentDictionary.Add(studentNumber, student);

                    Console.WriteLine("\nStudent added successfully!");
                }
            }

            else if (choice == "2")
            {
                Console.Write("Enter Student Number to search: ");
                string searchNumber = Console.ReadLine();

                if (studentDictionary.TryGetValue(searchNumber, out Student student))
                {
                    Console.WriteLine("\nStudent Found!");
                    Console.WriteLine($"Student Number: {student.StudentNumber}");
                    Console.WriteLine($"Name: {student.Name}");
                    Console.WriteLine($"Program: {student.Program}");
                    Console.WriteLine($"Year Level: {student.YearLevel}");
                }
                else
                {
                    Console.WriteLine("Student Number does not exist.");
                }
            }

            else if (choice == "3")
            {
                if (studentDictionary.Count == 0)
                {
                    Console.WriteLine("No student records found.");
                }
                else
                {
                    Console.WriteLine("========================================");
                    Console.WriteLine("           STUDENT RECORDS");
                    Console.WriteLine("========================================");

                    foreach (KeyValuePair<string, Student> item in studentDictionary)
                    {
                        Student student = item.Value;

                        Console.WriteLine($"Student Number: {student.StudentNumber}");
                        Console.WriteLine($"Name: {student.Name}");
                        Console.WriteLine($"Program: {student.Program}");
                        Console.WriteLine($"Year Level: {student.YearLevel}");
                        Console.WriteLine("----------------------------------------");
                    }
                }
            }

            else if (choice == "4")
            {
                Console.WriteLine("Program exited.");
                break;
            }

            else
            {
                Console.WriteLine("Invalid choice.");
            }

            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}