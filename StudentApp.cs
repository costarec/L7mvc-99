using System;
using System.Collections.Generic;
using System.IO;

namespace StudentDB
{
    internal class StudentApp
    {
        private List<Student> students = new List<Student>();
        internal void ReadDataFromInputFile()
        {
            // create the file
            StreamReader infile = new StreamReader("INPUTDATAFILE.txt");
            string studentType = string.Empty;
            while ((studentType = infile.ReadLine()) != null)
            {
                // reading in the rest of the student record
                string first = infile.ReadLine();
                string last = infile.ReadLine();
                double gpa = double.Parse(infile.ReadLine());
                string email = infile.ReadLine();
                DateTime date = DateTime.Parse(infile.ReadLine());

                // now we've read everything for a student - branch depending
                // on what kind of student
                if(studentType == "StudentDB.Undergrad")
                {
                    YearRank rank = (YearRank)Enum.Parse(typeof(YearRank), infile.ReadLine());
                    string major = infile.ReadLine();

                    Undergrad undergrad = new Undergrad(first, last, gpa, email, date, rank, major);
                    students.Add(undergrad);

                    //Console.WriteLine(undergrad);
                }
                else if(studentType == "StudentDB.GradStudent")
                {
                    decimal tuition = decimal.Parse(infile.ReadLine());
                    string facAdvisor = infile.ReadLine();

                    GradStudent grad = new GradStudent(first, last, gpa, email, date, tuition, facAdvisor);
                    students.Add(grad);
                }

                // create a student object from the read-in data
                // put it in the list of students
                //Student stu = new Student(first, last, gpa, email, date);
                //students.Add(stu);
                //Console.WriteLine($"Done reading record for:\n {stu}");

            }

            Console.WriteLine("Reading input file is complete...");
            infile.Close();
        }

        internal void RunDatabaseApp()
        {
            // display a menu of choices - CRUD operations
            while (true)
            {
                DisplayMainMenu();
                char sel = GetUserSelection();

                switch (sel)
                {
                    case 'P':
                    case 'p':
                        PrintAllRecords();
                        break;
                    case 'A':
                    case 'a':
                        break;
                    case 'D':
                    case 'd':
                        break;
                    case 'M':
                    case 'm':
                        break;
                    case 'E':
                    case 'e':
                        ExitApplicationWithoutSave();
                        break;
                    case 'S':
                    case 's':
                        SaveAllChangesAndQuit();
                        break;
                    default:
                        Console.WriteLine("ERROR: Not a valid input, please select again.");
                        break;
                }
            }
        }

        private void PrintAllRecords()
        {
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }

        private char GetUserSelection()
        {
            ConsoleKeyInfo keyPressed = Console.ReadKey();
            return keyPressed.KeyChar;
        }

        private void SaveAllChangesAndQuit()
        {
            WriteDataOutputFile();
            Environment.Exit(0);
        }

        private void ExitApplicationWithoutSave()
        {
            Environment.Exit(0);
        }

        private void DisplayMainMenu()
        {
            Console.WriteLine(@"
***************************************
**** Student DB Menu ******************
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
[P]rint all records             (R in CRUD)
[A]dd a new student record      (C in CRUD)
[D]elete an existing record     (D in CRUD)
[M]odify an existing record     (U in CRUD)
[E]xit without saving changes
[S]ave all changes and Quit application
");
            Console.Write("ENTER user selction: ");
        }

        internal void WriteDataOutputFile()
        {
            // create the output file details
            StreamWriter outFile = new StreamWriter("OUTPUTFILE.txt");

            foreach (var student in students)
            {
                // using the output file
                outFile.WriteLine(student.ToStringForOutputFile());
                Console.WriteLine(student.ToStringForOutputFile());
                //Console.WriteLine(student);
            }

            // close the output file
            outFile.Close();
        }
    }
}