namespace DSALibrary.LowestCommonDenominator;

public class Maths
{
    public int GreatestCommonDivisor(int x, int y)
    {
        return y == 0 ? x : GreatestCommonDivisor(y, x % y);
    }
}