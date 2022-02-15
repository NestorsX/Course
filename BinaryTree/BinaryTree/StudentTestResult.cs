using System;

namespace BinaryTree
{
    public struct StudentTestResult : IComparable<StudentTestResult>
    {
        private readonly string _studentName;
        private readonly string _testName;
        private readonly DateTime _testDate;
        private readonly int _testScore;

        public StudentTestResult(string studentName, string testName, DateTime testDate, int testScore)
        {
            if (studentName == null || testName == null)
            {
                throw new ArgumentNullException();
            }

            if(studentName == string.Empty || testName == string.Empty || testDate > DateTime.Now || testScore < 0)
            {
                throw new ArgumentException();
            }

            _studentName = studentName;
            _testName = testName;
            _testDate = testDate;
            _testScore = testScore;
        }

        public int CompareTo(StudentTestResult other)
        {
            return _testScore.CompareTo(other._testScore);
        }

        public override string ToString()
        {
            return string.Format("Студент: {0}\nТест: {1}\nДата: {2}\nРезультат: {3}", _studentName, _testName, _testDate.ToString("dd/MM/yyyy"), _testScore);
        }
    }
}
