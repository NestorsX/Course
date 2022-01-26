namespace ProgramConverterTask
{
    public interface IConvertible
    {
        string ConvertToCSharp(string line);

        string ConvertToVB(string line);
    }
}
