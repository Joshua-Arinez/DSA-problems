using System;

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
        Student[] students = new Student[10];
        int studentCount = 0;

        while (true)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("       STUDENT RECORD MANAGEMENT");
            Console.WriteLine("========================================");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Display All Students");
            Console.WriteLine("3. Search Student");
            Console.WriteLine("4. Update Student");
            Console.WriteLine("5. Delete Student");
            Console.WriteLine("6. Exit");
            Console.Write("Enter choice: ");

            string choice = Console.ReadLine();

            Console.Clear();


            if (choice == "1")
            {
                if (studentCount >= 10)
                {
                    Console.WriteLine("Student limit reached. Cannot add more than 10 students.");
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

                        Console.Write("Enter Year Level (1-4): ");
                        int yearLevel = Convert.ToInt32(Console.ReadLine());

                        students[studentCount].StudentNumber = studentNumber;
                        students[studentCount].Name = name;
                        students[studentCount].Program = program;
                        students[studentCount].YearLevel = yearLevel;

                        studentCount++;

                        Console.WriteLine("\nStudent added successfully!");
                    }
                }
            }

            else if (choice == "2")
            {
                if (studentCount == 0)
                {
                    Console.WriteLine("No student records found.");
                }
                else
                {
                    Console.WriteLine("========================================");
                    Console.WriteLine("           STUDENT RECORDS");
                    Console.WriteLine("========================================");

                    for (int i = 0; i < studentCount; i++)
                    {
                        Console.WriteLine($"Student Number: {students[i].StudentNumber}");
                        Console.WriteLine($"Name: {students[i].Name}");
                        Console.WriteLine($"Program: {students[i].Program}");
                        Console.WriteLine($"Year Level: {students[i].YearLevel}");
                        Console.WriteLine("----------------------------------------");
                    }
                }
            }

            else if (choice == "3")
            {
                Console.Write("Enter Student Number to search: ");
                string searchNumber = Console.ReadLine();

                bool found = false;

                for (int i = 0; i < studentCount; i++)
                {
                    if (students[i].StudentNumber == searchNumber)
                    {
                        Console.WriteLine("\nStudent Found!");
                        Console.WriteLine($"Student Number: {students[i].StudentNumber}");
                        Console.WriteLine($"Name: {students[i].Name}");
                        Console.WriteLine($"Program: {students[i].Program}");
                        Console.WriteLine($"Year Level: {students[i].YearLevel}");

                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    Console.WriteLine("Student not found.");
                }
            }

            else if (choice == "4")
            {
                Console.Write("Enter Student Number to update: ");
                string searchNumber = Console.ReadLine();

                bool found = false;

                for (int i = 0; i < studentCount; i++)
                {
                    if (students[i].StudentNumber == searchNumber)
                    {
                        Console.Write("Enter New Name: ");
                        students[i].Name = Console.ReadLine();

                        Console.Write("Enter New Program: ");
                        students[i].Program = Console.ReadLine();

                        Console.Write("Enter New Year Level (1-4): ");
                        students[i].YearLevel = Convert.ToInt32(Console.ReadLine());

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

            else if (choice == "5")
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
                    for (int i = index; i < studentCount - 1; i++)
                    {
                        students[i] = students[i + 1];
                    }

                    studentCount--;

                    Console.WriteLine("Student deleted successfully!");
                }
            }

            else if (choice == "6")
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