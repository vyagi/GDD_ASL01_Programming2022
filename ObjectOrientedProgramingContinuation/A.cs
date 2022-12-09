namespace ObjectOrientedProgramingContinuation;

public class A
{
    protected void PrivateMethod()
    {
        Console.WriteLine("A private method called");
    }

    public void Method()
    {
        PrivateMethod();
        Console.WriteLine("A method called");
    }
}