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
        /// Calculates the number of students that represents a percentage of the total count of the students collection.
        /// </summary>
        /// <param name="percentage">Percentage of the total to be calculated (E.g. 100% = 100)</param>
        /// <returns>Number of students that represents the total</returns>
        private int CalcPercentageOfListCountAsInt(double percentage) => (int)(Math.Round(Students.Count * (percentage * 0.01)));

        /// <summary>
        /// Calculates the number of students that have grade higher than the entered grade.
        /// </summary>
        /// <param name="averageGrade">Grade to be compared</param>
        /// <returns>Number of students with grades higher than the entered grade</returns>
        private int CalcGradesAbove(double averageGrade)
        {
            int AboveGradeCounter = 0;
            foreach (Student student in Students)
                if (student.AverageGrade > averageGrade) AboveGradeCounter++;
            return AboveGradeCounter;
        }

        /// <summary>
        /// Calculates the letter grade that the entered average grade would receive compared to the average grade of all students.
        /// <br></br>
        /// Follows a rule of 0-20/20-40/40-60/60-80% top of the students average grades to assign a letter grade
        /// </summary>
        /// <param name="averageGrade">Average grade to rate</param>
        /// <returns>Letter Grade from grading algorithm</returns>
        public override char GetLetterGrade(double averageGrade)
        {
            try
            {
                if (Students.Count < 5)
                    throw new InvalidOperationException("Ranked grading requires at least 5 students.");

                int countGradesAbove = CalcGradesAbove(averageGrade);

                int twentyPercent = CalcPercentageOfListCountAsInt(20);
                int fourtyPercent = CalcPercentageOfListCountAsInt(40);
                int sixtyPercent = CalcPercentageOfListCountAsInt(60);
                int eightyPercent = CalcPercentageOfListCountAsInt(80);

                if (countGradesAbove < twentyPercent)
                    return 'A';
                if (countGradesAbove < fourtyPercent)
                    return 'B';
                if (countGradesAbove < sixtyPercent)
                    return 'C';
                if (countGradesAbove < eightyPercent)
                    return 'D';
                return 'F';
            }
            catch (InvalidOperationException)
            {
                throw;
            }
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
