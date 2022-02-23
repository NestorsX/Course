using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DisplayDataWithLINQ.Tests
{
    [TestClass]
    public class StudentTestResultTests
    {
		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException), "")]
		public void CtorStudentNameParam_ThrowsArgumentNullException()
		{
			var result = new StudentTestResult(null, "Test 1", DateTime.Now, 10);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException), "")]
		public void CtorTestNameParam_ThrowsArgumentNullException()
		{
			var result = new StudentTestResult("Student 1", null, DateTime.Now, 10);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException), "")]
		public void CtorStudentNameParam_ThrowsArgumentException()
		{
			var result = new StudentTestResult("", "Test 1", DateTime.Now, 10);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException), "")]
		public void CtorTestNameParam_ThrowsArgumentException()
		{
			var result = new StudentTestResult("Student 1", "", DateTime.Now, 10);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException), "")]
		public void CtorTestDateParam_ThrowsArgumentException()
		{
			var result = new StudentTestResult("Student 1", "Test 1", DateTime.Now.AddDays(1), 10);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException), "")]
		public void CtorTestScoreParam_ThrowsArgumentException()
		{
			var result = new StudentTestResult("Student 1", "Test 1", DateTime.Now, -1);
		}
	}
}
