using System;
using System.Collections.Generic;
using System.Text;
using GradeBook.Enums;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        #region Constructors

        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Count how many students is 20%. 
        /// Trying to loop through the count and checking how many students have grade above mine. Reduce grade by 1 every 20%.
        /// </summary>
        /// <param name="averageGrade">Compared grade</param>
        /// <returns></returns>
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new Exception("Ranked grading requires at least 5 students.");
            
            int twentyPercent = Students.Count / 5 ;
            int countGradesAbove = 0;

            foreach (Student student in Students)
            {
                if (student.AverageGrade > averageGrade)
                    countGradesAbove++;
            }

            if (countGradesAbove < twentyPercent)
                return 'A';
            else if (countGradesAbove < twentyPercent * 2)
                return 'B';
            else if (countGradesAbove < twentyPercent * 3)
                return 'C';
            else if (countGradesAbove < twentyPercent * 4)
                return 'D';
            else
                return 'F';

        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
                Console.WriteLine("Ranked grading requires at least 5 students.");
            else
                base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
                Console.WriteLine("Ranked grading requires at least 5 students.");
            else
                base.CalculateStudentStatistics(name);
        }

        #endregion

    }
}
