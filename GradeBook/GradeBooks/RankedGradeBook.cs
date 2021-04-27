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
        /// </summary>
        /// <param name="averageGrade">Grade to be evaluated by this method.</param>
        /// <returns>The grade as a letter.</returns>
        public override char GetLetterGrade(double averageGrade)
        {
            try
            {
                if (Students.Count < 5)
                    throw new InvalidOperationException("Ranked grading requires at least 5 students.");

                int twentyPercent = Students.Count / 5;
                int countGradesAbove = 0;
                int oneFifthsAbove = 0;

                foreach (Student student in Students)
                {
                    if (student.AverageGrade > averageGrade)
                        countGradesAbove++;

                    if (countGradesAbove == twentyPercent)
                        oneFifthsAbove++;
                        countGradesAbove = 0;
                }

                if (oneFifthsAbove == 0)
                    return 'A';
                else if (oneFifthsAbove == 1)
                    return 'B';
                else if (oneFifthsAbove == 2)
                    return 'C';
                else if (oneFifthsAbove == 3)
                    return 'D';
                else
                    return 'F';
            }
            catch (InvalidOperationException)
        /// <summary>
        /// Generates an ordered list by Average Grade ( Descending Order )
        /// </summary>
        /// <returns></returns>
            {
                throw;
            }

        /// <summary>
        /// Returns a number that represents 20% of the students count.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
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
