using System;

public class Wagon
{
    public Wagon left;
    public Wagon right;
    public int number;

    public Wagon(int newWagonNumber, Wagon newWagonLeft = null, Wagon newWagonRight = null)
    {
        number = newWagonNumber;
        left = newWagonLeft;
        right = newWagonRight;
    }
}

public class TrainComposition
{
    Wagon First;
    Wagon Last;
    int Count = 0;

    public TrainComposition()
    {
        First = null;
        Last = null;
        Count = 0;
    }

    public void AttachWagonFromLeft(int wagonId)
    {
        if (Count == 0)
        {
            First = Last = new Wagon(wagonId);
        }
        else
        {
            var newWagon = new Wagon(wagonId, null, First);
            First.left = newWagon;
            First = newWagon;
        }
        Count++;
    }

    public void AttachWagonFromRight(int wagonId)
    {
        if (Count == 0)
        {
            First = Last = new Wagon(wagonId);
        }
        else
        {
            var newWagon = new Wagon(wagonId, Last, null);
            Last.right = newWagon;
            Last = newWagon;
        }
        Count++;
    }

    public int DetachWagonFromLeft()
    {
        if (Count < 1)
        {
            throw new Exception("No wagon left to dettach!");
        }

        var returnedWagonNumber = First.number;

        if (Count == 1)
        {
            First = Last = null;
        }
        else
        {
            First = First.right;
            First.left = null;
        }
        Count--;

        return returnedWagonNumber;
    }

    public int DetachWagonFromRight()
    {
        if (Count < 1)
        {
            throw new Exception("No wagon left to dettach!");
        }

        var returnedWagonNumber = Last.number;

        if (Count == 1)
        {
            First = Last = null;
        }
        else
        {
            Last = Last.left;
            Last.right = null;
        }
        Count--;

        return returnedWagonNumber;
    }

    public static void TestTrainComposition(string[] args)
    {
        TrainComposition train = new TrainComposition();
        train.AttachWagonFromLeft(7);
        train.AttachWagonFromLeft(13);
        Console.WriteLine(train.DetachWagonFromRight()); // 7
        Console.WriteLine(train.DetachWagonFromLeft()); // 13
    }
}
