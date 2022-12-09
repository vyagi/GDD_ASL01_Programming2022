namespace ObjectOrientedProgramingContinuation;

public class InvoiceProcessor
{
    private readonly ILinesProvider _linesProvider;

    public InvoiceProcessor(ILinesProvider linesProvider) => 
        _linesProvider = linesProvider;

    public Dictionary<string, decimal> GroupByCategory()
    {
        var lines = _linesProvider.GetLines();

        var dictionary = new Dictionary<string, decimal>();

        for (var i = 1; i < lines.Length; i++)
        {
            var line = lines[i];

            var split = line.Split(";");

            var category = split[1];
            var price = Convert.ToDecimal(split[2].Replace(".", ","));

            if (dictionary.ContainsKey(category))
            {
                dictionary[category] += price;
            }
            else
            {
                dictionary[category] = price;
            }
        }

        return dictionary;
    }
}