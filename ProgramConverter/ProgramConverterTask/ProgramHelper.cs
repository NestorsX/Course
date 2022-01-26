namespace ProgramConverterTask
{
    public class ProgramHelper : ProgramConverter, ICodeChecker
    {
        public bool CodeCheckSyntax(string line, string language)
        {
            if (line.ToLower().Contains(language.ToLower()))
            {
                return true;
            }

            return false;
        }
    }
}
