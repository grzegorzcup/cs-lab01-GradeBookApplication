using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook : BaseGradeBook
    {
        RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;

        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5) throw new InvalidOperationException("nie ma tylu studentow");

            int ilosc = (int)Math.Ceiling(Students.Count * 0.2);
            var grades = Students.OrderByDescending(srednia => srednia.AverageGrade).Select(sr => sr.AverageGrade).ToList();

            if (grades[ilosc - 1] <= averageGrade)
                return 'A';
            else if (grades[(ilosc * 2) - 1] <= averageGrade)
                return 'B';
            else if (grades[(ilosc * 3) - 1] <= averageGrade)
                return 'C';
            else if (grades[(ilosc * 4) - 1] <= averageGrade)
                return 'D';
            else return 'F';



        }
    }
}
