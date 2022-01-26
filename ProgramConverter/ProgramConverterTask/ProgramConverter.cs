namespace ProgramConverterTask
{
    public class ProgramConverter : IConvertible
    {
        public string ConvertToCSharp(string line)
        {
            return "Code has been converted to C#";
        }

        public string ConvertToVB(string line)
        {
            return "Code has been converted to Visual Basic";
        }
    }
}
