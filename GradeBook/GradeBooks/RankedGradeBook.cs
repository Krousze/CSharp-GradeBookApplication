using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }
            
            int percentile = (int)Math.Floor(Students.Count * .2);
            var actualPercentile = Students.OrderByDescending(i => i.AverageGrade).Select(i => i.AverageGrade).ToList();

            if (averageGrade >= actualPercentile[percentile - 1])
            {
                return 'A';
            }
            if (averageGrade >= actualPercentile[(percentile * 2)- 1])
            {
                return 'B';
            }
            if (averageGrade >= actualPercentile[(percentile * 3) - 1])
            {
                return 'C';
            }
            if (averageGrade >= actualPercentile[(percentile * 4) - 1])
            {
                return 'D';
            }
            return 'F';

        }
    }
}
