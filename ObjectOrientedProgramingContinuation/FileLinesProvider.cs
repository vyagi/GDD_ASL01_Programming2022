namespace ObjectOrientedProgramingContinuation;

public class FileLinesProvider : ILinesProvider
{
    public string[] GetLines() => 
        File.ReadAllLines("C:\\Users\\Marcin\\Desktop\\Invoices.txt").Skip(1).ToArray();
}