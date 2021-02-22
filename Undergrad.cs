using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDB
{
    public enum YearRank
    {
        Freshman = 1,
        Sophomore = 2,
        Junior = 3,
        Senior = 4
    }
    internal class Undergrad : Student
    {
        public YearRank Rank { get; set; }
        public string DegreeMajor { get; set; }

        public Undergrad(string first, string last, double gpa, 
                            string email, DateTime enrolled,
                            YearRank rank, string degree)
            : base (first, last, gpa, email, enrolled)
        {
            Rank = rank;
            DegreeMajor = degree;
        }

        // does not go to the output file
        public override string ToString() => base.ToString() + $"      Year: {Rank}\n      Major: {DegreeMajor}\n";

        public override string ToStringForOutputFile()
        {
            string str = this.GetType() + "\n";
            str += base.ToStringForOutputFile();
            str += $"{Rank}\n";
            str += $"{DegreeMajor}";    // no CRLF here because it will be called in WriteLine()

            return str;
        }
    }
}
