using System;
using System.Collections.Generic;
using System.Text;
using GradeBook.Enums;
using System.Linq;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook : BaseGradeBook
    {
        #region Constructors

        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        #endregion

        #region Methods

        public override char GetLetterGrade(double averageGrade)
        {
            // Implementation
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

        public List<Student> GenerateRankedStudentList()
        {
            List<Student> rankedStudentList = new List<Student>();

            foreach (Student student in Students.OrderByDescending(student => student.AverageGrade))
            {
                rankedStudentList.Add(student);
            }

            return rankedStudentList;
        }

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
