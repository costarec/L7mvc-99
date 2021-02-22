///////////////////////////////////////////////////////////////
// Change History
// Date         Developer       Description
// 2021-02-08   costarella      -design and creation of file, tostring and ctors 
// 2021-02-08   costarella      -add set specific code to some props

using System;

namespace StudentDB
{
    internal class Student
    {
        // definition of the data stored in a POCO student class object
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        private double gradePtAvg;
        private string emailAddress;

        // replace the do nothing no-arg ctor
        public Student()
        {
        }

        // overloading the ctor for student class
        // fully specified ctor for making student POCO objects
        public Student(string first, string last, double grades, string email, DateTime enrolled)
        {
            FirstName = first;
            LastName = last;
            GradePtAvg = grades;
            EmailAddress = email;
            EnrollmentDate = enrolled;
        }

        public double GradePtAvg
        {
            get
            {
                return gradePtAvg;
            }
            set
            {
                if(0 <= value && value <= 4) 
                {
                    // only set the gpa if passed in val is between
                    // "legal" defined GPA range 0 to 4 inclusive
                    gradePtAvg = value;
                }
                else
                {
                    gradePtAvg = 0.7;
                }
            }
        }

        public string EmailAddress
        {
            get
            {
                return emailAddress;
            }
            set
            {
                // passed in email must have at least 3 chars and one must be "@"
                if(value.Contains("@") && value.Length > 3)
                {
                    emailAddress = value;
                }
                else
                {
                    // TODO: not sure how we want to handle this - look into possible regex
                    emailAddress = "ERROR: Invalid email.";
                }
            }
        }

        // format a student object to a string for
        // displaying student data to the user in the UI
        public override string ToString()
        {
            // create a temp string to hold the output
            string str = string.Empty;

            str += "**** Student Record *******************\n";
            // build up the string with data from the object
            str += $"First Name: {FirstName}\n";
            str += $" Last Name: {LastName}\n";
            str += $"       Gpa: {GradePtAvg}\n";
            str += $"     Email: {EmailAddress}\n";
            str += $"  Enrolled: {EnrollmentDate}\n\n";

            // return the string
            return str;
        }

        // format a student object to a string for
        // writing the data to the output file
        public virtual string ToStringForOutputFile()
        {
            // create a temp string to hold the output
            string str = string.Empty;

            // build up the string with data from the object
            str += $"{FirstName}\n";
            str += $"{LastName}\n";
            str += $"{GradePtAvg}\n";
            str += $"{EmailAddress}\n";
            str += $"{EnrollmentDate}\n";

            // return the string
            return str;
        }
    }
}