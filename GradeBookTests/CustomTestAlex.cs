using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using GradeBook;
using GradeBook.Enums;
using Xunit;

namespace GradeBookTests
{
    public class CustomTestAlex
    {
        [Fact(DisplayName = "Second 20 Percent Lower Limit Gets An B")]
        public void SecondTwentyPercentTestLowerLimit()
        {
            // Setup Test
            var rankedGradeBook = TestHelpers.GetUserType("GradeBook.GradeBooks.RankedGradeBook");
            Assert.True(rankedGradeBook != null, "`RankedGradeBook` wasn't found in the `GradeBooks.GradeBook` namespace.");

            var constructor = rankedGradeBook.GetConstructors().FirstOrDefault();
            var parameters = constructor.GetParameters();
            object gradeBook = null;
            if (parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool))
                gradeBook = Activator.CreateInstance(rankedGradeBook, "Test GradeBook", true);
            else if (parameters.Count() == 1 && parameters[0].ParameterType == typeof(string))
                gradeBook = Activator.CreateInstance(rankedGradeBook, "Test GradeBook");

            MethodInfo method = rankedGradeBook.GetMethod("GetLetterGrade");

            //Setup successful conditions
            var students = new List<Student>
            {
                new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 99 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 1 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 2 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 3 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 4 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 5 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 6 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 7 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 8 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 9 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 10 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 11 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 12 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 13 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 14 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 15 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 16 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 17 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 18 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 19 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 20 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 21 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 22 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 23 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 24 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 25 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 26 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 27 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 28 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 29 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 30 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 31 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 32 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 33 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 34 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 35 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 36 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 37 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 38 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 39 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 40 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 41 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 42 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 100 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 43 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 44 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 45 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 46 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 47 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 48 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 49 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 50 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 51 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 52 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 53 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 54 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 55 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 56 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 57 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 58 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 59 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 60 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 61 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 62 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 63 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 64 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 65 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 66 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 67 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 68 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 69 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 70 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 71 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 72 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 73 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 74 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 75 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 76 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 77 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 78 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 79 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 80 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 81 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 82 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 83 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 84 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 85 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 86 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 87 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 88 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 89 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 90 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 91 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 92 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 93 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 94 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 95 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 96 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 97 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 98 }
                }
            };

            gradeBook.GetType().GetProperty("Students").SetValue(gradeBook, students);

            Assert.True((char)method.Invoke(gradeBook, new object[] { 61 }) == 'B', "`GradeBook.GradeBooks.RankedGradeBook.GetLetterGrade` didn't give an B to students between the top 20 and 40% of the class.");
        }

        [Fact(DisplayName = "Second 20 Percent Lower Limit Under Gets a C")]
        public void SecondTwentyPercentTestLowerLimitUnder()
        {
            // Setup Test
            var rankedGradeBook = TestHelpers.GetUserType("GradeBook.GradeBooks.RankedGradeBook");
            Assert.True(rankedGradeBook != null, "`RankedGradeBook` wasn't found in the `GradeBooks.GradeBook` namespace.");

            var constructor = rankedGradeBook.GetConstructors().FirstOrDefault();
            var parameters = constructor.GetParameters();
            object gradeBook = null;
            if (parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool))
                gradeBook = Activator.CreateInstance(rankedGradeBook, "Test GradeBook", true);
            else if (parameters.Count() == 1 && parameters[0].ParameterType == typeof(string))
                gradeBook = Activator.CreateInstance(rankedGradeBook, "Test GradeBook");

            MethodInfo method = rankedGradeBook.GetMethod("GetLetterGrade");

            //Setup successful conditions
            var students = new List<Student>
            {
                new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 99 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 1 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 2 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 3 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 4 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 5 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 6 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 7 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 8 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 9 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 10 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 11 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 12 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 13 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 14 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 15 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 16 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 17 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 18 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 19 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 20 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 21 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 22 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 23 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 24 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 25 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 26 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 27 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 28 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 29 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 30 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 31 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 32 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 33 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 34 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 35 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 36 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 37 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 38 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 39 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 40 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 41 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 42 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 100 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 43 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 44 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 45 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 46 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 47 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 48 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 49 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 50 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 51 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 52 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 53 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 54 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 55 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 56 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 57 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 58 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 59 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 60 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 61 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 62 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 63 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 64 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 65 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 66 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 67 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 68 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 69 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 70 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 71 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 72 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 73 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 74 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 75 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 76 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 77 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 78 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 79 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 80 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 81 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 82 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 83 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 84 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 85 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 86 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 87 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 88 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 89 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 90 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 91 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 92 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 93 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 94 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 95 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 96 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 97 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 98 }
                }
            };

            gradeBook.GetType().GetProperty("Students").SetValue(gradeBook, students);

            Assert.True((char)method.Invoke(gradeBook, new object[] { 60 }) == 'C', "`GradeBook.GradeBooks.RankedGradeBook.GetLetterGrade` didn't give an C to students between the top 40 and 60% of the class.");
        }


        [Fact(DisplayName = "Second 20 Percent Upper Limit Gets An B")]
        public void SecondTwentyPercentTestUpperLimit()
        {
            // Setup Test
            var rankedGradeBook = TestHelpers.GetUserType("GradeBook.GradeBooks.RankedGradeBook");
            Assert.True(rankedGradeBook != null, "`RankedGradeBook` wasn't found in the `GradeBooks.GradeBook` namespace.");

            var constructor = rankedGradeBook.GetConstructors().FirstOrDefault();
            var parameters = constructor.GetParameters();
            object gradeBook = null;
            if (parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool))
                gradeBook = Activator.CreateInstance(rankedGradeBook, "Test GradeBook", true);
            else if (parameters.Count() == 1 && parameters[0].ParameterType == typeof(string))
                gradeBook = Activator.CreateInstance(rankedGradeBook, "Test GradeBook");

            MethodInfo method = rankedGradeBook.GetMethod("GetLetterGrade");

            //Setup successful conditions
            var students = new List<Student>
            {
                new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 99 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 1 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 2 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 3 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 4 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 5 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 6 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 7 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 8 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 9 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 10 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 11 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 12 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 13 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 14 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 15 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 16 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 17 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 18 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 19 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 20 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 21 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 22 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 23 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 24 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 25 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 26 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 27 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 28 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 29 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 30 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 31 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 32 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 33 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 34 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 35 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 36 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 37 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 38 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 39 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 40 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 41 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 42 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 100 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 43 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 44 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 45 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 46 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 47 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 48 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 49 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 50 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 51 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 52 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 53 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 54 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 55 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 56 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 57 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 58 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 59 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 60 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 61 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 62 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 63 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 64 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 65 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 66 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 67 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 68 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 69 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 70 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 71 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 72 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 73 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 74 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 75 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 76 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 77 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 78 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 79 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 80 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 81 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 82 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 83 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 84 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 85 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 86 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 87 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 88 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 89 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 90 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 91 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 92 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 93 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 94 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 95 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 96 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 97 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 98 }
                }
            };

            gradeBook.GetType().GetProperty("Students").SetValue(gradeBook, students);

            Assert.True((char)method.Invoke(gradeBook, new object[] { 80 }) == 'B', "`GradeBook.GradeBooks.RankedGradeBook.GetLetterGrade` didn't give an B to students between the top 20 and 40% of the class.");
        }

        [Fact(DisplayName = "Exact 20th Percent Gets an A")]
        public void SecondTwentyPercentTestUpperLimitOverByOne()
        {
            // Setup Test
            var rankedGradeBook = TestHelpers.GetUserType("GradeBook.GradeBooks.RankedGradeBook");
            Assert.True(rankedGradeBook != null, "`RankedGradeBook` wasn't found in the `GradeBooks.GradeBook` namespace.");

            var constructor = rankedGradeBook.GetConstructors().FirstOrDefault();
            var parameters = constructor.GetParameters();
            object gradeBook = null;
            if (parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool))
                gradeBook = Activator.CreateInstance(rankedGradeBook, "Test GradeBook", true);
            else if (parameters.Count() == 1 && parameters[0].ParameterType == typeof(string))
                gradeBook = Activator.CreateInstance(rankedGradeBook, "Test GradeBook");

            MethodInfo method = rankedGradeBook.GetMethod("GetLetterGrade");

            //Setup successful conditions
            var students = new List<Student>
            {
                new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 99 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 1 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 2 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 3 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 4 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 5 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 6 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 7 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 8 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 9 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 10 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 11 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 12 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 13 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 14 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 15 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 16 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 17 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 18 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 19 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 20 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 21 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 22 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 23 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 24 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 25 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 26 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 27 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 28 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 29 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 30 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 31 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 32 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 33 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 34 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 35 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 36 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 37 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 38 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 39 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 40 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 41 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 42 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 100 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 43 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 44 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 45 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 46 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 47 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 48 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 49 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 50 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 51 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 52 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 53 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 54 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 55 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 56 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 57 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 58 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 59 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 60 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 61 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 62 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 63 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 64 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 65 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 66 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 67 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 68 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 69 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 70 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 71 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 72 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 73 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 74 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 75 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 76 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 77 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 78 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 79 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 80 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 81 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 82 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 83 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 84 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 85 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 86 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 87 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 88 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 89 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 90 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 91 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 92 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 93 }
                },new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 94 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 95 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 96 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 97 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 98 }
                }
            };

            gradeBook.GetType().GetProperty("Students").SetValue(gradeBook, students);

            Assert.True((char)method.Invoke(gradeBook, new object[] { 81 }) == 'A', "`GradeBook.GradeBooks.RankedGradeBook.GetLetterGrade` didn't give an A to students in the top 20% of the class.");
        }
        [Fact(DisplayName = "Seven students - Grade Test for 0-20/20-40/40-60")]
        public void SevenStudentsGradeCTest()
        {
            // Setup Test
            var rankedGradeBook = TestHelpers.GetUserType("GradeBook.GradeBooks.RankedGradeBook");
            Assert.True(rankedGradeBook != null, "`RankedGradeBook` wasn't found in the `GradeBooks.GradeBook` namespace.");

            var constructor = rankedGradeBook.GetConstructors().FirstOrDefault();
            var parameters = constructor.GetParameters();
            object gradeBook = null;
            if (parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool))
                gradeBook = Activator.CreateInstance(rankedGradeBook, "Test GradeBook", true);
            else if (parameters.Count() == 1 && parameters[0].ParameterType == typeof(string))
                gradeBook = Activator.CreateInstance(rankedGradeBook, "Test GradeBook");

            MethodInfo method = rankedGradeBook.GetMethod("GetLetterGrade");

            //Setup successful conditions
            var students = new List<Student>
            {
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 1 }
                },
                new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 2 }
                },
                new Student("tom",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 3 }
                },
                new Student("tony",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 4 }
                },
                new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 5 }
                },
                new Student("john",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 6 }
                },
                new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 7 }
                },
                new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 8 }
                },
                new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 9 }
                },
                new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
                {
                    Grades = new List<double>{ 10 }
                }
            };

            gradeBook.GetType().GetProperty("Students").SetValue(gradeBook, students);

            Assert.True((char)method.Invoke(gradeBook, new object[] { 6 }) == 'C', "`GradeBook.GradeBooks.RankedGradeBook.GetLetterGrade` didn't give an C to students between the top 40% and 60% of the class.");
            Assert.True((char)method.Invoke(gradeBook, new object[] { 8 }) == 'B', "`GradeBook.GradeBooks.RankedGradeBook.GetLetterGrade` didn't give an B to students between the top 20% and 40% of the class.");
            Assert.True((char)method.Invoke(gradeBook, new object[] { 9 }) == 'A', "`GradeBook.GradeBooks.RankedGradeBook.GetLetterGrade` didn't give an A to students in the top 20% of the class.");
        }
    }
}
