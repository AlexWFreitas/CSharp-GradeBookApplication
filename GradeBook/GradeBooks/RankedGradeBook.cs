using GradeBook.Enums;
using System;

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
            try
            {
                if (Students.Count < 5)
                    throw new InvalidOperationException("Ranked grading requires at least 5 students.");

                int twentyPercent = Students.Count / 5;
                int countGradesAbove = 0;
                int OneFifthsAbove = 0;

                foreach (Student student in Students)
                {
                    if (student.AverageGrade > averageGrade)
                        countGradesAbove++;

                    if (countGradesAbove == twentyPercent)
                        OneFifthsAbove++;
                        countGradesAbove = 0;
                }

                if (OneFifthsAbove == 0)
                    return 'A';
                else if (OneFifthsAbove == 1)
                    return 'B';
                else if (OneFifthsAbove == 2)
                    return 'C';
                else if (OneFifthsAbove == 3)
                    return 'D';
                else
                    return 'F';
            }
            catch (InvalidOperationException)
            {
                throw;
            }

        }

        public override void CalculateStatistics()
        {
            try
            { 
            if (Students.Count < 5)
                throw new InvalidOperationException("Ranked grading requires at least 5 students.");
            else
                base.CalculateStatistics();
            }
            catch (InvalidOperationException)
            {
                throw;
            }
}

        public override void CalculateStudentStatistics(string name)
        {
            try
            {
            if (Students.Count < 5)
                throw new InvalidOperationException("Ranked grading requires at least 5 students.");
            else
                base.CalculateStudentStatistics(name);
            }
            catch (InvalidOperationException)
            {
                throw;
            }
        }

        #endregion

    }
}
