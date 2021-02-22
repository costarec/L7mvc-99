using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDB
{
    internal class GradStudent : Student
    {
        public decimal TuitionCredit { get; set; }
        public string FacultyAdvisor { get; set; }

        public GradStudent(string first, string last, double gpa, 
                            string email, DateTime enrolled, 
                            decimal credit, string advisor)
            : base (first, last, gpa, email, enrolled)
        {
            TuitionCredit = credit;
            FacultyAdvisor = advisor;
        }

        // lambda expression - "=>" reads: "goes to"
        public override string ToString() => base.ToString() + $"    Credit: {TuitionCredit:C}\n       Fac: {FacultyAdvisor}\n";

        public override string ToStringForOutputFile()
        {
            StringBuilder str = new StringBuilder(this.GetType() + "\n");
            str.Append(base.ToStringForOutputFile());
            str.Append($"{TuitionCredit}\n");
            str.Append($"{FacultyAdvisor}");

            return str.ToString();
        }
    }
}
