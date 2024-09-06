namespace DSALibrary.Fibonacci;

public class Fibonacci
{
    public int FibonacciIterative(int x)
    {
        if (x <= 1) return x;

        var result = 0;
        var left = 0;
        var right = 1;

        for (var i = 2; i <= x; i++)
        {
            result = left + right;
            left = right;
            right = result;
        }

        return result;
    }
    public int FibonacciRecursion(int x)
    {
        if (x <= 1) return x;
        return FibonacciRecursion(x - 1) + FibonacciRecursion(x - 2);
    }

    public int FibonacciArray(int x)
    {
        if (x <= 1) return x;
        var sums = new int[x + 1];
        sums[0] = 0;
        sums[1] = 1;

        for (var i = 2; i <= x; i++)
        {
            sums[i] = sums[i - 1] + sums[i - 2];
        }

        return sums[x];
    }

    public int[] FibonacciSequence(int x)
    {
        if (x == 0) return new[] { 0 };
        if (x == 1) return new[] { 0, 1 };
        
        var sums = new int[x + 1];
        sums[0] = 0;
        sums[1] = 1;

        for (var i = 2; i <= x; i++)
        {
            sums[i] = sums[i - 1] + sums[i - 2];
        }

        return sums;
    }
}