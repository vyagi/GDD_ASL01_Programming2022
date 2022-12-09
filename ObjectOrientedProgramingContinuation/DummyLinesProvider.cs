namespace ObjectOrientedProgramingContinuation;

public class DummyLinesProvider : ILinesProvider
{
    public string[] GetLines() =>
        new[]
        {
            "Blouse;Clothing;223;2022-09-25",
            "Party;Misc;100.12;2022-08-12",
            "Jacket;Clothing;200;2022-11-02"
        };
}