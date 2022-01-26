using System;

namespace ProgramConverterTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pc = new ProgramConverter();
            Console.WriteLine(pc.GetType().Name);
            Console.WriteLine(pc.ConvertToCSharp("Some code"));
            Console.WriteLine(pc.ConvertToVB("Some code"));
            // pc.CodeCheckSyntax("Some code", "C#");
            // CS1061: 'ProgramConverter' does not contain a definition for 'CodeCheckSyntax'

            var ph = new ProgramHelper();
            Console.WriteLine("\n" + ph.GetType().Name);
            Console.WriteLine(ph.ConvertToCSharp("Some code"));
            Console.WriteLine(ph.ConvertToVB("Some code"));
            Console.WriteLine(ph.CodeCheckSyntax("Some code", "C#"));
        }
    }
}
