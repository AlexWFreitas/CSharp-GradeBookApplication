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
        /// Creates a descending list ordered by average grade.
        /// <br></br>
        /// Calculates the number that represents twenty percent.
        /// <br></br>
        /// Verifies if the average grade passed on the method is higher or equal than the bottom 20% of the ranked list.
        /// </summary>
        /// <param name="averageGrade">Grade to be evaluated by this method.</param>
        /// <returns>The grade as a letter.</returns>
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException();

            List<Student> rankedList = GenerateRankedStudentList();
            int twentySplit = CalculateTwentyPercent(rankedList);

            if (averageGrade >= rankedList[twentySplit - 1].AverageGrade)
                return 'A';
            else if (averageGrade >= rankedList[(twentySplit * 2) - 1].AverageGrade)
                return 'B';
            else if (averageGrade >= rankedList[(twentySplit * 3) - 1].AverageGrade)
                return 'C';
            else if (averageGrade >= rankedList[(twentySplit * 4) - 1].AverageGrade)
                return 'D';
            else
                return 'F';
        }

        /// <summary>
        /// Generates an ordered list by Average Grade ( Descending Order )
        /// </summary>
        /// <returns></returns>
        public List<Student> GenerateRankedStudentList()
        {
            List<Student> rankedStudentList = new List<Student>();

            foreach (Student student in Students.OrderByDescending(student => student.AverageGrade))
            {
                rankedStudentList.Add(student);
            }

            return rankedStudentList;
        }

        /// <summary>
        /// Returns a number that represents 20% of the students count.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public int CalculateTwentyPercent(List<Student> list)
        {
            return (list.Count / 5);
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
