using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace DisplayDataWithLINQ.Tests
{
	[TestClass]
	public class StudentTestsDataViewerTests
    {
		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException), "")]
		public void ReadWithNullPath_ThrowsArgumentNullException()
		{
			var dataViewer = new StudentTestsDataViewer();
			dataViewer.Read(null);
		}

		[TestMethod]
		public void ReadAllWithCorrectPath()
        {
            var results = new List<StudentTestResult>();
            using (var reader = new BinaryReader(File.Open("file.dat", FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    string studentName = reader.ReadString();
                    string testName = reader.ReadString();
                    DateTime testDate = Convert.ToDateTime(reader.ReadString());
                    int testScore = reader.ReadInt32();
                    results.Add(new StudentTestResult(studentName, testName, testDate, testScore));
                }
            }

            var dataViewer = new StudentTestsDataViewer();
            dataViewer.Read("file.dat");
            var dataViewerResult = dataViewer.View(SortingDirection.Asc);
            bool isEqual = true;
            if (results.Count != dataViewerResult.Count)
            {
                Assert.IsTrue(false);
            }

            for (var i = 0; i < results.Count; i++)
            {
                if (!results[i].Equals(dataViewerResult[i]))
                {
                    isEqual = false;
                    break;
                }
            }

            Assert.IsTrue(isEqual);
        }
	}
}
