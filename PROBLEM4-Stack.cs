using System;
using System.Collections.Generic;

struct Student
{
    public string StudentNumber;
    public string Name;
    public string Program;
    public int YearLevel;
}

struct Operation
{
    public string Action;
    public string StudentNumber;
    public string StudentName;
}

class Program
{
    static void Main()
    {
        Student[] students = new Student[10];
        int studentCount = 0;

        Stack<Operation> operationHistory =
            new Stack<Operation>();

        while (true)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("       OPERATION HISTORY SYSTEM");
            Console.WriteLine("========================================");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Update Student");
            Console.WriteLine("3. Delete Student");
            Console.WriteLine("4. View Operation History");
            Console.WriteLine("5. View Last Operation");
            Console.WriteLine("6. Remove Last Operation");
            Console.WriteLine("7. Exit");
            Console.Write("Enter choice: ");

            string choice = Console.ReadLine();

            Console.Clear();

            if (choice == "1")
            {
                if (studentCount >= 10)
                {
                    Console.WriteLine("Student limit reached.");
                }
                else
                {
                    Console.Write("Enter Student Number: ");
                    string studentNumber = Console.ReadLine();

                    bool duplicate = false;

                    for (int i = 0; i < studentCount; i++)
                    {
                        if (students[i].StudentNumber == studentNumber)
                        {
                            duplicate = true;
                            break;
                        }
                    }

                    if (duplicate)
                    {
                        Console.WriteLine("Student Number already exists.");
                    }
                    else
                    {
                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter Program: ");
                        string program = Console.ReadLine();

                        Console.Write("Enter Year Level: ");
                        int yearLevel = Convert.ToInt32(Console.ReadLine());

                        students[studentCount].StudentNumber = studentNumber;
                        students[studentCount].Name = name;
                        students[studentCount].Program = program;
                        students[studentCount].YearLevel = yearLevel;

                        studentCount++;

                        Operation operation = new Operation();

                        operation.Action = "Added";
                        operation.StudentNumber = studentNumber;
                        operation.StudentName = name;

                        operationHistory.Push(operation);

                        Console.WriteLine("\nStudent added successfully!");
                    }
                }
            }

            else if (choice == "2")
            {
                Console.Write("Enter Student Number to update: ");
                string searchNumber = Console.ReadLine();

                bool found = false;

                for (int i = 0; i < studentCount; i++)
                {
                    if (students[i].StudentNumber == searchNumber)
                    {
                        string studentName = students[i].Name;

                        Console.Write("Enter New Name: ");
                        students[i].Name = Console.ReadLine();

                        Console.Write("Enter New Program: ");
                        students[i].Program = Console.ReadLine();

                        Console.Write("Enter New Year Level: ");
                        students[i].YearLevel =
                            Convert.ToInt32(Console.ReadLine());

                        Operation operation = new Operation();

                        operation.Action = "Updated";
                        operation.StudentNumber = searchNumber;
                        operation.StudentName = studentName;

                        operationHistory.Push(operation);

                        Console.WriteLine("\nStudent updated successfully!");

                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    Console.WriteLine("Student not found.");
                }
            }

            else if (choice == "3")
            {
                Console.Write("Enter Student Number to delete: ");
                string searchNumber = Console.ReadLine();

                int index = -1;

                for (int i = 0; i < studentCount; i++)
                {
                    if (students[i].StudentNumber == searchNumber)
                    {
                        index = i;
                        break;
                    }
                }

                if (index == -1)
                {
                    Console.WriteLine("Student not found.");
                }
                else
                {
                    string studentName = students[index].Name;

                    for (int i = index; i < studentCount - 1; i++)
                    {
                        students[i] = students[i + 1];
                    }

                    studentCount--;

                    Operation operation = new Operation();

                    operation.Action = "Deleted";
                    operation.StudentNumber = searchNumber;
                    operation.StudentName = studentName;

                    operationHistory.Push(operation);

                    Console.WriteLine("Student deleted successfully!");
                }
            }

            else if (choice == "4")
            {
                if (operationHistory.Count == 0)
                {
                    Console.WriteLine("No recorded operations.");
                }
                else
                {
                    Console.WriteLine("========================================");
                    Console.WriteLine("          OPERATION HISTORY");
                    Console.WriteLine("========================================");

                    int number = 1;

                    foreach (Operation operation in operationHistory)
                    {
                        Console.WriteLine(
                            $"{number}. {operation.Action} {operation.StudentName}");

                        Console.WriteLine(
                            $"   Student Number: {operation.StudentNumber}");

                        number++;
                    }
                }
            }

            else if (choice == "5")
            {
                if (operationHistory.Count == 0)
                {
                    Console.WriteLine("No recorded operations.");
                }
                else
                {
                    Operation operation = operationHistory.Peek();

                    Console.WriteLine("Last Operation:");
                    Console.WriteLine(
                        $"{operation.Action} {operation.StudentName}");

                    Console.WriteLine(
                        $"Student Number: {operation.StudentNumber}");
                }
            }

            else if (choice == "6")
            {
                if (operationHistory.Count == 0)
                {
                    Console.WriteLine("No recorded operations.");
                }
                else
                {
                    Operation operation = operationHistory.Pop();

                    Console.WriteLine(
                        $"Removed Operation: {operation.Action} {operation.StudentName}");

                    Console.WriteLine(
                        "Last operation removed successfully!");
                }
            }

            else if (choice == "7")
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