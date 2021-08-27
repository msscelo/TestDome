using System;

public class RoutePlanner
{
    private static bool Inbounds(int row, int column, int size1, int size2)
    {
        return row >= 0 && column >= 0 && row < size1 && column < size2;
    }

    private static bool IsSame(int fromRow, int fromColumn, int toRow, int toColumn)
    {
        return fromRow == toRow && fromColumn == toColumn;
    }
    private static bool[,] Visited;

    public static bool RouteExists(int fromRow, int fromColumn, int toRow, int toColumn, bool[,] mapMatrix)
    {
        var setup = false;
        if (Visited == null)
        {
            // Console.WriteLine("Starting at: " + fromRow + ", " + fromColumn);
            // Console.WriteLine("Objective at: " + toRow + ", " + toColumn);
            // PrintMatrix(mapMatrix);
            setup = true;
            Visited = new bool[mapMatrix.GetLength(0), mapMatrix.GetLength(1)];
            if (!Inbounds(fromRow, fromColumn, mapMatrix.GetLength(0), mapMatrix.GetLength(1)))
            {
                if (setup)
                {
                    Visited = null;
                }
                throw new Exception("starting out of bounds!");
            }
            if (!Inbounds(toRow, toColumn, mapMatrix.GetLength(0), mapMatrix.GetLength(1)))
            {
                if (setup)
                {
                    Visited = null;
                }
                throw new Exception("objective out of bounds!");
            }
            if (!mapMatrix[toRow, toColumn])
            {
                if (setup)
                {
                    Visited = null;
                }

                return false;
            }
        }
        Visited[fromRow, fromColumn] = true;

        if (IsSame(fromRow, fromColumn, toRow, toColumn))
        {
            Visited = null;

            return true;
        }

        if (!mapMatrix[fromRow, fromColumn])
        {
            if (setup)
            {
                Visited = null;
            }
            return false;
        }
        var next = new int[,] {
            { fromRow - 1, fromColumn },
            { fromRow + 1, fromColumn },
            { fromRow, fromColumn - 1},
            { fromRow, fromColumn + 1 },
        };

        for (int i = 0; i < 4; i++)
        {
            if (Inbounds(next[i, 0], next[i, 1], mapMatrix.GetLength(0), mapMatrix.GetLength(1)) && !Visited[next[i, 0], next[i, 1]])
            {
                if (RouteExists(next[i, 0], next[i, 1], toRow, toColumn, mapMatrix))
                {
                    Visited = null;

                    return true;
                }
            }
        }

        if (setup)
        {
            Visited = null;
        }

        return false;
    }

    private static void PrintMatrix(bool[,] mapMatrix)
    {
        for (int i = 0; i < mapMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < mapMatrix.GetLength(1); j++)
            {
                Console.Write(mapMatrix[i, j] ? " - " : " x ");
            }
            Console.Write("\n");
        }
    }

    public static void TestRoutePlanner(string[] args)
    {
        Test1();
        Test2();
        Test3();
        Test4();
        Test5();
        Test6();
    }

    private static void Test1()
    {
        bool[,] mapMatrix = {
            { true,  true,  true},
            {false, false,  true},
            {false, false,  true},
        };

        Console.WriteLine(RouteExists(0, 0, 2, 2, mapMatrix));
    }

    private static void Test2()
    {
        bool[,] mapMatrix = {
            { true,  true,  true, false, false, false},
            {false, false,  true,  true,  true,  true},
            {false, false,  true, false, false,  true},
            {false, false,  true, false, false,  true}
        };

        Console.WriteLine(RouteExists(0, 0, 3, 5, mapMatrix));
    }

    private static void Test3()
    {
        bool[,] mapMatrix = {
            { true,  true, false, false},
            {false,  true, false, false},
            {false,  true, false, false},
            {false,  true, false, false},
            {false,  true,  true, false},
            {false, false,  true,  true},
        };

        Console.WriteLine(RouteExists(0, 0, 5, 3, mapMatrix));
    }
    private static void Test4()
    {
        bool[,] mapMatrix = {
            { true, true,  true},
            {false, true,  false},
            {false, true,  false},
            {false, true,  false},
            {false, true,  false},
        };

        Console.WriteLine(RouteExists(0, 0, 4, 1, mapMatrix));
    }

    private static void Test5()
    {
        bool[,] mapMatrix = {
            { true,  true,  true, false, false, false},
            {false, false,  true,  true,  false,  true},
            {false, false,  true, true, false,  true},
            {false, false,  true, true, false,  true}
        };

        Console.WriteLine(RouteExists(0, 0, 3, 5, mapMatrix));
    }

    private static void Test6()
    {
        bool[,] mapMatrix = {
            { true,  true, false, false},
            {false,  true, false, false},
            {false,  true, false, false},
            {false,  true, false, false},
            {false,  true,  true, false},
            {false, true,  false,  true},
        };

        Console.WriteLine(RouteExists(0, 0, 5, 3, mapMatrix));
    }
}
