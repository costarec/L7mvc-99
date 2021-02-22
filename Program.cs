using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDB
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentApp app = new StudentApp();
            app.ReadDataFromInputFile();
            // run the database application and make arbitrary changes
            // to the students
            app.RunDatabaseApp();
        }

        static void TestMain()
        {
            // create 4 student objects for testing
            Student stu1 = new Student();
            // good place to test the properties in student class
            stu1.FirstName = "David";
            stu1.LastName = "Dillon";
            stu1.GradePtAvg = 3.7;
            stu1.EmailAddress = "ddillon@uw.edu";
            stu1.EnrollmentDate = DateTime.Now;

            Student stu2 = new Student("Alice", "Anderson", 4.01, "aanderson@uw.edu", DateTime.Now);
            Student stu3 = new Student("Bob", "Bradshaw", 3.9, "bbradshaw@uw.edu", DateTime.Now);
            Student stu4 = new Student("Carlos", "Castaneda", 3.8, "ccastaneda@uw.edu", DateTime.Now);

            // need a way to print out the data that is in the student objects
            Console.WriteLine(stu1);
            Console.WriteLine(stu2);
            Console.WriteLine(stu3);
            Console.WriteLine(stu4);

            // create the output file details
            StreamWriter outFile = new StreamWriter("OUTPUTFILE.txt");

            // using the output file
            outFile.WriteLine(stu1.ToStringForOutputFile());
            outFile.WriteLine(stu2.ToStringForOutputFile());
            outFile.WriteLine(stu3.ToStringForOutputFile());
            outFile.WriteLine(stu4.ToStringForOutputFile());

            // close the output file
            outFile.Close();
        }
    }
}
