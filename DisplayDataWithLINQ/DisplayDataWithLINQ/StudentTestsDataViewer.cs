using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DisplayDataWithLINQ
{
    public class StudentTestsDataViewer
    {
        private BinaryTree<StudentTestResult> _root;

        public void Read(string path, int rowsCount = -1)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            using (var reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                int i = 0;
                while (i != rowsCount && reader.PeekChar() > -1)
                {
                    i++;
                    string studentName = reader.ReadString();
                    string testName = reader.ReadString();
                    DateTime testDate = Convert.ToDateTime(reader.ReadString());
                    int testScore = reader.ReadInt32();
                    if (_root == null)
                    {
                        _root = new BinaryTree<StudentTestResult>(new StudentTestResult(studentName, testName, testDate, testScore));
                        continue;
                    }

                    _root.Add(new StudentTestResult(studentName, testName, testDate, testScore));
                }
            }
        }

        public List<StudentTestResult> View(SortingDirection direction, string studentName = "", string testName = "", string testDate = "", int testScore = -1)
        {
            if (studentName == null || testName == null || testDate == null)
            {
                throw new ArgumentNullException();
            }

            if (testScore < -1)
            {
                throw new ArgumentException();
            }

            var result = from student in _root
                         where student.StudentName.Contains(studentName)
                         && student.TestName.Contains(testName)
                         && student.TestDate.ToString("dd/MM/yyyy").Contains(testDate)
                         select student;
            if (testScore > -1)
            {
                result = result.Where(x => x.TestScore == testScore);
            }

            if (direction == SortingDirection.Asc)
            {
                return result.OrderBy(x => x.StudentName).ToList();
            }

            return result.OrderByDescending(x => x.StudentName).ToList();
        }
    }
}
