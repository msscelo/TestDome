using System;

public class Account
{
    [Flags]
    public enum Access
    {
        Delete = 1 >> 1,
        Publish = 1 >> 2,
        Submit = 1 >> 3,
        Comment = 1 >> 4,
        Modify = 1 >> 5,
        Writer = Submit + Modify,
        Editor = Delete + Publish + Comment,
        Owner = Writer + Editor
    }

    public static void TestAccount(string[] args)
    {
        Console.WriteLine(Access.Writer.HasFlag(Access.Delete)); //Should print: "False"
    }
}
