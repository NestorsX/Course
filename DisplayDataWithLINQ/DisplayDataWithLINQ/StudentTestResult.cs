using System;

namespace DisplayDataWithLINQ
{
    public struct StudentTestResult : IComparable<StudentTestResult>
    {
        public string StudentName { get; private set; }
        public string TestName { get; private set; }
        public DateTime TestDate { get; private set; }
        public int TestScore { get; private set; }

        public StudentTestResult(string studentName, string testName, DateTime testDate, int testScore)
        {
            if (studentName == null || testName == null)
            {
                throw new ArgumentNullException();
            }

            if (studentName == string.Empty || testName == string.Empty || testDate > DateTime.Now || testScore < 0)
            {
                throw new ArgumentException();
            }

            StudentName = studentName;
            TestName = testName;
            TestDate = testDate;
            TestScore = testScore;
        }

        public int CompareTo(StudentTestResult other)
        {
            return TestScore.CompareTo(other.TestScore);
        }

        public override string ToString()
        {
            return string.Format("Студент: {0}\nТест: {1}\nДата: {2}\nРезультат: {3}", StudentName, TestName, TestDate.ToString("dd/MM/yyyy"), TestScore);
        }
    }
}
