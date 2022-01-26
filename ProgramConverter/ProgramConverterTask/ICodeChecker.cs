namespace ProgramConverterTask
{
    public interface ICodeChecker
    {
        bool CodeCheckSyntax(string line, string language);
    }
}
