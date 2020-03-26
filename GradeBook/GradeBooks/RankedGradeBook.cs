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

        public override void CalculateStatistics()
        {
            if (Students.Count() < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            else
            {
                base.CalculateStatistics();
            }
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count() < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;

            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }
    }
}
