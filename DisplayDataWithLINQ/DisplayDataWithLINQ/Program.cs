using System;
using System.Collections.Generic;

namespace DisplayDataWithLINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = AppContext.BaseDirectory + @"file.dat";
            var dataViewer = new StudentTestsDataViewer();
            dataViewer.Read(path, 3);
            List<StudentTestResult> list = dataViewer.View(SortingDirection.Desc);
            list.ForEach(x => Console.WriteLine(x));
        }
    }
}
